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
        float ResizeFactor=0;
        public MainButton()
        {
            InitializeComponent();
            
        }
        public MainButton(double ResizeFactor)
        {
            this.ResizeFactor=(float)ResizeFactor;
            InitializeComponent();

        }
        protected override void OnCreateControl()
        {
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);

            ReScale(global.percentScale);
            //this.Size = new System.Drawing.Size(226, 111);
            

            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.UseVisualStyleBackColor = false;
            this.ResumeLayout(false);
            base.OnCreateControl();
        }
        
        protected void setAlignment(bool center)
        {
            if (center == true)
                this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            else
                this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            
        }

        public void ReScale(float ResizeFactor)
        {
            this.Size = new System.Drawing.Size((int)(226 * ResizeFactor), (int)(111 * ResizeFactor));
            this.Font = new Font(this.Font.FontFamily, this.Font.Size * ResizeFactor, this.Font.Style, this.Font.Unit);
        }
    }
}