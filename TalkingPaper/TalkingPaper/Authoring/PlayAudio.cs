using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using QuartzTypeLib;

namespace TalkingPaper.Authoring
{
    public partial class PlayAudio:Form
    {
        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        private FilgraphManager m_objFilterGraph = null;
        private IBasicAudio m_objBasicAudio = null;
        private IVideoWindow m_objVideoWindow = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;
        private System.Windows.Forms.MenuItem menuItem5;
        private string file;
        //private ComponentiDelPoster elenco_componenti;
        private AggiungiComponenteForm componente_nuovo;
        //private EccoLaStoria la_storia;
        ///private TalkingPaper.BarCode.FormVisualizzaElementi visualizza_elementi;
        //private TalkingPaper.RfidCode.FormVisualizzaElementiRFID visualizza_elementi_rfid;
        private TalkingPaper.Authoring.PosizionaComponentiForm visualizza_elementi_rfid;
        private string path;

        enum MediaStatus { None, Stopped, Paused, Running };

        private MediaStatus m_CurrentStatus = MediaStatus.None;


        public PlayAudio(string path, AggiungiComponenteForm componente_nuovo, /*ComponentiDelPoster elenco_componenti,BarCode.FormVisualizzaElementi visualizza_elementi, EccoLaStoria la_storia,*/Authoring.PosizionaComponentiForm visualizza_elementi_rfid)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 50, true);
            //this.nome_file = nome_file;
            this.path = path;
            this.componente_nuovo = componente_nuovo;
            //this.elenco_componenti = elenco_componenti;
            ///this.visualizza_elementi = visualizza_elementi;
            this.visualizza_elementi_rfid = visualizza_elementi_rfid;
            //this.la_storia = la_storia;
            UpdateStatusBar();
            UpdateToolBar();
            int indice = path.LastIndexOf("\\");
            int lenght = path.Length - (indice + 1);
            this.file = path.Substring(indice + 1, lenght);
            m_objFilterGraph = new FilgraphManager();
            //string file = "D:\\Documents and Settings\\IO\\Documenti\\Musica\\Io Carlo - Lego.mp3";
            //string destinazione= "D:\\Documents and Settings\\IO\\Documenti\\Visual Studio 2005\\ProvaMySql\\TalkingPaper\\TalkingPaper\\audio\\";
            m_objFilterGraph.RenderFile(path);
            //MessageBox.Show(openFileDialog.FileName);
            //System.IO.File.Copy(file,destinazione+"Audio4.mp3");
            //MessageBox.Show("File copiato");

            m_objMediaEvent = m_objFilterGraph as IMediaEvent;

            m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
            m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);

            m_objMediaPosition = m_objFilterGraph as IMediaPosition;

            m_objMediaControl = m_objFilterGraph as IMediaControl;

            this.Text = "DirectShow - [" + file + "]";

            m_objMediaControl.Run();
            m_CurrentStatus = MediaStatus.Running;

            UpdateStatusBar();
            UpdateToolBar();
        }

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

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0: m_objMediaControl.Run();
                    m_CurrentStatus = MediaStatus.Running;
                    break;

                case 1: m_objMediaControl.Pause();
                    m_CurrentStatus = MediaStatus.Paused;
                    break;

                case 2: m_objMediaControl.Stop();
                    m_objMediaPosition.CurrentPosition = 0;
                    m_CurrentStatus = MediaStatus.Stopped;
                    break;

                case 3: m_objMediaControl.Stop();
                    m_objMediaPosition.CurrentPosition = 0;
                    m_CurrentStatus = MediaStatus.Stopped;
                    /*if (elenco_componenti != null)
                    {
                        elenco_componenti.Enabled = true;
                    }
                    else*/ if (componente_nuovo != null)
                    {
                        componente_nuovo.Enabled = true;
                    }
                    /*else if (visualizza_elementi != null)
                    {
                        visualizza_elementi.Enabled = true;
                    }*/
                    /*else if (la_storia != null)
                    {
                        la_storia.Enabled = true;
                    }*/
                    else if (visualizza_elementi_rfid != null)
                    {
                        visualizza_elementi_rfid.Enabled = true;
                    }
                    this.Close();
                    break;
            }
            this.Cursor = Cursors.Default;
            UpdateStatusBar();
            UpdateToolBar();
            //this.Cursor = Cursors.WaitCursor;
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
                            m_CurrentStatus = MediaStatus.Stopped;
                            UpdateStatusBar();
                            UpdateToolBar();
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

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (m_CurrentStatus == MediaStatus.Running)
            {
                UpdateStatusBar();
            }
        }

        private void UpdateStatusBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None: statusBarPanel1.Text = "Stopped"; break;
                case MediaStatus.Paused: statusBarPanel1.Text = "Paused "; break;
                case MediaStatus.Running: statusBarPanel1.Text = "Running"; break;
                case MediaStatus.Stopped: statusBarPanel1.Text = "Stopped"; break;
            }

            if (m_objMediaPosition != null)
            {
                int s = (int)m_objMediaPosition.Duration;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                statusBarPanel2.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

                s = (int)m_objMediaPosition.CurrentPosition;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);

                statusBarPanel3.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                statusBarPanel2.Text = "00:00:00";
                statusBarPanel3.Text = "00:00:00";
            }
        }

        private void UpdateToolBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None: toolBarButton1.Enabled = false;
                    toolBarButton2.Enabled = false;
                    toolBarButton3.Enabled = false;
                    break;

                case MediaStatus.Paused: toolBarButton1.Enabled = true;
                    toolBarButton2.Enabled = false;
                    toolBarButton3.Enabled = true;
                    break;

                case MediaStatus.Running: toolBarButton1.Enabled = false;
                    toolBarButton2.Enabled = true;
                    toolBarButton3.Enabled = true;
                    break;

                case MediaStatus.Stopped: toolBarButton1.Enabled = true;
                    toolBarButton2.Enabled = false;
                    toolBarButton3.Enabled = false;
                    break;
            }
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
          //  Form2 dlg = new Form2();
          //  dlg.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void PlayAudio_Load(object sender, EventArgs e)
        {

        }
    }
}