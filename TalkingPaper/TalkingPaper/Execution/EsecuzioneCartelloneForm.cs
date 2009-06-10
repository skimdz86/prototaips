using System;
using QuartzTypeLib;
using TalkingPaper.Common;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;


namespace TalkingPaper.Execution
{
    public partial class EsecuzioneCartelloneForm : FormSchema
    {
        
        private ControlLogic.ExecutionControl control;
        private String poster1;
        private Model.Contenuto contenuto;
        
        Timer updateTimer;
        FormVideo formVideo;

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

        private Model.Griglia griglia;
        private List<Model.Contenuto> listaContenuti;
        private Model.Contenuto[,] matrix;

        public EsecuzioneCartelloneForm(string nomePoster)
        {
            try
            {
                InitializeComponent();

                control = new ControlLogic.ExecutionControl();
                
                poster1 = nomePoster;
                sottotitolo.Text += " " + poster1;

                if (Global.isEmpty(poster1))
                {
                    throw new Exception("Errore!! Il poster non esiste!!");
                }

                /*Inizializzazione della griglia in grafica*/
                Model.Poster p1 = control.getPoster(nomePoster);
                griglia = control.getGriglia(p1.getNomeGriglia());

                disegnaGriglia();
                listaContenuti = new List<Model.Contenuto>();
                matrix = new Model.Contenuto[griglia.getNumRighe() + 1, griglia.getNumColonne() + 1];

                Model.Poster poster = Global.dataHandler.getPoster(nomePoster);

                if ((poster != null) && (poster.getNome() != null))
                {
                    List<Model.Contenuto> contenuti = poster.getContenuti();
                    if (contenuti != null)
                    {
                        foreach (Model.Contenuto contenuto in contenuti)
                        {
                            int[] coord = contenuto.getCoordinate();
                            if (coord != null)
                            {
                                matrix[coord[0], coord[1]] = contenuto;
                                if (!(contenuto.getNomeContenuto().Equals("Play")) && !(contenuto.getNomeContenuto().Equals("Pausa")) && !(contenuto.getNomeContenuto().Equals("Stop")))
                                    listaContenuti.Add(contenuto);
                            }
                        }

                    }

                }
                riempiGriglia();
                /*fine parte griglia*/

                control.inizializzaReader(this);

                updateTimer = new Timer();
                updateTimer.Tick += UpdateStatusBar;
                updateTimer.Interval = 1000;

                

                CleanUp();
                

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Metodo per la rappresentazione della griglia vuota
        /// </summary>
        private void disegnaGriglia()
        {
            try
            {
                schemaGriglia.Rows.Clear();
                schemaGriglia.Columns.Clear();

                schemaGriglia.ColumnCount = griglia.getNumColonne() + 1;
                schemaGriglia.Rows.Add(griglia.getNumRighe() + 1);

                schemaGriglia.Rows[0].Height = 35;
                schemaGriglia.Columns[0].Width = 50;

                schemaGriglia[0, 0].Style.BackColor = Color.ForestGreen;
                schemaGriglia[0, 0].Style.SelectionBackColor = Color.ForestGreen;

                Font font = new Font("Arial", 16);

                //header righe
                for (int i = 1; i <= griglia.getNumRighe(); i++)
                {
                    schemaGriglia[0, i].Value = i;
                    schemaGriglia[0, i].Style.Font = font;
                    schemaGriglia[0, i].Style.BackColor = Color.ForestGreen;
                    schemaGriglia[0, i].Style.SelectionBackColor = Color.ForestGreen;
                }

                //header colonne
                for (int j = 1; j <= griglia.getNumColonne(); j++)
                {
                    schemaGriglia.Columns[j].Width = 120;
                    schemaGriglia[j, 0].Value = (char)('A' + j - 1);
                    schemaGriglia[j, 0].Style.Font = font;
                    schemaGriglia[j, 0].Style.BackColor = Color.ForestGreen;
                    schemaGriglia[j, 0].Style.SelectionBackColor = Color.ForestGreen;
                }

                //singole celle
                font = new Font("Arial", 12);
                for (int i = 0; i < (griglia.getNumRighe() * griglia.getNumColonne()); i++)
                {
                    int c = (i % griglia.getNumColonne()) + 1;
                    int r = (i / griglia.getNumColonne()) + 1;

                    //celle valide
                    if (Global.isNotEmpty(griglia.getTagFromIndex(i)))
                    {
                        schemaGriglia[c, r].Style.Font = font;
                        schemaGriglia[c, r].Style.BackColor = Color.White;
                        schemaGriglia[c, r].Style.ForeColor = Color.Black;
                        schemaGriglia[c, r].Style.SelectionBackColor = Color.PowderBlue;
                        schemaGriglia[c, r].Style.SelectionForeColor = Color.Black;
                    }
                    //celle non valide (no tag)
                    else
                    {
                        schemaGriglia[c, r].Style.BackColor = Color.Gray;
                        schemaGriglia[c, r].Style.SelectionBackColor = Color.Gray;
                    }
                }

            }
            catch (Exception e) { MessageBox.Show(e.Message); }

        }

        /// <summary>
        /// Metodo per riempire la griglia con tutti i contenuti finora inseriti
        /// </summary>
        private void riempiGriglia()
        {

            for (int i = 1; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 1; j <= matrix.GetUpperBound(1); j++)
                {
                    if ((matrix[i, j] != null) && (matrix[i, j].getNomeContenuto() != null))
                        schemaGriglia[j, i].Value = matrix[i, j].getNomeContenuto();
                    else
                        schemaGriglia[j, i].Value = null;
                }
            }
        }


        /// <summary>
        /// Metodo per la gestione della lettura del tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rfid_StatusUpdateEvent(string id)
        {
            try
            {
                //verifico di non aver letto lo stesso tag in breve tempo
                if (control.verificaId(id))
                {
                    contenuto = control.getContenutoFromTag(poster1, id);
                    if (contenuto == null)
                    {
                        Console.WriteLine("Al tag " + id + " non corrisponde un contenuto");
                    }
                    else
                    {
                        //stabilisco il tipo di contenuto associato al tag ed eseguo l'azione corrispondente
                        if (contenuto.getNomeContenuto().Equals("Play"))
                        {
                            if (m_CurrentStatus == MediaStatus.Paused || m_CurrentStatus == MediaStatus.Stopped)
                            {
                                m_objMediaControl.Run();
                                m_CurrentStatus = MediaStatus.Running;
                                stato.Text = "In Esecuzione";
                                updateTimer.Start();
                                if ((formVideo != null) && (formVideo.Visible == false))
                                {
                                    formVideo.Visible = true;

                                }
                            }
                        }
                        else if (contenuto.getNomeContenuto().Equals("Pausa"))
                        {
                            if (m_CurrentStatus == MediaStatus.Running)
                            {
                                m_objMediaControl.Pause();
                                m_CurrentStatus = MediaStatus.Paused;
                                stato.Text = "In Pausa";
                                updateTimer.Stop();
                                if ((formVideo != null) && (formVideo.Visible == false))
                                {
                                    formVideo.Visible = true;

                                }
                            }
                        }
                        else if (contenuto.getNomeContenuto().Equals("Stop"))
                        {
                            if (m_CurrentStatus == MediaStatus.Running || m_CurrentStatus == MediaStatus.Paused)
                            {
                                m_objMediaControl.Stop();
                                m_objMediaPosition.CurrentPosition = 0;
                                m_CurrentStatus = MediaStatus.Stopped;
                                stato.Text = "Interrotto";
                                updateTimer.Stop();
                                if ((formVideo != null) && (formVideo.Visible == true))
                                {
                                    formVideo.Visible = false;

                                }


                            }
                        }
                        else if (Global.isNotEmpty(contenuto.getVideoPath()))
                        {
                            if (File.Exists(contenuto.getVideoPath()))
                            {

                                CleanUp();
                                m_objFilterGraph = new FilgraphManager();
                                m_objFilterGraph.RenderFile(contenuto.getVideoPath());
                                try
                                {
                                    formVideo = new FormVideo();
                                    m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                                    m_objVideoWindow.Owner = (int)formVideo.Handle;
                                    m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                                    m_objVideoWindow.SetWindowPosition(formVideo.ClientRectangle.Left,
                                    formVideo.ClientRectangle.Top,
                                    formVideo.ClientRectangle.Width,
                                    formVideo.ClientRectangle.Height);


                                    m_objMediaEvent = m_objFilterGraph as IMediaEvent;

                                    m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
                                    m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);

                                    m_objMediaPosition = m_objFilterGraph as IMediaPosition;

                                    m_objMediaControl = m_objFilterGraph as IMediaControl;

                                    m_objMediaControl.Run();
                                    m_CurrentStatus = MediaStatus.Running;


                                    updateTimer.Start();

                                    labelEsecuzioneDi.Visible = true;
                                    nomeContenuto.Text = contenuto.getNomeContenuto();
                                    nomeContenuto.Visible = true;
                                    labelStato.Visible = true;
                                    stato.Visible = true;
                                    tempoTotale.Visible = true;
                                    tempoTrascorso.Visible = true;
                                    labelSu.Visible = true;

                                    formVideo.Show();
                                }
                                catch (Exception)
                                {
                                    m_objVideoWindow = null;
                                }

                            }
                            else MessageBox.Show("Non esiste più il contenuto" + contenuto.getNomeContenuto() + "!! Aggiornare il cartellone");
                        }
                        else if (Global.isNotEmpty(contenuto.getAudioPath()))
                        {
                            if (File.Exists(contenuto.getAudioPath()))
                            {

                                CleanUp();
                                m_objFilterGraph = new FilgraphManager();
                                m_objFilterGraph.RenderFile(contenuto.getAudioPath());

                                m_objBasicAudio = m_objFilterGraph as IBasicAudio;



                                m_objMediaEvent = m_objFilterGraph as IMediaEvent;

                                m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
                                m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);

                                m_objMediaPosition = m_objFilterGraph as IMediaPosition;

                                m_objMediaControl = m_objFilterGraph as IMediaControl;

                                m_objMediaControl.Run();
                                m_CurrentStatus = MediaStatus.Running;
                                updateTimer.Start();


                                labelEsecuzioneDi.Visible = true;
                                nomeContenuto.Text = contenuto.getNomeContenuto();
                                nomeContenuto.Visible = true;
                                labelStato.Visible = true;
                                stato.Visible = true;
                                tempoTotale.Visible = true;
                                tempoTrascorso.Visible = true;
                                labelSu.Visible = true;
                            }
                            else MessageBox.Show("Non esiste più il contenuto" + contenuto.getNomeContenuto() + "!! Aggiornare il cartellone");
                        }
                        else throw new Exception("Il contenuto " + contenuto.getNomeContenuto() + " è malformato");

                        UpdateStatusBar(null, null);
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Metodo per resettare gli indicatori di avanzamento dell'esecuzione
        /// </summary>
        private void CleanUp()
        {
            if (m_objMediaControl != null)
                m_objMediaControl.Stop();

            m_CurrentStatus = MediaStatus.None;

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

        /// <summary>
        /// Metodo per aggiornare gli indicatori di avanzamento dell'esecuzione
        /// </summary>
        private void UpdateStatusBar(object sender, EventArgs e)
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None:
                    {
                        stato.Text = "Interrotto";
                        messaggioStart.Visible = true;
                        verificaLabel.Visible = false;
                        break;
                    }
                case MediaStatus.Paused:
                    {
                        stato.Text = "In Pausa";
                        messaggioStart.Visible = true;
                        verificaLabel.Visible = false;
                        break;
                    }
                case MediaStatus.Running:
                    {
                        stato.Text = "In Esecuzione";
                        messaggioStart.Visible = false;
                        verificaLabel.Visible = false;
                        break;
                    }
                case MediaStatus.Stopped:
                    {
                        stato.Text = "Interrotto";
                        messaggioStart.Visible = true;
                        verificaLabel.Visible = false;
                        break;
                    }
                case MediaStatus.End:
                    {
                        stato.Text = "Terminato";
                        messaggioStart.Visible = true;
                        verificaLabel.Visible = false;
                        break;
                    }
                default:
                    {
                        stato.Text = "";
                        messaggioStart.Visible = true;
                        verificaLabel.Visible = true;
                        break;
                    }
            }

            if (m_objMediaPosition != null)
            {
                int s = (int)m_objMediaPosition.Duration;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                this.tempoTotale.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

                s = (int)m_objMediaPosition.CurrentPosition;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                this.tempoTrascorso.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                this.tempoTotale.Text = "00:00:00";
                this.tempoTrascorso.Text = "00:00:00";
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

                            UpdateStatusBar(null, null);
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

        private void home_Click(object sender, EventArgs e)
        {
            try
            {
                //controllo se sto eseguendo un contenuto
                if (m_CurrentStatus == MediaStatus.Running || m_CurrentStatus == MediaStatus.Paused)
                {
                    QuestionSchema dialog = new QuestionSchema("Un contenuto è in esecuzione.\nSei sicuro di voler uscire?", this, "1");
                    NavigationControl.showDialog(dialog);
                }
                else
                {
                    CleanUp();
                    UpdateStatusBar(null, null);
                    control.stopReader();
                    updateTimer.Stop();
                    NavigationControl.goHome(this);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Metodo eseguito in seguito alla risposta ad una dialog che chiede se si vuole
        /// interrompere l'esecuzione di un contenuto ed uscire dall'esecuzione del cartellone
        /// </summary>
        /// <param name="param"></param>
        /// <param name="response"></param>
        public void questionAnswer(string param,string response)
        {
            try
            {
                if ((param != null) && (param.Equals("1")))
                {
                    if ((response != null) && (response.Equals("yes")))
                    {
                        CleanUp();
                        UpdateStatusBar(null, null);
                        control.stopReader();
                        updateTimer.Stop();
                        NavigationControl.goHome(this);
                    }
                }

                else if ((param != null) && (param.Equals("2")))
                {
                    if ((response != null) && (response.Equals("yes")))
                    {
                        CleanUp();
                        UpdateStatusBar(null, null);
                        control.stopReader();
                        updateTimer.Stop();
                        NavigationControl.goBack(this);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Attenzione: per essere sicuro che il lettore funzioni, controlla che lampeggi la luce rossa. \n");
            NavigationControl.showDialog(helpForm);
        }

        private void annulla1_Click(object sender, EventArgs e)
        {
            try
            {
                //controllo se sto eseguendo un contenuto
                if (m_CurrentStatus == MediaStatus.Running || m_CurrentStatus == MediaStatus.Paused)
                {
                    QuestionSchema dialog = new QuestionSchema("Un contenuto è in esecuzione.\nSei sicuro di voler tornare indietro?", this, "2");
                    NavigationControl.showDialog(dialog);
                }
                else
                {
                    CleanUp();
                    UpdateStatusBar(null, null);
                    control.stopReader();
                    updateTimer.Stop();
                    NavigationControl.goBack(this);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        

    }
}