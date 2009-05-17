using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QuartzTypeLib;
using System.Xml;
using TalkingPaper.Common;


namespace TalkingPaper.Execution
{
    public partial class EsecuzioneCartelloneForm : FormSchema
    {

        private ControlLogic.ExecutionControl control;
        private Model.Poster poster;
        private Model.Griglia griglia;

        private bool attivo; // variabile che identifica lo status del sistema

        
        //Per gestire lo stato della risorsamultimediale
        private enum MediaStatus { None, Stopped, Paused, Running, End };
        private MediaStatus m_CurrentStatus;
        private FilgraphManager m_objFilterGraph = null;
        private IBasicAudio m_objBasicAudio = null;
        private IVideoWindow m_objVideoWindow = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;
        
        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;
        private FormVideo f_video;
        

        

        public EsecuzioneCartelloneForm(string nomePoster)
        {
            InitializeComponent();

            control = new ControlLogic.ExecutionControl();

            poster = control.getPoster(nomePoster);
            String nomeGriglia = poster.getNomeGriglia();
            griglia = control.getGriglia(nomeGriglia);

            if (poster == null)
            {
                throw new Exception("Errore!! Esecuzione di un poster inesistente");
            }
            
            f_video = new FormVideo();
      
            m_CurrentStatus = MediaStatus.None;

            attivo = true;
            
            UpdateStatusBar();


        }


