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
        private string poster;
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
        

        public EsecuzioneCartelloneForm(string nomePoster)
        {
            try
            {
                InitializeComponent();

                control = new ControlLogic.ExecutionControl();

                poster = nomePoster;
                sottotitolo.Text += " " + poster;

                if (Global.isEmpty(poster))
                {
                    throw new Exception("Errore!! Esecuzione di un poster inesistente");
                }

                control.inizializzaReader(this);

                updateTimer = new Timer();
                updateTimer.Tick += UpdateStatusBar;
                updateTimer.Interval = 1000;

                

                CleanUp();
                UpdateStatusBar(null, null);

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }


        /// <summary>
        /// metodo per la gestione della lettura del tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rfid_StatusUpdateEvent(string id)
        {
            try
            {
                if (control.verificaId(id))
                {
                    contenuto = control.getContenutoFromTag(poster, id);
                    if (contenuto == null)
                    {
                        Console.WriteLine("Al tag " + id + " non corrisponde un contenuto");
                    }
                    else
                    {
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

                                //m_objBasicAudio = m_objFilterGraph as IBasicAudio;

                                try
                                {
                                    formVideo = new FormVideo();
                                    m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                                    m_objVideoWindow.Owner = (int)formVideo.Handle;
                                    m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                                    //m_objVideoWindow.FullScreenMode = 1;
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

        

        private void UpdateStatusBar(object sender, EventArgs e)
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None:
                    {
                        stato.Text = "Interrotto";
                        messaggioStart.Visible = true;
                        break;
                    }
                case MediaStatus.Paused:
                    {
                        stato.Text = "In Pausa";
                        messaggioStart.Visible = true;
                        break;
                    }
                case MediaStatus.Running:
                    {
                        stato.Text = "In Esecuzione";
                        messaggioStart.Visible = false;
                        break;
                    }
                case MediaStatus.Stopped:
                    {
                        stato.Text = "Interrotto";
                        messaggioStart.Visible = true;
                        break;
                    }
                case MediaStatus.End:
                    {
                        stato.Text = "Terminato";
                        messaggioStart.Visible = true;
                        break;
                    }
                default:
                    {
                        stato.Text = "";
                        messaggioStart.Visible = true;
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

        

        
        
        

        private void buttonAttiva_Click(object sender, EventArgs e)
        {
            
            
            esecuzioneDisattivata.Visible = false;

            messaggioStart.Visible = true;
            labelEsecuzioneDi.Visible = false;
            nomeContenuto.Visible = false;
            labelStato.Visible = false;
            stato.Visible = false;
            tempoTotale.Visible = false;
            tempoTrascorso.Visible = false;
            labelSu.Visible = false;
            buttonAttiva.Enabled = false;
            buttonDisattiva.Enabled = true;
            control.inizializzaReader(this);
            
            
        }

        private void buttonDisattiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_CurrentStatus == MediaStatus.Running || m_CurrentStatus == MediaStatus.Paused)
                {
                    QuestionSchema dialog = new QuestionSchema("Un contenuto è in esecuzione.\nSei sicuro di voler disattivare?", this, "2");
                    NavigationControl.showDialog(dialog);

                }
                else // non c'è nulla in esecuzione
                {
                    

                    CleanUp();
                    UpdateStatusBar(null, null);
                    control.stopReader();
                    updateTimer.Stop();

                    esecuzioneDisattivata.Visible = true;

                    messaggioStart.Visible = false;
                    labelEsecuzioneDi.Visible = false;
                    nomeContenuto.Visible = false;
                    labelStato.Visible = false;
                    stato.Visible = false;
                    tempoTotale.Visible = false;
                    tempoTrascorso.Visible = false;
                    labelSu.Visible = false;
                    buttonDisattiva.Enabled = false;
                    buttonAttiva.Enabled = true;

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void home_Click(object sender, EventArgs e)
        {
            try
            {
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
                    esecuzioneDisattivata.Visible = true;
                    updateTimer.Stop();
                    NavigationControl.goHome(this);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

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
                        esecuzioneDisattivata.Visible = true;
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
                        esecuzioneDisattivata.Visible = true;
                        updateTimer.Stop();

                        messaggioStart.Visible = false;
                        labelEsecuzioneDi.Visible = false;
                        nomeContenuto.Visible = false;
                        labelStato.Visible = false;
                        stato.Visible = false;
                        tempoTotale.Visible = false;
                        labelSu.Visible = false;
                        tempoTrascorso.Visible = false;

                        buttonDisattiva.Enabled = false;
                        buttonAttiva.Enabled = true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        

    }
}