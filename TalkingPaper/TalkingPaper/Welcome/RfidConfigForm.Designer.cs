namespace TalkingPaper.Welcome
{
    partial class RfidConfigForm
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
            this.port_number = new System.Windows.Forms.Label();
            this.Button_Salva = new System.Windows.Forms.Button();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.labelOK = new System.Windows.Forms.Label();
            this.labelNO = new System.Windows.Forms.Label();
            this.labelNO2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.button1 = new TalkingPaper.MainButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(398, 33);
            this.sottotitolo.Text = "Configura il dispositivo Rfid";
            // 
            // port_number
            // 
            this.port_number.AutoSize = true;
            this.port_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.port_number.Location = new System.Drawing.Point(126, 53);
            this.port_number.Name = "port_number";
            this.port_number.Size = new System.Drawing.Size(110, 16);
            this.port_number.TabIndex = 24;
            this.port_number.Text = "Scegli la Porta";
            // 
            // Button_Salva
            // 
            this.Button_Salva.BackColor = System.Drawing.Color.Yellow;
            this.Button_Salva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Salva.Enabled = false;
            this.Button_Salva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Button_Salva.Location = new System.Drawing.Point(17, 19);
            this.Button_Salva.Name = "Button_Salva";
            this.Button_Salva.Size = new System.Drawing.Size(120, 61);
            this.Button_Salva.TabIndex = 10;
            this.Button_Salva.Text = "Salva";
            this.Button_Salva.UseVisualStyleBackColor = false;
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.BackColor = System.Drawing.Color.Yellow;
            this.buttonTestConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTestConnection.Location = new System.Drawing.Point(195, 110);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(160, 78);
            this.buttonTestConnection.TabIndex = 42;
            this.buttonTestConnection.Text = "Prova la connessione";
            this.buttonTestConnection.UseVisualStyleBackColor = false;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // labelOK
            // 
            this.labelOK.AutoSize = true;
            this.labelOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOK.ForeColor = System.Drawing.Color.Blue;
            this.labelOK.Location = new System.Drawing.Point(48, 240);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(462, 20);
            this.labelOK.TabIndex = 43;
            this.labelOK.Text = "Connessione riuscita!! La configurazione è stata salvata.";
            this.labelOK.Visible = false;
            // 
            // labelNO
            // 
            this.labelNO.AutoSize = true;
            this.labelNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNO.ForeColor = System.Drawing.Color.Red;
            this.labelNO.Location = new System.Drawing.Point(163, 240);
            this.labelNO.Name = "labelNO";
            this.labelNO.Size = new System.Drawing.Size(223, 20);
            this.labelNO.TabIndex = 44;
            this.labelNO.Text = "Connessione NON riuscita.";
            this.labelNO.Visible = false;
            // 
            // labelNO2
            // 
            this.labelNO2.AutoSize = true;
            this.labelNO2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNO2.ForeColor = System.Drawing.Color.Red;
            this.labelNO2.Location = new System.Drawing.Point(32, 269);
            this.labelNO2.Name = "labelNO2";
            this.labelNO2.Size = new System.Drawing.Size(494, 16);
            this.labelNO2.TabIndex = 45;
            this.labelNO2.Text = "Assicurarsi che il dispositivo sia collegato correttamente, e i dati inseriti sia" +
                " corretti.";
            this.labelNO2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.comboPort);
            this.groupBox1.Controls.Add(this.buttonTestConnection);
            this.groupBox1.Controls.Add(this.labelNO2);
            this.groupBox1.Controls.Add(this.port_number);
            this.groupBox1.Controls.Add(this.labelNO);
            this.groupBox1.Controls.Add(this.labelOK);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(324, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 324);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // comboPort
            // 
            this.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPort.FormattingEnabled = true;
            this.comboPort.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboPort.Location = new System.Drawing.Point(309, 50);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(92, 24);
            this.comboPort.TabIndex = 43;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(853, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 69);
            this.button1.TabIndex = 46;
            this.button1.Text = "Indietro";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RfidConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1136, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RfidConfigForm";
            this.Text = "Rfid Reader Configuration";
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.help, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Label port_number;
        private System.Windows.Forms.Button Button_Salva;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Label labelOK;
        private System.Windows.Forms.Label labelNO;
        private System.Windows.Forms.Label labelNO2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboPort;
        private TalkingPaper.MainButton button1;
    
    }
}