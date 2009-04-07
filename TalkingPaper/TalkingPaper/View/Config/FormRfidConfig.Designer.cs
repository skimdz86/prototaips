namespace TalkingPaper.Config
{
    partial class FormRfidConfig
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
            this.cancel = new System.Windows.Forms.Button();
            this.nTimeOut = new System.Windows.Forms.Label();
            this.cBaudRate = new System.Windows.Forms.Label();
            this.cFrame = new System.Windows.Forms.Label();
            this.port_number = new System.Windows.Forms.Label();
            this.to_val = new System.Windows.Forms.TextBox();
            this.bRate_val = new System.Windows.Forms.TextBox();
            this.cFrame_val = new System.Windows.Forms.TextBox();
            this.port_number_val = new System.Windows.Forms.TextBox();
            this.Button_Salva = new System.Windows.Forms.Button();
            this.lblRFidcfg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.labelOK = new System.Windows.Forms.Label();
            this.labelNO = new System.Windows.Forms.Label();
            this.labelNO2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost1)).BeginInit();
            this.grouppoControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grouppoControl
            // 
            this.grouppoControl.Controls.Add(this.cancel);
            this.grouppoControl.Controls.Add(this.Button_Salva);
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(400, 33);
            this.sottotitolo.Text = "Configura il dispositivo RFif";
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Yellow;
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cancel.Location = new System.Drawing.Point(218, 19);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(120, 61);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // nTimeOut
            // 
            this.nTimeOut.AutoSize = true;
            this.nTimeOut.Location = new System.Drawing.Point(23, 149);
            this.nTimeOut.Name = "nTimeOut";
            this.nTimeOut.Size = new System.Drawing.Size(70, 16);
            this.nTimeOut.TabIndex = 27;
            this.nTimeOut.Text = "Time Out";
            // 
            // cBaudRate
            // 
            this.cBaudRate.AutoSize = true;
            this.cBaudRate.Location = new System.Drawing.Point(23, 107);
            this.cBaudRate.Name = "cBaudRate";
            this.cBaudRate.Size = new System.Drawing.Size(81, 16);
            this.cBaudRate.TabIndex = 26;
            this.cBaudRate.Text = "Baud Rate";
            // 
            // cFrame
            // 
            this.cFrame.AutoSize = true;
            this.cFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cFrame.Location = new System.Drawing.Point(23, 65);
            this.cFrame.Name = "cFrame";
            this.cFrame.Size = new System.Drawing.Size(149, 16);
            this.cFrame.TabIndex = 25;
            this.cFrame.Text = "Comunication Frame";
            this.cFrame.UseMnemonic = false;
            // 
            // port_number
            // 
            this.port_number.AutoSize = true;
            this.port_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.port_number.Location = new System.Drawing.Point(23, 23);
            this.port_number.Name = "port_number";
            this.port_number.Size = new System.Drawing.Size(94, 16);
            this.port_number.TabIndex = 24;
            this.port_number.Text = "Port Number";
            // 
            // to_val
            // 
            this.to_val.Location = new System.Drawing.Point(226, 146);
            this.to_val.Name = "to_val";
            this.to_val.Size = new System.Drawing.Size(160, 22);
            this.to_val.TabIndex = 4;
            this.to_val.Text = "1000";
            this.to_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bRate_val
            // 
            this.bRate_val.Location = new System.Drawing.Point(226, 104);
            this.bRate_val.Name = "bRate_val";
            this.bRate_val.Size = new System.Drawing.Size(160, 22);
            this.bRate_val.TabIndex = 3;
            this.bRate_val.Text = "38400";
            this.bRate_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cFrame_val
            // 
            this.cFrame_val.Location = new System.Drawing.Point(226, 59);
            this.cFrame_val.Name = "cFrame_val";
            this.cFrame_val.Size = new System.Drawing.Size(160, 22);
            this.cFrame_val.TabIndex = 2;
            this.cFrame_val.Text = "8E1";
            this.cFrame_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // port_number_val
            // 
            this.port_number_val.Location = new System.Drawing.Point(226, 17);
            this.port_number_val.Name = "port_number_val";
            this.port_number_val.Size = new System.Drawing.Size(160, 22);
            this.port_number_val.TabIndex = 2;
            this.port_number_val.Text = "- immettere il numero di porta - ";
            this.port_number_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.port_number_val.Leave += new System.EventHandler(this.Port_n_Leave);
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
            this.Button_Salva.Click += new System.EventHandler(this.config_button_Click);
            // 
            // lblRFidcfg
            // 
            this.lblRFidcfg.AutoSize = true;
            this.lblRFidcfg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFidcfg.ForeColor = System.Drawing.Color.White;
            this.lblRFidcfg.Location = new System.Drawing.Point(477, 184);
            this.lblRFidcfg.Name = "lblRFidcfg";
            this.lblRFidcfg.Size = new System.Drawing.Size(184, 24);
            this.lblRFidcfg.TabIndex = 39;
            this.lblRFidcfg.Text = "RFid Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Di seguito vengono riportati i valori standard. Cambiarli se ritenuto necessario";
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.Yellow;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.Location = new System.Drawing.Point(266, 200);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(120, 50);
            this.buttonHelp.TabIndex = 41;
            this.buttonHelp.Text = "help";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Visible = false;
            this.buttonHelp.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.BackColor = System.Drawing.Color.Yellow;
            this.buttonTestConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTestConnection.Location = new System.Drawing.Point(405, 200);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(120, 50);
            this.buttonTestConnection.TabIndex = 42;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = false;
            this.buttonTestConnection.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelOK
            // 
            this.labelOK.AutoSize = true;
            this.labelOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOK.ForeColor = System.Drawing.Color.Blue;
            this.labelOK.Location = new System.Drawing.Point(368, 610);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(424, 20);
            this.labelOK.TabIndex = 43;
            this.labelOK.Text = "Connessione riuscita, puoi salvare la configurazione";
            this.labelOK.Visible = false;
            // 
            // labelNO
            // 
            this.labelNO.AutoSize = true;
            this.labelNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNO.ForeColor = System.Drawing.Color.Red;
            this.labelNO.Location = new System.Drawing.Point(461, 610);
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
            this.labelNO2.Location = new System.Drawing.Point(352, 639);
            this.labelNO2.Name = "labelNO2";
            this.labelNO2.Size = new System.Drawing.Size(491, 16);
            this.labelNO2.TabIndex = 45;
            this.labelNO2.Text = "Assicurarsi che il dispositivo sia collegato correttamente, e i dati inseriti sia" +
                " corretti";
            this.labelNO2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Orange;
            this.groupBox1.Controls.Add(this.buttonTestConnection);
            this.groupBox1.Controls.Add(this.buttonHelp);
            this.groupBox1.Controls.Add(this.nTimeOut);
            this.groupBox1.Controls.Add(this.cBaudRate);
            this.groupBox1.Controls.Add(this.cFrame);
            this.groupBox1.Controls.Add(this.port_number);
            this.groupBox1.Controls.Add(this.to_val);
            this.groupBox1.Controls.Add(this.bRate_val);
            this.groupBox1.Controls.Add(this.cFrame_val);
            this.groupBox1.Controls.Add(this.port_number_val);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(318, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 274);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // FormRfidConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1184, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelNO2);
            this.Controls.Add(this.labelNO);
            this.Controls.Add(this.labelOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRFidcfg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRfidConfig";
            this.Text = "Rfid Reader Configuration";
            this.Load += new System.EventHandler(this.FormRfidConfig_Load);
            this.Enter += new System.EventHandler(this.On_Enter);
            this.Controls.SetChildIndex(this.lblRFidcfg, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.labelOK, 0);
            this.Controls.SetChildIndex(this.labelNO, 0);
            this.Controls.SetChildIndex(this.labelNO2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
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
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label nTimeOut;
        private System.Windows.Forms.Label cBaudRate;
        private System.Windows.Forms.Label cFrame;
        private System.Windows.Forms.Label port_number;
        private System.Windows.Forms.TextBox to_val;
        private System.Windows.Forms.TextBox bRate_val;
        private System.Windows.Forms.TextBox cFrame_val;
        private System.Windows.Forms.TextBox port_number_val;
        private System.Windows.Forms.Button Button_Salva;
        private System.Windows.Forms.Label lblRFidcfg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Label labelOK;
        private System.Windows.Forms.Label labelNO;
        private System.Windows.Forms.Label labelNO2;
        private System.Windows.Forms.GroupBox groupBox1;
    
    }
}