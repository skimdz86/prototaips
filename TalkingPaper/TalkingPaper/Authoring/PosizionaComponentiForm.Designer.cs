using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Authoring
{
    partial class PosizionaComponentiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosizionaComponentiForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.noComponenti = new System.Windows.Forms.Label();
            this.ElencoRisorse = new System.Windows.Forms.DataGridView();
            this.controlloBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aggiungi = new System.Windows.Forms.Button();
            this.scegliOggetto = new System.Windows.Forms.Label();
            this.trascina = new System.Windows.Forms.Label();
            this.schemaGriglia = new System.Windows.Forms.DataGridView();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).BeginInit();
            this.controlloBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schemaGriglia)).BeginInit();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(338, 33);
            this.sottotitolo.Text = "Posiziona i componenti";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // boxSotto
            // 
            this.boxSotto.Location = new System.Drawing.Point(610, 591);
            // 
            // noComponenti
            // 
            this.noComponenti.AutoSize = true;
            this.noComponenti.BackColor = System.Drawing.Color.DarkOrange;
            this.noComponenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noComponenti.ForeColor = System.Drawing.Color.White;
            this.noComponenti.Location = new System.Drawing.Point(33, 270);
            this.noComponenti.Name = "noComponenti";
            this.noComponenti.Size = new System.Drawing.Size(268, 99);
            this.noComponenti.TabIndex = 45;
            this.noComponenti.Text = "Non sono presenti\r\ncomponenti ....\r\nAggiungili!";
            this.noComponenti.Visible = false;
            // 
            // ElencoRisorse
            // 
            this.ElencoRisorse.AllowUserToAddRows = false;
            this.ElencoRisorse.AllowUserToDeleteRows = false;
            this.ElencoRisorse.AllowUserToResizeRows = false;
            this.ElencoRisorse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ElencoRisorse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ElencoRisorse.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.ElencoRisorse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoRisorse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ElencoRisorse.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoRisorse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ElencoRisorse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoRisorse.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoRisorse.DefaultCellStyle = dataGridViewCellStyle2;
            this.ElencoRisorse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoRisorse.EnableHeadersVisualStyles = false;
            this.ElencoRisorse.GridColor = System.Drawing.Color.Cyan;
            this.ElencoRisorse.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoRisorse.Location = new System.Drawing.Point(14, 224);
            this.ElencoRisorse.MultiSelect = false;
            this.ElencoRisorse.Name = "ElencoRisorse";
            this.ElencoRisorse.ReadOnly = true;
            this.ElencoRisorse.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoRisorse.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ElencoRisorse.RowHeadersVisible = false;
            this.ElencoRisorse.RowHeadersWidth = 120;
            this.ElencoRisorse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoRisorse.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoRisorse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoRisorse.ShowEditingIcon = false;
            this.ElencoRisorse.Size = new System.Drawing.Size(336, 346);
            this.ElencoRisorse.TabIndex = 42;
            // 
            // controlloBox
            // 
            this.controlloBox.BackColor = System.Drawing.Color.Orange;
            this.controlloBox.Controls.Add(this.label3);
            this.controlloBox.Controls.Add(this.label2);
            this.controlloBox.Controls.Add(this.label1);
            this.controlloBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlloBox.ForeColor = System.Drawing.Color.White;
            this.controlloBox.Location = new System.Drawing.Point(5, 576);
            this.controlloBox.Name = "controlloBox";
            this.controlloBox.Size = new System.Drawing.Size(570, 157);
            this.controlloBox.TabIndex = 58;
            this.controlloBox.TabStop = false;
            this.controlloBox.Text = "Componenti di controllo";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(384, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 110);
            this.label3.TabIndex = 54;
            this.label3.Text = "Stop";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(218, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 110);
            this.label2.TabIndex = 53;
            this.label2.Text = "Pausa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(47, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 110);
            this.label1.TabIndex = 52;
            this.label1.Text = "Play";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // aggiungi
            // 
            this.aggiungi.BackColor = System.Drawing.Color.Yellow;
            this.aggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aggiungi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aggiungi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aggiungi.Location = new System.Drawing.Point(571, 106);
            this.aggiungi.Name = "aggiungi";
            this.aggiungi.Size = new System.Drawing.Size(124, 62);
            this.aggiungi.TabIndex = 53;
            this.aggiungi.Text = "Aggiungi";
            this.aggiungi.UseVisualStyleBackColor = false;
            this.aggiungi.Click += new System.EventHandler(this.aggiungi_Click);
            // 
            // scegliOggetto
            // 
            this.scegliOggetto.AutoSize = true;
            this.scegliOggetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scegliOggetto.ForeColor = System.Drawing.Color.White;
            this.scegliOggetto.Location = new System.Drawing.Point(12, 117);
            this.scegliOggetto.Name = "scegliOggetto";
            this.scegliOggetto.Size = new System.Drawing.Size(506, 33);
            this.scegliOggetto.TabIndex = 64;
            this.scegliOggetto.Text = "Scegli un nuovo oggetto da inserire";
            // 
            // trascina
            // 
            this.trascina.AutoSize = true;
            this.trascina.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trascina.ForeColor = System.Drawing.Color.White;
            this.trascina.Location = new System.Drawing.Point(12, 174);
            this.trascina.Name = "trascina";
            this.trascina.Size = new System.Drawing.Size(776, 33);
            this.trascina.TabIndex = 65;
            this.trascina.Text = "Trascina il componente su una casella per aggiungerlo";
            this.trascina.Visible = false;
            // 
            // schemaGriglia
            // 
            this.schemaGriglia.AllowUserToAddRows = false;
            this.schemaGriglia.AllowUserToDeleteRows = false;
            this.schemaGriglia.AllowUserToResizeColumns = false;
            this.schemaGriglia.AllowUserToResizeRows = false;
            this.schemaGriglia.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.schemaGriglia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schemaGriglia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.schemaGriglia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.schemaGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.schemaGriglia.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.schemaGriglia.DefaultCellStyle = dataGridViewCellStyle6;
            this.schemaGriglia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.schemaGriglia.EnableHeadersVisualStyles = false;
            this.schemaGriglia.GridColor = System.Drawing.Color.Black;
            this.schemaGriglia.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.schemaGriglia.Location = new System.Drawing.Point(350, 232);
            this.schemaGriglia.MultiSelect = false;
            this.schemaGriglia.Name = "schemaGriglia";
            this.schemaGriglia.ReadOnly = true;
            this.schemaGriglia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.schemaGriglia.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.schemaGriglia.RowHeadersVisible = false;
            this.schemaGriglia.RowHeadersWidth = 120;
            this.schemaGriglia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Peru;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.schemaGriglia.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.schemaGriglia.RowTemplate.Height = 33;
            this.schemaGriglia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.schemaGriglia.ShowEditingIcon = false;
            this.schemaGriglia.Size = new System.Drawing.Size(635, 360);
            this.schemaGriglia.TabIndex = 67;
            this.schemaGriglia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.schemaGriglia_CellClick);
            // 
            // PosizionaComponentiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.schemaGriglia);
            this.Controls.Add(this.trascina);
            this.Controls.Add(this.controlloBox);
            this.Controls.Add(this.scegliOggetto);
            this.Controls.Add(this.aggiungi);
            this.Controls.Add(this.noComponenti);
            this.Controls.Add(this.ElencoRisorse);
            this.Name = "PosizionaComponentiForm";
            this.Text = "FormVisualizzaElementiAuthoring";
            this.VisibleChanged += new System.EventHandler(this.PosizionaComponentiForm_VisibleChanged);
            this.Controls.SetChildIndex(this.ElencoRisorse, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.noComponenti, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.aggiungi, 0);
            this.Controls.SetChildIndex(this.scegliOggetto, 0);
            this.Controls.SetChildIndex(this.controlloBox, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.trascina, 0);
            this.Controls.SetChildIndex(this.schemaGriglia, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).EndInit();
            this.controlloBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schemaGriglia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noComponenti;
        private System.Windows.Forms.DataGridView ElencoRisorse;
        private System.Windows.Forms.GroupBox controlloBox;
        private Button aggiungi;
        private System.Windows.Forms.Label scegliOggetto;
        private Label trascina;
        private DataGridView schemaGriglia;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}