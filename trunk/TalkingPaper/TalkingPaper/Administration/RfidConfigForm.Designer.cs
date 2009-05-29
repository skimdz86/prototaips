using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Administration
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
            this.salva = new System.Windows.Forms.Button();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(337, 33);
            this.sottotitolo.Text = "Configura il lettore Rfid";
            // 
            // help
            // 
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
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
            this.buttonTestConnection.Location = new System.Drawing.Point(71, 110);
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
            this.labelOK.Location = new System.Drawing.Point(19, 240);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(526, 20);
            this.labelOK.TabIndex = 43;
            this.labelOK.Text = "Connessione riuscita solo se lampeggia la luce rossa sul lettore. ";
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
            this.groupBox1.Controls.Add(this.salva);
            this.groupBox1.Controls.Add(this.comboPort);
            this.groupBox1.Controls.Add(this.buttonTestConnection);
            this.groupBox1.Controls.Add(this.labelNO2);
            this.groupBox1.Controls.Add(this.port_number);
            this.groupBox1.Controls.Add(this.labelNO);
            this.groupBox1.Controls.Add(this.labelOK);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(239, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 327);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // salva
            // 
            this.salva.BackColor = System.Drawing.Color.Yellow;
            this.salva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salva.Location = new System.Drawing.Point(329, 110);
            this.salva.Name = "salva";
            this.salva.Size = new System.Drawing.Size(160, 78);
            this.salva.TabIndex = 46;
            this.salva.Text = "Salva ed esci";
            this.salva.UseVisualStyleBackColor = false;
            this.salva.Click += new System.EventHandler(this.salva_Click);
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
            // RfidConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RfidConfigForm";
            this.Text = "Rfid Reader Configuration";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
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
        private Button salva;
    
    }
}