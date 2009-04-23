namespace TalkingPaper.GestioneDisposizione
{
    partial class BenvenutoGestioneDisposizione
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenvenutoGestioneDisposizione));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ModificaSingoli = new TalkingPaper.MainButton();
            this.button1 = new TalkingPaper.MainButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Fase = new System.Windows.Forms.Label();
            this.Menu = new TalkingPaper.ControlButton();
            this.NuovaConfigurazione = new TalkingPaper.MainButton();
            this.button2 = new TalkingPaper.MainButton();
            this.button3 = new TalkingPaper.MainButton();
            this.TagNuovoPannello = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gB = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gB.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Menu);
            this.grouppoControl.Location = new System.Drawing.Point(1024, 12);
            this.grouppoControl.Size = new System.Drawing.Size(148, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(243, 33);
            this.sottotitolo.Text = "Cosa vuoi fare ?";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 554);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 19;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // ModificaSingoli
            // 
            this.ModificaSingoli.BackColor = System.Drawing.Color.Yellow;
            this.ModificaSingoli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ModificaSingoli.BackgroundImage")));
            this.ModificaSingoli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ModificaSingoli.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModificaSingoli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ModificaSingoli.Location = new System.Drawing.Point(300, 16);
            this.ModificaSingoli.Name = "ModificaSingoli";
            this.ModificaSingoli.Size = new System.Drawing.Size(226, 111);
            this.ModificaSingoli.TabIndex = 45;
            this.ModificaSingoli.Text = "Modifica un Cartellone";
            this.ModificaSingoli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ModificaSingoli.UseVisualStyleBackColor = false;
            this.ModificaSingoli.Click += new System.EventHandler(this.ModificaSingoli_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(12, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 111);
            this.button1.TabIndex = 46;
            this.button1.Text = "Crea Nuovo Cartellone";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Fase
            // 
            this.Fase.AutoSize = true;
            this.Fase.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.Fase.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fase.ForeColor = System.Drawing.Color.Red;
            this.Fase.Location = new System.Drawing.Point(12, 23);
            this.Fase.Name = "Fase";
            this.Fase.Size = new System.Drawing.Size(287, 37);
            this.Fase.TabIndex = 14;
            this.Fase.Text = "Fase di Authoring";
            this.Fase.Visible = false;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.Yellow;
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Menu.Location = new System.Drawing.Point(15, 19);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(120, 62);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "Menu";
            this.Menu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Menu.UseVisualStyleBackColor = false;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // NuovaConfigurazione
            // 
            this.NuovaConfigurazione.BackColor = System.Drawing.Color.Yellow;
            this.NuovaConfigurazione.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NuovaConfigurazione.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NuovaConfigurazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.NuovaConfigurazione.Location = new System.Drawing.Point(300, 19);
            this.NuovaConfigurazione.Name = "NuovaConfigurazione";
            this.NuovaConfigurazione.Size = new System.Drawing.Size(226, 111);
            this.NuovaConfigurazione.TabIndex = 48;
            this.NuovaConfigurazione.Text = "Crea Nuovo Pattern per supporto";
            this.NuovaConfigurazione.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NuovaConfigurazione.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(6, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 111);
            this.button2.TabIndex = 47;
            this.button2.Text = "Posiziona i Contenuti";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(6, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 111);
            this.button3.TabIndex = 44;
            this.button3.Text = "Fai parlare il tuo cartellone";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // TagNuovoPannello
            // 
            this.TagNuovoPannello.BackColor = System.Drawing.Color.Yellow;
            this.TagNuovoPannello.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TagNuovoPannello.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TagNuovoPannello.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.TagNuovoPannello.Location = new System.Drawing.Point(31, 19);
            this.TagNuovoPannello.Name = "TagNuovoPannello";
            this.TagNuovoPannello.Size = new System.Drawing.Size(226, 111);
            this.TagNuovoPannello.TabIndex = 44;
            this.TagNuovoPannello.Text = "Tag di un nuovo supporto";
            this.TagNuovoPannello.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TagNuovoPannello.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ModificaSingoli);
            this.groupBox1.Location = new System.Drawing.Point(157, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 136);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Orange;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(157, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 137);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Orange;
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(932, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 134);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // gB
            // 
            this.gB.BackColor = System.Drawing.Color.Orange;
            this.gB.Controls.Add(this.TagNuovoPannello);
            this.gB.Controls.Add(this.NuovaConfigurazione);
            this.gB.Location = new System.Drawing.Point(157, 570);
            this.gB.Name = "gB";
            this.gB.Size = new System.Drawing.Size(548, 139);
            this.gB.TabIndex = 52;
            this.gB.TabStop = false;
            // 
            // BenvenutoGestioneDisposizione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1192, 739);
            this.Controls.Add(this.Fase);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gB);
            this.Controls.Add(this.groupBox2);
            this.Name = "BenvenutoGestioneDisposizione";
            this.Text = "BenvenutoPostering";
            this.Load += new System.EventHandler(this.BenvenutoPostering_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.gB, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.Fase, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Fase;
        private MainButton ModificaSingoli;
        private MainButton button1;
        private ControlButton Menu;
        private MainButton NuovaConfigurazione;
        private MainButton button2;
        private MainButton button3;
        private MainButton TagNuovoPannello;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gB;
    }
}