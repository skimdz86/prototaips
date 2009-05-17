using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TalkingPaper.Common;

namespace TalkingPaper.Common
{
    public partial class HelpFormSchema : Form
    {

        public HelpFormSchema(String helpMessage)
        {
            InitializeComponent();
            helpBox.Text = helpMessage;
            
        }

        private void annulla_Click(object sender, EventArgs e)
        {
            NavigationControl.closeDialog(this);
        }
    }
}