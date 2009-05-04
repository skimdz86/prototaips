namespace TalkingPaper.Administration
{
    partial class AdminHomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nuovaGriglia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EliminaPoster = new System.Windows.Forms.Button();
            this.modificaGriglia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuovaGriglia
            // 
            this.nuovaGriglia.BackColor = System.Drawing.Color.Yellow;
            this.nuovaGriglia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nuovaGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuovaGriglia.Location = new System.Drawing.Point(114, 37);
            this.nuovaGriglia.Name = "nuovaGriglia";
            this.nuovaGriglia.Size = new System.Drawing.Size(202, 109);
            this.nuovaGriglia.TabIndex = 4;
            this.nuovaGriglia.Text = "Nuova Griglia";
            this.nuovaGriglia.UseVisualStyleBackColor = false;
            this.nuovaGriglia.Click += new System.EventHandler(this.nuovaGriglia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 33);
            this.label2.TabIndex = 22;
            this.label2.Text = "Amministrazione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 55);
            this.label3.TabIndex = 21;
            this.label3.Text = "Cartellone Parlante";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Orange;
            this.groupBox3.Controls.Add(this.EliminaPoster);
            this.groupBox3.Controls.Add(this.modificaGriglia);
            this.groupBox3.Controls.Add(this.nuovaGriglia);
            this.groupBox3.Location = new System.Drawing.Point(278, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 490);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // EliminaPoster
            // 
            this.EliminaPoster.BackColor = System.Drawing.Color.Yellow;
            this.EliminaPoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminaPoster.Location = new System.Drawing.Point(114, 347);
            this.EliminaPoster.Name = "EliminaPoster";
            this.EliminaPoster.Size = new System.Drawing.Size(202, 109);
            this.EliminaPoster.TabIndex = 7;
            this.EliminaPoster.Text = "Elimina Poster";
            this.EliminaPoster.UseVisualStyleBackColor = false;
            this.EliminaPoster.Click += new System.EventHandler(this.EliminaPoster_Click);
            // 
            // modificaGriglia
            // 
            this.modificaGriglia.BackColor = System.Drawing.Color.Yellow;
            this.modificaGriglia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modificaGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaGriglia.Location = new System.Drawing.Point(114, 193);
            this.modificaGriglia.Name = "modificaGriglia";
            this.modificaGriglia.Size = new System.Drawing.Size(202, 109);
            this.modificaGriglia.TabIndex = 5;
            this.modificaGriglia.Text = "Modifica Griglia";
            this.modificaGriglia.UseVisualStyleBackColor = false;
            this.modificaGriglia.Click += new System.EventHandler(this.modificaGriglia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(293, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 33;
            this.label1.Text = "Benvenuto ";
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Yellow;
            this.logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.Location = new System.Drawing.Point(904, 12);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(120, 61);
            this.logout.TabIndex = 0;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // AdminHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1036, 739);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "AdminHomeForm";
            this.Text = "FormAmministrazione";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.logout, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuovaGriglia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EliminaPoster;
        private System.Windows.Forms.Button modificaGriglia;
        private System.Windows.Forms.Button logout;
    }
}