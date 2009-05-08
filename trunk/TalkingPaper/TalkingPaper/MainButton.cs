using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper
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
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);

            this.UseVisualStyleBackColor = false;
            this.ResumeLayout(false);
            base.OnCreateControl();
        }
    }
}