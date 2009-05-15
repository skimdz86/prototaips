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
            InitializeComponent();
            foreach (string comPort in SerialPort.GetPortNames()) {
                if (!(comPort.Equals("COM1")) && !(comPort.Equals("COM2")))
                {
                    comboPort.Items.Add(comPort);
                }
            }
            if (comboPort.Items.Count > 0) comboPort.SelectedIndex = 0;
            else buttonTestConnection.Enabled = false;
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            int handlerRfid;
            string[] configuration = Global.reader.getConfiguration();

            int portNum = Convert.ToInt32(((string)comboPort.SelectedItem).Substring(3, 1));
            configuration[0] = portNum.ToString();
            Global.reader.saveConfiguration(configuration);
            handlerRfid = Global.reader.connect();
            if (handlerRfid <= 0)
            {
                this.labelNO.Visible = true;
                this.labelNO2.Visible = true;
                
            }
            else
            {
                this.labelOK.Visible = true;
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            NavigationControl.goHome(this);
        }

        private void salva_Click(object sender, EventArgs e)
        {
            NavigationControl.goWelcome(this);
        }

    }
}