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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxGriglia = new System.Windows.Forms.GroupBox();
            this.modificaGriglia = new System.Windows.Forms.Button();
            this.EliminaPoster = new System.Windows.Forms.Button();
            this.benvenuto = new System.Windows.Forms.Label();
            this.groupBoxRfid = new System.Windows.Forms.GroupBox();
            this.configRfid = new System.Windows.Forms.Button();
            this.groupBoxPoster = new System.Windows.Forms.GroupBox();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.groupBoxGriglia.SuspendLayout();
            this.groupBoxRfid.SuspendLayout();
            this.groupBoxPoster.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(248, 33);
            this.sottotitolo.Text = "Amministrazione";
            // 
            // home
            // 
            this.home.Text = "Logout";
            this.home.Click += new System.EventHandler(this.logout_Click);
            // 
            // annulla
            // 
            this.annulla.Visible = false;
            // 
            // ok
            // 
            this.ok.Visible = false;
            // 
            // boxSotto
            // 
            this.boxSotto.Visible = false;
            // 
            // nuovaGriglia
            // 
            this.nuovaGriglia.BackColor = System.Drawing.Color.Yellow;
            this.nuovaGriglia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nuovaGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuovaGriglia.Location = new System.Drawing.Point(67, 49);
            this.nuovaGriglia.Name = "nuovaGriglia";
            this.nuovaGriglia.Size = new System.Drawing.Size(202, 109);
            this.nuovaGriglia.TabIndex = 4;
            this.nuovaGriglia.Text = "Nuova Griglia";
            this.nuovaGriglia.UseVisualStyleBackColor = false;
            this.nuovaGriglia.Click += new System.EventHandler(this.nuovaGriglia_Click);
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
            // groupBoxGriglia
            // 
            this.groupBoxGriglia.BackColor = System.Drawing.Color.Orange;
            this.groupBoxGriglia.Controls.Add(this.modificaGriglia);
            this.groupBoxGriglia.Controls.Add(this.nuovaGriglia);
            this.groupBoxGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGriglia.Location = new System.Drawing.Point(173, 210);
            this.groupBoxGriglia.Name = "groupBoxGriglia";
            this.groupBoxGriglia.Size = new System.Drawing.Size(679, 203);
            this.groupBoxGriglia.TabIndex = 30;
            this.groupBoxGriglia.TabStop = false;
            // 
            // modificaGriglia
            // 
            this.modificaGriglia.BackColor = System.Drawing.Color.Yellow;
            this.modificaGriglia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modificaGriglia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificaGriglia.Location = new System.Drawing.Point(422, 49);
            this.modificaGriglia.Name = "modificaGriglia";
            this.modificaGriglia.Size = new System.Drawing.Size(202, 109);
            this.modificaGriglia.TabIndex = 5;
            this.modificaGriglia.Text = "Modifica Griglia";
            this.modificaGriglia.UseVisualStyleBackColor = false;
            this.modificaGriglia.Click += new System.EventHandler(this.modificaGriglia_Click);
            // 
            // EliminaPoster
            // 
            this.EliminaPoster.BackColor = System.Drawing.Color.Yellow;
            this.EliminaPoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminaPoster.Location = new System.Drawing.Point(67, 37);
            this.EliminaPoster.Name = "EliminaPoster";
            this.EliminaPoster.Size = new System.Drawing.Size(202, 109);
            this.EliminaPoster.TabIndex = 7;
            this.EliminaPoster.Text = "Elimina Poster";
            this.EliminaPoster.UseVisualStyleBackColor = false;
            this.EliminaPoster.Click += new System.EventHandler(this.EliminaPoster_Click);
            // 
            // benvenuto
            // 
            this.benvenuto.AutoSize = true;
            this.benvenuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benvenuto.ForeColor = System.Drawing.Color.White;
            this.benvenuto.Location = new System.Drawing.Point(435, 130);
            this.benvenuto.Name = "benvenuto";
            this.benvenuto.Size = new System.Drawing.Size(161, 32);
            this.benvenuto.TabIndex = 33;
            this.benvenuto.Text = "Benvenuto";
            // 
            // groupBoxRfid
            // 
            this.groupBoxRfid.BackColor = System.Drawing.Color.Orange;
            this.groupBoxRfid.Controls.Add(this.configRfid);
            this.groupBoxRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRfid.Location = new System.Drawing.Point(537, 458);
            this.groupBoxRfid.Name = "groupBoxRfid";
            this.groupBoxRfid.Size = new System.Drawing.Size(315, 177);
            this.groupBoxRfid.TabIndex = 31;
            this.groupBoxRfid.TabStop = false;
            this.groupBoxRfid.Visible = false;
            // 
            // configRfid
            // 
            this.configRfid.BackColor = System.Drawing.Color.Yellow;
            this.configRfid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configRfid.Location = new System.Drawing.Point(58, 37);
            this.configRfid.Name = "configRfid";
            this.configRfid.Size = new System.Drawing.Size(202, 109);
            this.configRfid.TabIndex = 4;
            this.configRfid.Text = "Configura lettore Rfid";
            this.configRfid.UseVisualStyleBackColor = false;
            this.configRfid.Visible = false;
            this.configRfid.Click += new System.EventHandler(this.configRfid_Click);
            // 
            // groupBoxPoster
            // 
            this.groupBoxPoster.BackColor = System.Drawing.Color.Orange;
            this.groupBoxPoster.Controls.Add(this.EliminaPoster);
            this.groupBoxPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPoster.Location = new System.Drawing.Point(173, 458);
            this.groupBoxPoster.Name = "groupBoxPoster";
            this.groupBoxPoster.Size = new System.Drawing.Size(334, 177);
            this.groupBoxPoster.TabIndex = 32;
            this.groupBoxPoster.TabStop = false;
            // 
            // AdminHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1036, 732);
            this.Controls.Add(this.groupBoxPoster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxRfid);
            this.Controls.Add(this.benvenuto);
            this.Controls.Add(this.groupBoxGriglia);
            this.Name = "AdminHomeForm";
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.groupBoxGriglia, 0);
            this.Controls.SetChildIndex(this.benvenuto, 0);
            this.Controls.SetChildIndex(this.groupBoxRfid, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBoxPoster, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.groupBoxGriglia.ResumeLayout(false);
            this.groupBoxRfid.ResumeLayout(false);
            this.groupBoxPoster.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuovaGriglia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxGriglia;
        private System.Windows.Forms.Label benvenuto;
        private System.Windows.Forms.Button EliminaPoster;
        private System.Windows.Forms.Button modificaGriglia;
        private System.Windows.Forms.GroupBox groupBoxRfid;
        private System.Windows.Forms.Button configRfid;
        private System.Windows.Forms.GroupBox groupBoxPoster;
    }
}