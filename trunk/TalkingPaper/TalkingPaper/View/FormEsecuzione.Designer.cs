namespace TalkingPaper
{
    partial class FormEsecuzione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEsecuzione));
            this.labelTitolo = new System.Windows.Forms.Label();
            this.labelEsecuzione = new System.Windows.Forms.Label();
            this.labelNoEsecuzione = new System.Windows.Forms.Label();
            this.buttonAttiva = new System.Windows.Forms.Button();
            this.buttonDisattiva = new System.Windows.Forms.Button();
            this.buttonEsc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNomeRisorsa = new System.Windows.Forms.Label();
            this.labelNomeContenuto = new System.Windows.Forms.Label();
            this.labelNomePoster = new System.Windows.Forms.Label();
            this.labelRfidTag = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.linkLabelStorico = new System.Windows.Forms.LinkLabel();
            this.labelUtente = new System.Windows.Forms.Label();
            this.labelProfilo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerRisorsa = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSalvaDisplay = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.labelOrario = new System.Windows.Forms.Label();
            this.labelOrario2 = new System.Windows.Forms.Label();
            this.labelTagNonPresente = new System.Windows.Forms.Label();
            this.buttonSalvaConsole = new System.Windows.Forms.Button();
            this.buttonStoricoContenuti = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonSalvaErrori = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.admin1 = new System.Windows.Forms.GroupBox();
            this.admin2 = new System.Windows.Forms.GroupBox();
            this.Admin = new TalkingPaper.ControlButton();
            this.panel1.SuspendLayout();
            this.admin1.SuspendLayout();
            this.admin2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoSize = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitolo.ForeColor = System.Drawing.Color.Black;
            this.labelTitolo.Location = new System.Drawing.Point(24, 33);
            this.labelTitolo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(185, 20);
            this.labelTitolo.TabIndex = 0;
            this.labelTitolo.Text = "Il sistema è in modalità di";
            // 
            // labelEsecuzione
            // 
            this.labelEsecuzione.AutoSize = true;
            this.labelEsecuzione.ForeColor = System.Drawing.Color.White;
            this.labelEsecuzione.Location = new System.Drawing.Point(219, 33);
            this.labelEsecuzione.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelEsecuzione.Name = "labelEsecuzione";
            this.labelEsecuzione.Size = new System.Drawing.Size(102, 20);
            this.labelEsecuzione.TabIndex = 1;
            this.labelEsecuzione.Text = "Esecuzione";
            this.labelEsecuzione.Visible = false;
            // 
            // labelNoEsecuzione
            // 
            this.labelNoEsecuzione.AutoSize = true;
            this.labelNoEsecuzione.ForeColor = System.Drawing.Color.White;
            this.labelNoEsecuzione.Location = new System.Drawing.Point(217, 33);
            this.labelNoEsecuzione.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelNoEsecuzione.Name = "labelNoEsecuzione";
            this.labelNoEsecuzione.Size = new System.Drawing.Size(142, 20);
            this.labelNoEsecuzione.TabIndex = 2;
            this.labelNoEsecuzione.Text = "NON esecuzione";
            // 
            // buttonAttiva
            // 
            this.buttonAttiva.BackColor = System.Drawing.Color.Yellow;
            this.buttonAttiva.ForeColor = System.Drawing.Color.Black;
            this.buttonAttiva.Location = new System.Drawing.Point(29, 16);
            this.buttonAttiva.Name = "buttonAttiva";
            this.buttonAttiva.Size = new System.Drawing.Size(117, 66);
            this.buttonAttiva.TabIndex = 3;
            this.buttonAttiva.Text = "ATTIVA";
            this.buttonAttiva.UseVisualStyleBackColor = false;
            this.buttonAttiva.Click += new System.EventHandler(this.buttonAttiva_Click);
            // 
            // buttonDisattiva
            // 
            this.buttonDisattiva.BackColor = System.Drawing.Color.Yellow;
            this.buttonDisattiva.Enabled = false;
            this.buttonDisattiva.ForeColor = System.Drawing.Color.Black;
            this.buttonDisattiva.Location = new System.Drawing.Point(182, 16);
            this.buttonDisattiva.Name = "buttonDisattiva";
            this.buttonDisattiva.Size = new System.Drawing.Size(112, 66);
            this.buttonDisattiva.TabIndex = 4;
            this.buttonDisattiva.Text = "DISATTIVA";
            this.buttonDisattiva.UseVisualStyleBackColor = false;
            this.buttonDisattiva.Click += new System.EventHandler(this.buttonDisattiva_Click);
            // 
            // buttonEsc
            // 
            this.buttonEsc.BackColor = System.Drawing.Color.Yellow;
            this.buttonEsc.ForeColor = System.Drawing.Color.Black;
            this.buttonEsc.Location = new System.Drawing.Point(998, 36);
            this.buttonEsc.Name = "buttonEsc";
            this.buttonEsc.Size = new System.Drawing.Size(156, 66);
            this.buttonEsc.TabIndex = 5;
            this.buttonEsc.Text = "ESCI";
            this.buttonEsc.UseVisualStyleBackColor = false;
            this.buttonEsc.Click += new System.EventHandler(this.buttonEsc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Esecuzione di:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "File: ";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cartellone: ";
            this.label3.Visible = false;
            // 
            // labelNomeRisorsa
            // 
            this.labelNomeRisorsa.AutoSize = true;
            this.labelNomeRisorsa.ForeColor = System.Drawing.Color.White;
            this.labelNomeRisorsa.Location = new System.Drawing.Point(160, 224);
            this.labelNomeRisorsa.Name = "labelNomeRisorsa";
            this.labelNomeRisorsa.Size = new System.Drawing.Size(154, 20);
            this.labelNomeRisorsa.TabIndex = 9;
            this.labelNomeRisorsa.Text = "labelNomeRisorsa";
            this.labelNomeRisorsa.Visible = false;
            // 
            // labelNomeContenuto
            // 
            this.labelNomeContenuto.AutoSize = true;
            this.labelNomeContenuto.ForeColor = System.Drawing.Color.White;
            this.labelNomeContenuto.Location = new System.Drawing.Point(160, 185);
            this.labelNomeContenuto.Name = "labelNomeContenuto";
            this.labelNomeContenuto.Size = new System.Drawing.Size(177, 20);
            this.labelNomeContenuto.TabIndex = 10;
            this.labelNomeContenuto.Text = "labelNomeContenuto";
            this.labelNomeContenuto.Visible = false;
            // 
            // labelNomePoster
            // 
            this.labelNomePoster.AutoSize = true;
            this.labelNomePoster.ForeColor = System.Drawing.Color.White;
            this.labelNomePoster.Location = new System.Drawing.Point(160, 151);
            this.labelNomePoster.Name = "labelNomePoster";
            this.labelNomePoster.Size = new System.Drawing.Size(145, 20);
            this.labelNomePoster.TabIndex = 11;
            this.labelNomePoster.Text = "labelNomePoster";
            this.labelNomePoster.Visible = false;
            // 
            // labelRfidTag
            // 
            this.labelRfidTag.AutoSize = true;
            this.labelRfidTag.ForeColor = System.Drawing.Color.White;
            this.labelRfidTag.Location = new System.Drawing.Point(114, 151);
            this.labelRfidTag.Name = "labelRfidTag";
            this.labelRfidTag.Size = new System.Drawing.Size(77, 20);
            this.labelRfidTag.TabIndex = 12;
            this.labelRfidTag.Text = "Rfid Tag";
            this.labelRfidTag.Visible = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(24, 151);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(73, 20);
            this.label.TabIndex = 14;
            this.label.Text = "Rfid tag";
            this.label.Visible = false;
            // 
            // linkLabelStorico
            // 
            this.linkLabelStorico.AutoSize = true;
            this.linkLabelStorico.Enabled = false;
            this.linkLabelStorico.Location = new System.Drawing.Point(739, 70);
            this.linkLabelStorico.Name = "linkLabelStorico";
            this.linkLabelStorico.Size = new System.Drawing.Size(229, 20);
            this.linkLabelStorico.TabIndex = 16;
            this.linkLabelStorico.TabStop = true;
            this.linkLabelStorico.Text = "Elenco dei contenuti visitati";
            this.linkLabelStorico.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelStorico_LinkClicked);
            // 
            // labelUtente
            // 
            this.labelUtente.AutoSize = true;
            this.labelUtente.ForeColor = System.Drawing.Color.White;
            this.labelUtente.Location = new System.Drawing.Point(114, 106);
            this.labelUtente.Name = "labelUtente";
            this.labelUtente.Size = new System.Drawing.Size(102, 20);
            this.labelUtente.TabIndex = 17;
            this.labelUtente.Text = "labelUtente";
            this.labelUtente.Visible = false;
            // 
            // labelProfilo
            // 
            this.labelProfilo.AutoSize = true;
            this.labelProfilo.ForeColor = System.Drawing.Color.Blue;
            this.labelProfilo.Location = new System.Drawing.Point(112, 20);
            this.labelProfilo.Name = "labelProfilo";
            this.labelProfilo.Size = new System.Drawing.Size(98, 20);
            this.labelProfilo.TabIndex = 18;
            this.labelProfilo.Text = "labelProfilo";
            this.labelProfilo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "di profilo";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Utente";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(27, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Stato: ";
            this.label7.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(160, 273);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(100, 20);
            this.labelStatus.TabIndex = 22;
            this.labelStatus.Text = "labelStatus";
            this.labelStatus.Visible = false;
            // 
            // timerRisorsa
            // 
            this.timerRisorsa.Enabled = true;
            this.timerRisorsa.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.buttonSalvaDisplay);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(19, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 167);
            this.panel1.TabIndex = 24;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(26, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(902, 127);
            this.richTextBox1.TabIndex = 29;
            this.richTextBox1.Text = "";
            // 
            // buttonSalvaDisplay
            // 
            this.buttonSalvaDisplay.Location = new System.Drawing.Point(36, 407);
            this.buttonSalvaDisplay.Name = "buttonSalvaDisplay";
            this.buttonSalvaDisplay.Size = new System.Drawing.Size(149, 29);
            this.buttonSalvaDisplay.TabIndex = 2;
            this.buttonSalvaDisplay.Text = "Salva";
            this.buttonSalvaDisplay.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Internal Message Console";
            // 
            // labelOrario
            // 
            this.labelOrario.AutoSize = true;
            this.labelOrario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrario.ForeColor = System.Drawing.Color.White;
            this.labelOrario.Location = new System.Drawing.Point(442, 273);
            this.labelOrario.Name = "labelOrario";
            this.labelOrario.Size = new System.Drawing.Size(39, 15);
            this.labelOrario.TabIndex = 25;
            this.labelOrario.Text = "orario";
            this.labelOrario.Visible = false;
            // 
            // labelOrario2
            // 
            this.labelOrario2.AutoSize = true;
            this.labelOrario2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrario2.ForeColor = System.Drawing.Color.White;
            this.labelOrario2.Location = new System.Drawing.Point(369, 273);
            this.labelOrario2.Name = "labelOrario2";
            this.labelOrario2.Size = new System.Drawing.Size(46, 15);
            this.labelOrario2.TabIndex = 26;
            this.labelOrario2.Text = "orario2";
            this.labelOrario2.Visible = false;
            // 
            // labelTagNonPresente
            // 
            this.labelTagNonPresente.AutoSize = true;
            this.labelTagNonPresente.ForeColor = System.Drawing.Color.White;
            this.labelTagNonPresente.Location = new System.Drawing.Point(436, 33);
            this.labelTagNonPresente.Name = "labelTagNonPresente";
            this.labelTagNonPresente.Size = new System.Drawing.Size(272, 20);
            this.labelTagNonPresente.TabIndex = 28;
            this.labelTagNonPresente.Text = "Ultimo Tag letto non è eseguibile";
            this.labelTagNonPresente.Visible = false;
            // 
            // buttonSalvaConsole
            // 
            this.buttonSalvaConsole.BackColor = System.Drawing.Color.Yellow;
            this.buttonSalvaConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvaConsole.Location = new System.Drawing.Point(982, 272);
            this.buttonSalvaConsole.Name = "buttonSalvaConsole";
            this.buttonSalvaConsole.Size = new System.Drawing.Size(156, 63);
            this.buttonSalvaConsole.TabIndex = 29;
            this.buttonSalvaConsole.Text = "Salva Contenuto Console";
            this.buttonSalvaConsole.UseVisualStyleBackColor = false;
            this.buttonSalvaConsole.Click += new System.EventHandler(this.buttonSalvaConsole_Click);
            // 
            // buttonStoricoContenuti
            // 
            this.buttonStoricoContenuti.BackColor = System.Drawing.Color.Yellow;
            this.buttonStoricoContenuti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonStoricoContenuti.Location = new System.Drawing.Point(980, 51);
            this.buttonStoricoContenuti.Name = "buttonStoricoContenuti";
            this.buttonStoricoContenuti.Size = new System.Drawing.Size(156, 66);
            this.buttonStoricoContenuti.TabIndex = 30;
            this.buttonStoricoContenuti.Text = "Salva Storico Contenuti";
            this.buttonStoricoContenuti.UseVisualStyleBackColor = false;
            this.buttonStoricoContenuti.Click += new System.EventHandler(this.buttonStoricoContenuti_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(739, 164);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(154, 20);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Elenco degli errori";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonSalvaErrori
            // 
            this.buttonSalvaErrori.BackColor = System.Drawing.Color.Yellow;
            this.buttonSalvaErrori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSalvaErrori.Location = new System.Drawing.Point(981, 141);
            this.buttonSalvaErrori.Name = "buttonSalvaErrori";
            this.buttonSalvaErrori.Size = new System.Drawing.Size(156, 66);
            this.buttonSalvaErrori.TabIndex = 32;
            this.buttonSalvaErrori.Text = "Salva Storico Errori";
            this.buttonSalvaErrori.UseVisualStyleBackColor = false;
            this.buttonSalvaErrori.Click += new System.EventHandler(this.buttonSalvaErrori_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(519, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 138);
            this.panel2.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 33);
            this.label4.TabIndex = 35;
            this.label4.Text = "Esecuzione";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(454, 55);
            this.label9.TabIndex = 34;
            this.label9.Text = "Cartellone Parlante";
            // 
            // admin1
            // 
            this.admin1.Controls.Add(this.buttonSalvaErrori);
            this.admin1.Controls.Add(this.linkLabel1);
            this.admin1.Controls.Add(this.buttonStoricoContenuti);
            this.admin1.Controls.Add(this.buttonSalvaConsole);
            this.admin1.Controls.Add(this.panel1);
            this.admin1.Controls.Add(this.label6);
            this.admin1.Controls.Add(this.labelTagNonPresente);
            this.admin1.Controls.Add(this.labelUtente);
            this.admin1.Controls.Add(this.linkLabelStorico);
            this.admin1.Controls.Add(this.label);
            this.admin1.Controls.Add(this.labelRfidTag);
            this.admin1.Controls.Add(this.labelTitolo);
            this.admin1.Controls.Add(this.labelNoEsecuzione);
            this.admin1.Controls.Add(this.labelEsecuzione);
            this.admin1.Location = new System.Drawing.Point(16, 350);
            this.admin1.Name = "admin1";
            this.admin1.Size = new System.Drawing.Size(1145, 388);
            this.admin1.TabIndex = 36;
            this.admin1.TabStop = false;
            this.admin1.Visible = false;
            // 
            // admin2
            // 
            this.admin2.Controls.Add(this.buttonDisattiva);
            this.admin2.Controls.Add(this.buttonAttiva);
            this.admin2.Location = new System.Drawing.Point(844, 273);
            this.admin2.Name = "admin2";
            this.admin2.Size = new System.Drawing.Size(317, 90);
            this.admin2.TabIndex = 37;
            this.admin2.TabStop = false;
            this.admin2.Visible = false;
            // 
            // Admin
            // 
            this.Admin.BackColor = System.Drawing.Color.Yellow;
            this.Admin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin.BackgroundImage")));
            this.Admin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Admin.Location = new System.Drawing.Point(864, 36);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(120, 62);
            this.Admin.TabIndex = 56;
            this.Admin.Text = "Amministratore";
            this.Admin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Admin.UseVisualStyleBackColor = false;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // FormEsecuzione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.ControlBox = false;
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.admin2);
            this.Controls.Add(this.admin1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelOrario2);
            this.Controls.Add(this.labelOrario);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelProfilo);
            this.Controls.Add(this.labelNomePoster);
            this.Controls.Add(this.labelNomeContenuto);
            this.Controls.Add(this.labelNomeRisorsa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEsc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormEsecuzione";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Esecuzione";
            this.Load += new System.EventHandler(this.FormEsecuzione_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.admin1.ResumeLayout(false);
            this.admin1.PerformLayout();
            this.admin2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.Label labelEsecuzione;
        private System.Windows.Forms.Label labelNoEsecuzione;
        private System.Windows.Forms.Button buttonAttiva;
        private System.Windows.Forms.Button buttonDisattiva;
        private System.Windows.Forms.Button buttonEsc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNomeRisorsa;
        private System.Windows.Forms.Label labelNomeContenuto;
        private System.Windows.Forms.Label labelNomePoster;
        private System.Windows.Forms.Label labelRfidTag;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.LinkLabel linkLabelStorico;
        private System.Windows.Forms.Label labelUtente;
        private System.Windows.Forms.Label labelProfilo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerRisorsa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSalvaDisplay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelOrario;
        private System.Windows.Forms.Label labelOrario2;
        private System.Windows.Forms.Label labelTagNonPresente;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSalvaConsole;
        private System.Windows.Forms.Button buttonStoricoContenuti;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonSalvaErrori;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox admin1;
        private System.Windows.Forms.GroupBox admin2;
        private ControlButton Admin;
    }
}