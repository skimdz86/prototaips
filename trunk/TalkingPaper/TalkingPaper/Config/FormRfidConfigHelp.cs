using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Config
{
    public partial class FormRfidConfigHelp : Common.FormSchema
    {
        private RfidConfigForm config;
        
        public FormRfidConfigHelp(RfidConfigForm config)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 75, true);
            this.config = config;
            
        }

        private void BtnChiusura_Click(object sender, EventArgs e)
        {   
            config.Visible = true;
            this.Close();
        }

        private void FormRfidConfigHelp_Load(object sender, EventArgs e)
        {

        }

    }
}