        /// <summary>
        /// metodo per la gestione della lettura del tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rfid_StatusUpdateEvent(string id)
        {
            List<Model.Contenuto> contenuti;
            int[] coord = griglia.getCoordFromTag(id);
            
            /*if (oldId.Equals(id) == true && (m_CurrentStatus == MediaStatus.Paused || m_CurrentStatus == MediaStatus.Running))
            //if( oldId.Equals(id) == true && ( risorsa_attiva == true || risorsa_pausa == true))
            {
                //non fare niente
                Console.WriteLine("Id già letto, non eseguo alcuna operazione");
                //this.richTextBox1.Text += "\nTag già letto: non eseguo alcuna operazione";

            }
            else if (oldId.Equals(id) == false)
            {
                labelTagNonPresente.Visible = false;
                //Se non è uguale al vecchio, devo verificare che id è
                /*
                 * ricerca dell'id
                 *  Se è un id non di controllo, e c'è file in esecuz non fai niente
                 * /
                oldId = id;
                //Risorsamultimediale ris_current = new Risorsamultimediale();

                using (ISession tempS = nh_mng.Session)
                //using (ITransaction tempT = tempS.BeginTransaction())
                {
                    this.richTextBox1.Text += "\nTag letto: inizio processo query-esecuzione. ID = " + id;
                    try
                    {
                        IQuery q = tempS.CreateQuery(
                            "from Contenuto as cont where cont.Rfidtag = :rfid AND cont.Poster.IDposter = :post");

                        q.SetParameter("rfid", id);
                        q.SetParameter("post", cod_poster );
                        cont_current = (Contenuto2)q.List()[0];
                        //tempT.Commit();
                        Console.WriteLine("Query di ricerca Contenuto by id ok, commit");
                        try
                        {
                            Console.WriteLine("Ecco la risorsa multimediale " + cont_current.RisorsaMultimediale.Path);
                        }
                        catch {
                            Console.WriteLine("Non cìè risorsa");
                        }
                        this.richTextBox1.Text += "\nQuery di ricerca Contenuto by id: OK \n";

                        if (cont_current.Tipo.Tipo.Equals("Risorsa") == true)
                        {
                            string current_path;
                            current_path = "error";
                            /*Ora devo verificare se ho un profilo da tener conto o no
                             * Perchè io estraggo sempre un oggetto contenuto, poi devo verificare
                             *  quale è la corretta RisorsaMultimediale associata guardando
                             *  nella profiloLista.
                             * 
                             * /
                            if (u_current.Profilo != null && u_current.Rfidtag != null)
                            {
                                // ho l'utente e il profilo, posso fare la scelta in base ai nuovi criteri
                                if (cont_current.RisorsaMultimediale.ProfiloLista.Count == 0)
                                {
                                    Console.WriteLine("Lista vuota...");
                                }
                                else
                                {

                                    foreach (Profilo prof in cont_current.RisorsaMultimediale.ProfiloLista)
                                    {
                                        Console.WriteLine("Ecco i profili " + prof.Nome);

                                        if (prof.IDprofilo == u_current.Profilo.IDprofilo)
                                        {
                                            Console.WriteLine("Trovato un utente corrispondente al profilo " + prof.Nome);
                                            current_path = directoryPath + cont_current.RisorsaMultimediale.Path + "/" +
                                                                cont_current.RisorsaMultimediale.Nome;
                                        }
                                    }
                                }
                                //chiudo if: se adesso ho ancora current_path vuoto,è perchè non c'è 
                                // nessuna risorsa collegata al contenuto e con il corretto Profilo
                                if (current_path.Equals("error") == true)
                                {
                                    throw new Exception("Non c'è nessuna risorsa collegata al profilo");
                                }
                            }

                            current_path = directoryPath + cont_current.RisorsaMultimediale.Path + "/" +
                     cont_current.RisorsaMultimediale.Nome;

                            CleanUp();
                            m_objFilterGraph = new FilgraphManager();
                            m_objFilterGraph.RenderFile(current_path);

                            m_objBasicAudio = m_objFilterGraph as IBasicAudio;

                            try
                            {/** vecchia versione
                                m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                                m_objVideoWindow.Owner = (int)panel2.Handle;
                                m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                                m_objVideoWindow.SetWindowPosition(panel2.ClientRectangle.Left,
                                    panel2.ClientRectangle.Top,
                                    panel2.ClientRectangle.Width,
                                    panel2.ClientRectangle.Height);
                              * 
                              * /
                                m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                                m_objVideoWindow.Owner = (int)f_video.Handle;
                                m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                                //m_objVideoWindow.FullScreenMode = 1;
                                m_objVideoWindow.SetWindowPosition(f_video.ClientRectangle.Left,
                                    f_video.ClientRectangle.Top,
                                    f_video.ClientRectangle.Width,
                                    f_video.ClientRectangle.Height);
                                f_video.Show();
                            }
                            catch (Exception)
                            {
                                m_objVideoWindow = null;
                            }

                            m_objMediaEvent = m_objFilterGraph as IMediaEvent;

                            m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
                            m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);

                            m_objMediaPosition = m_objFilterGraph as IMediaPosition;

                            m_objMediaControl = m_objFilterGraph as IMediaControl;

                            m_objMediaControl.Run();
                            m_CurrentStatus = MediaStatus.Running;

                            //update da fare...
                            //aggiornamento dello storico
                            UpdateStatusBar();
                            arrayStorico.Add(cont_current);
                            arrayStoricoData.Add(DateTime.Now);
                            updateLabelForm();
                            Console.WriteLine("Update ed arraystorico effettuati");
                        }
                        else if (cont_current.Tipo.Tipo.Equals("Controllo") == true)
                        {
                            //Devo mettere adesso per ogni caso gli update dei label...

                            switch (cont_current.Tipo.Descrizione)
                            {
                                case "Stop":
                                    if (m_CurrentStatus == MediaStatus.Running || m_CurrentStatus == MediaStatus.Paused)
                                    {
                                        m_objMediaControl.Stop();
                                        m_objMediaPosition.CurrentPosition = 0;
                                        m_CurrentStatus = MediaStatus.Stopped;
                                        this.labelStatus.Text = "Stopped";
                                        this.labelRfidTag.Text = cont_current.Rfidtag;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sono in Stop, ma non faccio niente, è già stop");
                                        this.richTextBox1.Text += "\nSono in Stop, ma non faccio niente, è già stop.";
                                        break;
                                    };

                                case "Pausa":
                                    if (m_CurrentStatus == MediaStatus.Running)
                                    {
                                        m_objMediaControl.Pause();
                                        m_CurrentStatus = MediaStatus.Paused;
                                        this.labelStatus.Text = "Paused";
                                        this.labelRfidTag.Text = cont_current.Rfidtag;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sono in Pausa, ma non faccio niente che non c'è nulla in esecuzione");
                                        this.richTextBox1.Text += "\nSono in Pausa, ma non faccio niente che non c'è nulla in esecuzione.";
                                        break;
                                    }

                                case "Play":
                                    if (m_CurrentStatus == MediaStatus.Paused || m_CurrentStatus == MediaStatus.Stopped)
                                    {
                                        m_objMediaControl.Run();
                                        m_CurrentStatus = MediaStatus.Running;
                                        this.labelStatus.Text = "Running";
                                        this.labelRfidTag.Text = cont_current.Rfidtag;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sono in Play, ma non faccio niente che non c'è nulla da rimettere in exe");
                                        this.richTextBox1.Text += "\nSono in Play, ma non faccio niente che non c'è nulla da rimettere in exe";
                                        break;
                                    }

                                case "Raccontami tutto": MessageBox.Show("Raccontami tutto da implementare...");
                                    break;

                                case "Solo principale": MessageBox.Show("Solo principale da implementare...");
                                    break;

                                default: MessageBox.Show("Sono nel default, controllo non registrato nel database!!!");
                                    break;

                            }
                            UpdateStatusBar();
                            arrayStorico.Add(cont_current);
                            arrayStoricoData.Add(DateTime.Now);
                            // updateLabelForm();
                            Console.WriteLine("Update ed array storico effettuati");
                            //this.richTextBox1.Text += "\nUpdate array storico effettuato";
                        }
                        else // se non è Risorsa o controllo, allora è sconosciuto
                        {
                            string er = "Tag " + id + " non presente nel database";
                            Console.WriteLine("Tag +" + id + " non presente nel database");
                            this.labelTagNonPresente.Visible = true;
                            arrayError.Add(er);
                            arrayErrorData.Add(DateTime.Now);
                            this.richTextBox1.Text += "\n" + er;
                        }

                    }
                    catch (FileNotFoundException file_not)
                    {
                        Console.WriteLine("File not file exception.\nMessage = " + file_not.Message);
                        arrayError.Add(file_not.Message);
                        arrayErrorData.Add(DateTime.Now);
                        MessageBox.Show("File non trovato", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    catch (NullReferenceException null_ref)
                    {
                        Console.WriteLine("Null reference exception.\nMessage = " + null_ref.Message);
                        arrayError.Add(null_ref.Message);
                        arrayErrorData.Add(DateTime.Now);
                        /**
                         * Dovrei creare uno spazio nella form dedicato agli errori, in cui
                         *  far apparire tutti qst messaggi di errore, ed eventualmente
                         *  suggerimenti per risolverli...
                         * /

                    }
                    catch (ArgumentOutOfRangeException argOutEx)
                    {
                        try
                        {
                            IQuery q = tempS.CreateQuery(
                                  "from Utente as ut where ut.Rfidtag = :rfid");

                            q.SetParameter("rfid", id);
                            u_current = (Utente)q.List()[0];
                            //tempT.Commit();
                            Console.WriteLine("Query di ricerca Utente by id ok, commit");
                            Console.WriteLine("Ecco l'utente " + u_current.Nome + " " + u_current.Cognome);
                            this.richTextBox1.Text += "\nQuery di ricerca Utente by id " + id + ": OK \n";
                            this.labelUtente.Visible = true;
                            this.labelProfilo.Visible = true;
                            this.labelRfidTag.Visible = true;
                            this.labelUtente.Text = u_current.Nome + " " + u_current.Cognome;
                            this.labelProfilo.Text = u_current.Profilo.Nome;
                            this.labelRfidTag.Text = id;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Errore\nMessage = " + ex.Message);
                            string err = "Errore\nMessage= " + ex.Message + "\nProbabilmente il tag " + id + " non è presente nel db";
                            arrayError.Add(ex.Message);
                            arrayErrorData.Add(DateTime.Now);
                            this.richTextBox1.Text += "\n" + err;
                            this.labelTagNonPresente.Visible = true;
                        }

                    }

                    catch (Exception ex)
                    {
                        //tempT.Rollback();
                        Console.WriteLine("Errore\nMessage = " + ex.Message);
                        string err = "Errore\nMessage= " + ex.Message;
                        arrayError.Add(ex.Message);
                        arrayErrorData.Add(DateTime.Now);
                        this.richTextBox1.Text += "\nErrore nell'esecuzione della query al db.\nMessage = " + ex.Message;
                        this.labelTagNonPresente.Visible = true;

                    }
                    finally
                    {
                        tempS.Close();
                    }
                }//fine using ITransaction
            }// fine di else if (oldId.Equals(id) == false)*/
        }// fine void statusUpdate... 

        

        

