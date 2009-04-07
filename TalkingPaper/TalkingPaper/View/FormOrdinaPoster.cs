using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;

namespace TalkingPaper
{
    public partial class FormOrdinaPoster : FormSchema
    {

        /**
         * Bisogna pensare anche che non posso fare get_posters generico: deve essere legato alla singola mostra:
         *  prima scelgo la mostra
         *  poi scelgo l'ordine dei poster
         *  poi scelgo l'ordine dei contenuti per poster
         * 
         * attenzione: fare altro debug...poi: chiudere e riaprire...
         * 
         * */
        private NHibernateManager nh_mng;
        private IList posterList;
        private IList mostraList;
        private int indiceMostra;
        private int posizione_current;
        private int indicePoster;
        private Mostra selected_mostra;
        private IList new_posterList;
        private IList afterPosterList;
        private bool mostraSelezionata;

        public FormOrdinaPoster()
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            mostraSelezionata = false;
            afterPosterList = new ArrayList();
            new_posterList = new ArrayList();
            selected_mostra = new Mostra();
            posizione_current = 0;
            indiceMostra = 0;
            nh_mng = new NHibernateManager();
            mostraList = get_mostre();

            //Aggiorna la listaMostra
            if(mostraList.Count > 0)
            {
                this.listBoxMostra.BeginUpdate();

                for (int i = 0; i < mostraList.Count; i++)
                {
                    this.listBoxMostra.Items.Add(((Mostra)mostraList[i]).Nome);
                }

                this.listBoxMostra.EndUpdate();

            }
            else
            {
                this.labelMostra.Visible = true;
            }
        }

        private IList get_mostre()
        {
            IList result = null;

            using (ISession tempS = nh_mng.Session)
            //using (ITransaction tempT = tempS.BeginTransaction())
            {
                try
                {
                    IQuery q = tempS.CreateQuery(
                    "select mostra " +
                    "from Mostra as mostra "
                        );
                    result = q.List();
                    //tempT.Commit();
                    Console.WriteLine("Query di get_mostre eseguita, commit");
                }
                catch (Exception ex)
                {

                    //tempT.Rollback();
                    Console.WriteLine("Query di get_mostra abortita, rollback.\nMessage = " + ex.Message);
                    MessageBox.Show("Query di get_mostre non riuscita\n" + ex.Message , "ERRORE",MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                finally
                {
                    tempS.Close();
                }
            }
            return result;

        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {

            if (mostraSelezionata == true)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Stai per cambiare mostra: tutti i cambiamenti fatti senza aver salvato" +
                "\nandranno perduti\n", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mostraSelezionata = false;
            }else{
            
                /**
                 * Pulisco la listBoxBefore
                 * */
                int tmp = listBoxBefore.Items.Count;
                if (tmp != 0)
                {
                    while (tmp != 0)
                    {
                        listBoxBefore.Items.RemoveAt(tmp -1 );
                        tmp = listBoxBefore.Items.Count;
                        new_posterList.RemoveAt(0); // devo svuotare la lista
                    }
                }
                else
                    this.label1.Visible = false;

                //devo pulire la textBoxAfter
                if( listBoxAfter.Items.Count > 0){
                    listBoxAfter.BeginUpdate();
                    while(listBoxAfter.Items.Count !=0 ){
                    this.listBoxAfter.Items.RemoveAt(0);
                    afterPosterList.RemoveAt(0);
                    }
                    listBoxAfter.EndUpdate();
                }
                    //Estraiamo la giusta mostra

                indiceMostra = listBoxMostra.SelectedIndex;
                selected_mostra = (Mostra)this.mostraList[indiceMostra];
                posterList = selected_mostra.PosterLista;
                Console.WriteLine("Mostra selezionata, " + selected_mostra.Nome + " e num poster = " + posterList.Count);
                //Aggiorna la listaBefore, costruendo la new_posterList che è la posterList ordinata
                int posterCount = posterList.Count;
                int tmp_ord = 0;
                if (posterCount > 0)
                {
                    this.listBoxBefore.BeginUpdate();

                    for (int i = 0; i < posterCount; i++)
                    {
                        for (int x = 0; x < posterCount; x++)
                        {
                            if (tmp_ord == ((Poster)posterList[x]).Ordine)
                            {
                                this.listBoxBefore.Items.Add(((Poster)posterList[x]).Nome);
                                this.new_posterList.Add((Poster)posterList[x]);
                            }
                        }
                        tmp_ord++;
                    }

                    this.listBoxBefore.EndUpdate();

                }
                else
                {
                    this.label1.Visible = true;
                }
        }
            }//chiudo OnMouseClick
            

        private void OnDoubleClikBBefore(object sender, MouseEventArgs e)
        {
            mostraSelezionata = true;

            indicePoster = listBoxBefore.SelectedIndex;

            this.listBoxBefore.BeginUpdate();
            this.listBoxBefore.Items.RemoveAt(indicePoster);
            this.listBoxBefore.EndUpdate();

            this.listBoxAfter.BeginUpdate();
            this.listBoxAfter.Items.Add(((Poster)new_posterList[indicePoster]).Nome);
            this.afterPosterList.Add(((Poster)new_posterList[indicePoster]));
            this.new_posterList.RemoveAt(indicePoster);
            this.listBoxAfter.EndUpdate();

            if( new_posterList.Count == 0 )
            {
                buttonSalva.Enabled = true;
            }
        }

        private void OnMouseDoubleClickBAfter(object sender, MouseEventArgs e)
        {
            buttonSalva.Enabled = false;

            indicePoster = listBoxAfter.SelectedIndex;

            this.listBoxAfter.BeginUpdate();
           this.listBoxAfter.Items.RemoveAt(indicePoster);
            this.listBoxAfter.EndUpdate();
 
            this.listBoxBefore.BeginUpdate();
            this.listBoxBefore.Items.Add(((Poster)afterPosterList[indicePoster]).Nome);
            this.new_posterList.Add((Poster)afterPosterList[indicePoster]);
            this.afterPosterList.RemoveAt(indicePoster);
            this.listBoxBefore.EndUpdate();

        }

        private void buttonSalva_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < afterPosterList.Count; i++ )
            {
                ((Poster)(afterPosterList[i])).Ordine = i;
            }


            using( ISession tempS = this.nh_mng.Session)
            {
                try
                {
                    selected_mostra.PosterLista = afterPosterList;
                    //tempS.SaveOrUpdate(selected_mostra);
                    tempS.Update(selected_mostra);
                    tempS.Flush();

                }
                catch(Exception exc)
                {
                    Console.WriteLine("Errore nel salvataggio, message = " + exc.Message);
                }
                finally
                {
                    tempS.Close();
                }
            }
            //devo pulire la textBoxAfter
            if (listBoxAfter.Items.Count > 0)
            {
                listBoxAfter.BeginUpdate();
                while (listBoxAfter.Items.Count != 0)
                {
                    this.listBoxAfter.Items.RemoveAt(0);
                }
                listBoxAfter.EndUpdate();
            }
            this.mostraSelezionata = false;
            //devo ripulire la textBoxBefore
            if (listBoxBefore.Items.Count > 0)
            {
                listBoxBefore.BeginUpdate();
                while (listBoxBefore.Items.Count != 0)
                {
                    this.listBoxBefore.Items.RemoveAt(0);
                }
                listBoxBefore.EndUpdate();
            }

            buttonSalva.Enabled = false;

            FormOrdinaPoster nuova_f = new FormOrdinaPoster();
            nuova_f.Show();
            this.Visible = false;
        }

