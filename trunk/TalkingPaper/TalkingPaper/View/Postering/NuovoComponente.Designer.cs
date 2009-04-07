namespace TalkingPaper.Postering
{
    partial class NuovoComponente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuovoComponente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SfogliaAudio = new TalkingPaper.ControlButton();
            this.Salva = new TalkingPaper.MainButton();
            this.Annulla = new TalkingPaper.ControlButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SfogliaVideo = new TalkingPaper.ControlButton();
            this.SfogliaImmagine = new TalkingPaper.ControlButton();
            this.SfogliaTesto = new TalkingPaper.ControlButton();
            this.EliminaAudio = new TalkingPaper.ControlButton();
            this.EliminaVideo = new TalkingPaper.ControlButton();
            this.EliminaImmagine = new TalkingPaper.ControlButton();
            this.EliminaTesto = new TalkingPaper.ControlButton();
            this.PreviewTesto = new TalkingPaper.ControlButton();
            this.PreviewImmagine = new TalkingPaper.ControlButton();
            this.PreviewVideo = new TalkingPaper.ControlButton();
            this.PreviewAudio = new TalkingPaper.ControlButton();
            this.mainButton1 = new TalkingPaper.MainButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.Annulla);
            this.grouppoControl.Location = new System.Drawing.Point(1026, 12);
            this.grouppoControl.Size = new System.Drawing.Size(146, 91);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(337, 33);
            this.sottotitolo.Text = "Inserisci il componente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(68, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Suono";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(189, 172);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 26);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(189, 240);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(394, 26);
            this.textBox2.TabIndex = 5;
            // 
            // SfogliaAudio
            // 
            this.SfogliaAudio.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaAudio.Location = new System.Drawing.Point(602, 219);
            this.SfogliaAudio.Name = "SfogliaAudio";
            this.SfogliaAudio.Size = new System.Drawing.Size(120, 62);
            this.SfogliaAudio.TabIndex = 44;
            this.SfogliaAudio.Text = "Scegli il suono";
            this.SfogliaAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaAudio.UseVisualStyleBackColor = false;
            this.SfogliaAudio.Click += new System.EventHandler(this.SfogliaAudio_Click);
            // 
            // Salva
            // 
            this.Salva.BackColor = System.Drawing.Color.Yellow;
            this.Salva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Salva.BackgroundImage")));
            this.Salva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Salva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Salva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Salva.Location = new System.Drawing.Point(25, 18);
            this.Salva.Name = "Salva";
            this.Salva.Size = new System.Drawing.Size(226, 111);
            this.Salva.TabIndex = 55;
            this.Salva.Text = "Salva";
            this.Salva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Salva.UseVisualStyleBackColor = false;
            this.Salva.Click += new System.EventHandler(this.Salva_Click);
            // 
            // Annulla
            // 
            this.Annulla.BackColor = System.Drawing.Color.Yellow;
            this.Annulla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Annulla.BackgroundImage")));
            this.Annulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Annulla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Annulla.Location = new System.Drawing.Point(17, 19);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(120, 62);
            this.Annulla.TabIndex = 56;
            this.Annulla.Text = "Indietro";
            this.Annulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Annulla.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(427, 37);
            this.label5.TabIndex = 11;
            this.label5.Text = "Inserimento componente in";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(189, 320);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(394, 26);
            this.textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(189, 397);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(394, 26);
            this.textBox5.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(189, 475);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(394, 26);
            this.textBox6.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(68, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Video";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(68, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Immagine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(68, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "Testo";
            // 
            // SfogliaVideo
            // 
            this.SfogliaVideo.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaVideo.Location = new System.Drawing.Point(602, 297);
            this.SfogliaVideo.Name = "SfogliaVideo";
            this.SfogliaVideo.Size = new System.Drawing.Size(120, 62);
            this.SfogliaVideo.TabIndex = 54;
            this.SfogliaVideo.Text = "Scegli il video";
            this.SfogliaVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaVideo.UseVisualStyleBackColor = false;
            this.SfogliaVideo.Click += new System.EventHandler(this.SfogliaVideo_Click);
            // 
            // SfogliaImmagine
            // 
            this.SfogliaImmagine.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaImmagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaImmagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaImmagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaImmagine.Location = new System.Drawing.Point(602, 378);
            this.SfogliaImmagine.Name = "SfogliaImmagine";
            this.SfogliaImmagine.Size = new System.Drawing.Size(120, 62);
            this.SfogliaImmagine.TabIndex = 53;
            this.SfogliaImmagine.Text = "Scegli l\'immagine";
            this.SfogliaImmagine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaImmagine.UseVisualStyleBackColor = false;
            this.SfogliaImmagine.Click += new System.EventHandler(this.SfogliaImmagine_Click);
            // 
            // SfogliaTesto
            // 
            this.SfogliaTesto.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaTesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaTesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaTesto.Location = new System.Drawing.Point(602, 458);
            this.SfogliaTesto.Name = "SfogliaTesto";
            this.SfogliaTesto.Size = new System.Drawing.Size(120, 62);
            this.SfogliaTesto.TabIndex = 52;
            this.SfogliaTesto.Text = "Scegli il testo";
            this.SfogliaTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaTesto.UseVisualStyleBackColor = false;
            this.SfogliaTesto.Click += new System.EventHandler(this.SfogliaTesto_Click);
            // 
            // EliminaAudio
            // 
            this.EliminaAudio.BackColor = System.Drawing.Color.Yellow;
            this.EliminaAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaAudio.Location = new System.Drawing.Point(747, 219);
            this.EliminaAudio.Name = "EliminaAudio";
            this.EliminaAudio.Size = new System.Drawing.Size(120, 62);
            this.EliminaAudio.TabIndex = 51;
            this.EliminaAudio.Text = "Elimina il suono";
            this.EliminaAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaAudio.UseVisualStyleBackColor = false;
            this.EliminaAudio.Visible = false;
            this.EliminaAudio.Click += new System.EventHandler(this.EliminaAudio_Click);
            // 
            // EliminaVideo
            // 
            this.EliminaVideo.BackColor = System.Drawing.Color.Yellow;
            this.EliminaVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaVideo.Location = new System.Drawing.Point(747, 297);
            this.EliminaVideo.Name = "EliminaVideo";
            this.EliminaVideo.Size = new System.Drawing.Size(120, 62);
            this.EliminaVideo.TabIndex = 47;
            this.EliminaVideo.Text = "Elimina il video";
            this.EliminaVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaVideo.UseVisualStyleBackColor = false;
            this.EliminaVideo.Visible = false;
            this.EliminaVideo.Click += new System.EventHandler(this.EliminaVideo_Click);
            // 
            // EliminaImmagine
            // 
            this.EliminaImmagine.BackColor = System.Drawing.Color.Yellow;
            this.EliminaImmagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaImmagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaImmagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaImmagine.Location = new System.Drawing.Point(747, 378);
            this.EliminaImmagine.Name = "EliminaImmagine";
            this.EliminaImmagine.Size = new System.Drawing.Size(120, 62);
            this.EliminaImmagine.TabIndex = 46;
            this.EliminaImmagine.Text = "Elimina l\'immagine";
            this.EliminaImmagine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaImmagine.UseVisualStyleBackColor = false;
            this.EliminaImmagine.Visible = false;
            this.EliminaImmagine.Click += new System.EventHandler(this.EliminaImmagine_Click);
            // 
            // EliminaTesto
            // 
            this.EliminaTesto.BackColor = System.Drawing.Color.Yellow;
            this.EliminaTesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaTesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaTesto.Location = new System.Drawing.Point(747, 458);
            this.EliminaTesto.Name = "EliminaTesto";
            this.EliminaTesto.Size = new System.Drawing.Size(120, 62);
            this.EliminaTesto.TabIndex = 45;
            this.EliminaTesto.Text = "Elimina il testo";
            this.EliminaTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaTesto.UseVisualStyleBackColor = false;
            this.EliminaTesto.Visible = false;
            this.EliminaTesto.Click += new System.EventHandler(this.EliminaTesto_Click);
            // 
            // PreviewTesto
            // 
            this.PreviewTesto.BackColor = System.Drawing.Color.Yellow;
            this.PreviewTesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewTesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewTesto.Location = new System.Drawing.Point(892, 458);
            this.PreviewTesto.Name = "PreviewTesto";
            this.PreviewTesto.Size = new System.Drawing.Size(120, 62);
            this.PreviewTesto.TabIndex = 50;
            this.PreviewTesto.Text = "Che testo ho scelto ?";
            this.PreviewTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewTesto.UseVisualStyleBackColor = false;
            this.PreviewTesto.Visible = false;
            this.PreviewTesto.Click += new System.EventHandler(this.PreviewTesto_Click);
            // 
            // PreviewImmagine
            // 
            this.PreviewImmagine.BackColor = System.Drawing.Color.Yellow;
            this.PreviewImmagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewImmagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewImmagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewImmagine.Location = new System.Drawing.Point(892, 378);
            this.PreviewImmagine.Name = "PreviewImmagine";
            this.PreviewImmagine.Size = new System.Drawing.Size(120, 62);
            this.PreviewImmagine.TabIndex = 49;
            this.PreviewImmagine.Text = "Che immagine ho scelto ?";
            this.PreviewImmagine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewImmagine.UseVisualStyleBackColor = false;
            this.PreviewImmagine.Visible = false;
            this.PreviewImmagine.Click += new System.EventHandler(this.PreviewImmagine_Click);
            // 
            // PreviewVideo
            // 
            this.PreviewVideo.BackColor = System.Drawing.Color.Yellow;
            this.PreviewVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewVideo.Location = new System.Drawing.Point(892, 297);
            this.PreviewVideo.Name = "PreviewVideo";
            this.PreviewVideo.Size = new System.Drawing.Size(120, 62);
            this.PreviewVideo.TabIndex = 48;
            this.PreviewVideo.Text = "Che video ho scelto ?";
            this.PreviewVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewVideo.UseVisualStyleBackColor = false;
            this.PreviewVideo.Visible = false;
            this.PreviewVideo.Click += new System.EventHandler(this.PreviewVideo_Click);
            // 
            // PreviewAudio
            // 
            this.PreviewAudio.BackColor = System.Drawing.Color.Yellow;
            this.PreviewAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewAudio.Location = new System.Drawing.Point(892, 219);
            this.PreviewAudio.Name = "PreviewAudio";
            this.PreviewAudio.Size = new System.Drawing.Size(120, 62);
            this.PreviewAudio.TabIndex = 57;
            this.PreviewAudio.Text = "Che suono ho scelto ?";
            this.PreviewAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewAudio.UseVisualStyleBackColor = false;
            this.PreviewAudio.Visible = false;
            this.PreviewAudio.Click += new System.EventHandler(this.PreviewAudio_Click);
            // 
            // mainButton1
            // 
            this.mainButton1.BackColor = System.Drawing.Color.Yellow;
            this.mainButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainButton1.BackgroundImage")));
            this.mainButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.mainButton1.Location = new System.Drawing.Point(283, 18);
            this.mainButton1.Name = "mainButton1";
            this.mainButton1.Size = new System.Drawing.Size(226, 111);
            this.mainButton1.TabIndex = 58;
            this.mainButton1.Text = "Annulla";
            this.mainButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mainButton1.UseVisualStyleBackColor = false;
            this.mainButton1.Click += new System.EventHandler(this.mainButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mainButton1);
            this.groupBox1.Controls.Add(this.Salva);
            this.groupBox1.Location = new System.Drawing.Point(189, 554);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 146);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // NuovoComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.SfogliaAudio);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PreviewAudio);
            this.Controls.Add(this.EliminaAudio);
            this.Controls.Add(this.SfogliaVideo);
            this.Controls.Add(this.SfogliaImmagine);
            this.Controls.Add(this.EliminaTesto);
            this.Controls.Add(this.SfogliaTesto);
            this.Controls.Add(this.EliminaVideo);
            this.Controls.Add(this.PreviewImmagine);
            this.Controls.Add(this.PreviewVideo);
            this.Controls.Add(this.PreviewTesto);
            this.Controls.Add(this.EliminaImmagine);
            this.Name = "NuovoComponente";
            this.Text = "Inserimento nuovo componente - Fase di Postering";
            this.Load += new System.EventHandler(this.NuovoComponente_Load);
            this.Controls.SetChildIndex(this.EliminaImmagine, 0);
            this.Controls.SetChildIndex(this.PreviewTesto, 0);
            this.Controls.SetChildIndex(this.PreviewVideo, 0);
            this.Controls.SetChildIndex(this.PreviewImmagine, 0);
            this.Controls.SetChildIndex(this.EliminaVideo, 0);
            this.Controls.SetChildIndex(this.SfogliaTesto, 0);
            this.Controls.SetChildIndex(this.EliminaTesto, 0);
            this.Controls.SetChildIndex(this.SfogliaImmagine, 0);
            this.Controls.SetChildIndex(this.SfogliaVideo, 0);
            this.Controls.SetChildIndex(this.EliminaAudio, 0);
            this.Controls.SetChildIndex(this.PreviewAudio, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBox6, 0);
            this.Controls.SetChildIndex(this.SfogliaAudio, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.grouppoControl, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost1, 0);
            this.Controls.SetChildIndex(this.pictureBoxPost2, 0);
            this.Controls.SetChildIndex(this.textBoxPost, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).EndInit();
            this.grouppoControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private ControlButton Annulla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ControlButton SfogliaVideo;
        private ControlButton SfogliaImmagine;
        private ControlButton SfogliaTesto;
        private ControlButton EliminaAudio;
        private ControlButton EliminaVideo;
        private ControlButton EliminaImmagine;
        private ControlButton EliminaTesto;
        private ControlButton PreviewTesto;
        private ControlButton PreviewImmagine;
        private ControlButton PreviewVideo;
        private ControlButton PreviewAudio;
        private ControlButton SfogliaAudio;
        private MainButton Salva;
        private MainButton mainButton1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}