        private void CleanUp()
        {
            if (m_objMediaControl != null)
                m_objMediaControl.Stop();

            m_CurrentStatus = MediaStatus.Stopped;

            if (m_objMediaEventEx != null)
                m_objMediaEventEx.SetNotifyWindow(0, 0, 0);

            if (m_objVideoWindow != null)
            {
                m_objVideoWindow.Visible = 0;
                m_objVideoWindow.Owner = 0;
            }

            if (m_objMediaControl != null) m_objMediaControl = null;
            if (m_objMediaPosition != null) m_objMediaPosition = null;
            if (m_objMediaEventEx != null) m_objMediaEventEx = null;
            if (m_objMediaEvent != null) m_objMediaEvent = null;
            if (m_objVideoWindow != null) m_objVideoWindow = null;
            if (m_objBasicAudio != null) m_objBasicAudio = null;
            if (m_objFilterGraph != null) m_objFilterGraph = null;
        }

        

        private void UpdateStatusBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None: labelStatus.Text = "Stopped"; break;
                case MediaStatus.Paused: labelStatus.Text = "Paused "; break;
                case MediaStatus.Running: labelStatus.Text = "Running"; break;
                case MediaStatus.Stopped: labelStatus.Text = "Stopped"; break;
                case MediaStatus.End: labelStatus.Text = "End"; break;
                default: Console.WriteLine("Probabile errore nell'updateStatus");
                    labelStatus.Text = "";
                    