        private void buttonEsci_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Tutti i cambiamenti effettuati senza aver salvato andranno perduti" +
            "\nVuoi davvero uscire?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if( dr == DialogResult.Yes)
                this.Close();
        }

        private void ButtonAggiungi_Click(object sender, EventArgs e)
        {
            mostraSelezionata = true;

            indicePoster = listBoxBefore.SelectedIndex;

            this.listBoxBefore.BeginUpdate();
            this.listBoxBefore.Items.RemoveAt(indicePoster);
            this.listBoxBefore.EndUpdate();

            this.listBoxAfter.BeginUpdate();
            this.listBoxAfter.Items.Add(((Poster)new_posterList[indicePoster]).Nome);
            this.afterPosterList.Add(((Poster)new_posterList[indicePoster]));
            this.new_posterList.RemoveAt(indicePoster);
            this.listBoxAfter.EndUpdate();

            if (new_posterList.Count == 0)
            {
                buttonSalva.Enabled = true;
            }
        }

        private void buttonRimuovi_Click(object sender, EventArgs e)
        {
            buttonSalva.Enabled = false;

            indicePoster = listBoxAfter.SelectedIndex;

            this.listBoxAfter.BeginUpdate();
            this.listBoxAfter.Items.RemoveAt(indicePoster);
            this.listBoxAfter.EndUpdate();

            this.listBoxBefore.BeginUpdate();
            this.listBoxBefore.Items.Add(((Poster)afterPosterList[indicePoster]).Nome);
            this.new_posterList.Add((Poster)afterPosterList[indicePoster]);
            this.afterPosterList.RemoveAt(indicePoster);
            this.listBoxBefore.EndUpdate();
        }

        private void FormOrdinaPoster_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add by mac
            if (pictureBoxPost2.Visible = true)
            {
                pictureBoxPost2.Visible = false;
                textBoxPost.Visible = false;
            }
            else
            {
                pictureBoxPost2.Visible = true;
                textBoxPost.Visible = true;
            }
        }



    }
}