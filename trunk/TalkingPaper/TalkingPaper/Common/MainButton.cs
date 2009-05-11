using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Common
{
    public partial class MainButton : Button
    {
        public MainButton()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            this.BackColor = System.Drawing.Color.Yellow;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            
            this.UseVisualStyleBackColor = false;
            this.ResumeLayout(false);
            base.OnCreateControl();
        }
    }
}