                    string err = "Probabile errore nell'updateStatusBar";
                    
                    break;
            }

            if (m_objMediaPosition != null)
            {
                int s = (int)m_objMediaPosition.Duration;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                this.labelOrario.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

                s = (int)m_objMediaPosition.CurrentPosition;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                this.labelOrario2.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                this.labelOrario.Text = "00:00:00";
                this.labelOrario2.Text = "00:00:00";
            }
        }

       protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_GRAPHNOTIFY)
            {
                int lEventCode;
                int lParam1, lParam2;

                while (true)
                {
                    try
                    {
                        m_objMediaEventEx.GetEvent(out lEventCode,
                            out lParam1,
                            out lParam2,
                            0);

                        m_objMediaEventEx.FreeEventParams(lEventCode, lParam1, lParam2);

                        if (lEventCode == EC_COMPLETE)
                        {
                            m_objMediaControl.Stop();
                            m_objMediaPosition.CurrentPosition = 0;
                            m_CurrentStatus = MediaStatus.End;
                            
                            UpdateStatusBar();
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            base.WndProc(ref m);
        }

        

        private void buttonSalvaConsole_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            
            
        }

        private void buttonStoricoContenuti_Click(object sender, EventArgs e)
        {

            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.xml";
            saveFile1.Filter = "XML Files|*.xml";

            
        }

        private void buttonSalvaErrori_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.xml";
            saveFile1.Filter = "XML Files|*.xml";

            
        }

        

        private void buttonAttiva_Click(object sender, EventArgs e)
        {
            
            attivo = true;
            
            
        }

        private void buttonEsc_Click(object sender, EventArgs e)
        {
            //devo bloccare anche i timer, e l'eventuale esecuzione del file multimediale
            DialogResult dr = new DialogResult();
            string commento = "";
            if (attivo == true)
                commento = "Il sistema è ancora attivo, l'uscita dal programma\n determinerà la disattivazione forzata";
            else
                commento = "";

            dr = MessageBox.Show(commento + "\n\tSei sicuro di voler uscire?", "Chiusura Finestra",
             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);

            if (dr == DialogResult.Yes)
            {
                
                //MessageBox.Show("Bisogna fare il codice per salvataggio file storico!!!", "ATTENZIONE",
                //MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                /*
                 * Codice per salvare....
                 * */
               
                
                this.Close();
            }
            else
            {
                Console.Write("Si è scelto di rimanere nella formEsecuzione");
            }

        }

        private void buttonDisattiva_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            if (m_CurrentStatus == MediaStatus.Running || m_CurrentStatus == MediaStatus.Paused)
            {

                dr = MessageBox.Show("Risorsa in esecuzione.\n\tSei sicuro di voler disattivare?", "Disattivazione sistema",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);

                if (dr == DialogResult.Yes)
                {
                    attivo = false;

                    //UpdateStatusBar();
                    if (m_objMediaControl != null)
                    {
                        Console.WriteLine("Disattivo sistema: stoppo il contenuto");
                        m_objMediaControl.Stop();
                        m_CurrentStatus = MediaStatus.None;
                        if (m_objMediaPosition != null)
                        {
                            m_objMediaPosition.CurrentPosition = 0;
                            this.labelOrario.Text = "00:00:00";
                            this.labelOrario2.Text = "00:00:00";
                        }
                    }



                }
                else
                {
                    Console.Write("Si è scelto di rimanere nella formEsecuzione");
                }
            }
            else // non c'è nulla in esecuzione
            {
                attivo = false;

            }  
                
        }

        

        private void FormEsecuzioneRfidPoster_Load(object sender, EventArgs e)
        {
            buttonAttiva_Click(null,null);
        }


        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        

    }
}