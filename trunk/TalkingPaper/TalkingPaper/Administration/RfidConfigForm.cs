using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TalkingPaper.Common;
using System.IO.Ports;

namespace TalkingPaper.Administration
{
    public partial class RfidConfigForm : FormSchema
    {
                
        public RfidConfigForm()
        {
            try
            {
                InitializeComponent();
                foreach (string comPort in SerialPort.GetPortNames())
                {
                    /*Escludo dal controllo le porte COM1 e COM2 che non sono utilizzabili dal lettore*/
                    if (!(comPort.Equals("COM1")) && !(comPort.Equals("COM2")))
                    {
                        comboPort.Items.Add(comPort);
                    }
                }
                if (comboPort.Items.Count > 0) comboPort.SelectedIndex = 0;
                else buttonTestConnection.Enabled = false;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                int handlerRfid;
                string[] configuration = Global.reader.getConfiguration();

                int portNum = Convert.ToInt32(((string)comboPort.SelectedItem).Substring(3, 1));
                configuration[0] = portNum.ToString();
                Global.reader.close();
                Global.reader.saveConfiguration(configuration);
                handlerRfid = Global.reader.connect();
                if (handlerRfid <= 0)
                {
                    this.labelNO.Visible = true;
                    this.labelNO2.Visible = true;

                }
                else
                {
                    Global.reader.readerStatusUpdate += new TalkingPaper.Reader.ReaderDelegate(prova_lettura);
                    Global.reader.startRead();//serve a far lampeggiare il lettore per capire se è configurato
                    this.labelOK.Visible = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Eì il delegate che permette di avviare il test sul lettore
        /// </summary>
        /// <param name="value"></param>
        void prova_lettura(string value)
        {
            
        }

        private void home_Click(object sender, EventArgs e)
        {
            Global.reader.close();
            NavigationControl.goHome(this);
        }

        private void salva_Click(object sender, EventArgs e)
        {
            Global.reader.close();
            NavigationControl.goHome(this);
        }

        private void help_Click(object sender, EventArgs e)
        {
            HelpFormSchema helpForm = new HelpFormSchema("Per controllare che il lettore RFID sia configurato a dovere, è sufficiente controllare che la luce rossa posta su di esso lampeggi. \nSuggerimento: spesso il lettore RFID è associato alla porta con numero più alto, quindi è consigliabile selezionare prima quello per provare la connessione");
            NavigationControl.showDialog(helpForm);
        }

    }
}