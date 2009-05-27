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
            this.play = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Label();
            this.pausa = new System.Windows.Forms.Label();
            this.aggiungi = new System.Windows.Forms.Button();
            this.schemaGriglia = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.modifica = new System.Windows.Forms.Button();
            this.elimina = new System.Windows.Forms.Button();
            this.svuotaCella = new System.Windows.Forms.Button();
            this.scegliOggetto = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemaGriglia)).BeginInit();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Location = new System.Drawing.Point(13, 60);
            this.sottotitolo.Size = new System.Drawing.Size(304, 33);
            this.sottotitolo.Text = "Posiziona i contenuti";
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
            this.ElencoRisorse.AllowDrop = true;
            this.ElencoRisorse.AllowUserToAddRows = false;
            this.ElencoRisorse.AllowUserToDeleteRows = false;
            this.ElencoRisorse.AllowUserToResizeColumns = false;
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
            this.ElencoRisorse.Location = new System.Drawing.Point(8, 257);
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
            this.ElencoRisorse.Size = new System.Drawing.Size(336, 330);
            this.ElencoRisorse.TabIndex = 42;
            // 
            // play
            // 
            this.play.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play.ForeColor = System.Drawing.Color.White;
            this.play.Image = ((System.Drawing.Image)(resources.GetObject("play.Image")));
            this.play.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.play.Location = new System.Drawing.Point(45, 616);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(100, 110);
            this.play.TabIndex = 52;
            this.play.Tag = "Play";
            this.play.Text = "Play";
            this.play.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.play.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            // 
            // stop
            // 
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.ForeColor = System.Drawing.Color.White;
            this.stop.Image = ((System.Drawing.Image)(resources.GetObject("stop.Image")));
            this.stop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.stop.Location = new System.Drawing.Point(362, 616);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(100, 110);
            this.stop.TabIndex = 54;
            this.stop.Tag = "Stop";
            this.stop.Text = "Stop";
            this.stop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            // 
            // pausa
            // 
            this.pausa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pausa.ForeColor = System.Drawing.Color.White;
            this.pausa.Image = ((System.Drawing.Image)(resources.GetObject("pausa.Image")));
            this.pausa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.pausa.Location = new System.Drawing.Point(205, 616);
            this.pausa.Name = "pausa";
            this.pausa.Size = new System.Drawing.Size(100, 110);
            this.pausa.TabIndex = 53;
            this.pausa.Tag = "Pausa";
            this.pausa.Text = "Pausa";
            this.pausa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.pausa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            // 
            // aggiungi
            // 
            this.aggiungi.BackColor = System.Drawing.Color.Yellow;
            this.aggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aggiungi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aggiungi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aggiungi.Location = new System.Drawing.Point(604, 68);
            this.aggiungi.Name = "aggiungi";
            this.aggiungi.Size = new System.Drawing.Size(124, 62);
            this.aggiungi.TabIndex = 53;
            this.aggiungi.Text = "Aggiungi";
            this.aggiungi.UseVisualStyleBackColor = false;
            this.aggiungi.Click += new System.EventHandler(this.aggiungi_Click);
            // 
            // schemaGriglia
            // 
            this.schemaGriglia.AllowDrop = true;
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
            this.schemaGriglia.Location = new System.Drawing.Point(372, 256);
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
            this.schemaGriglia.Size = new System.Drawing.Size(618, 333);
            this.schemaGriglia.TabIndex = 67;
            this.schemaGriglia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.schemaGriglia_CellClick);
            this.schemaGriglia.DragEnter += new System.Windows.Forms.DragEventHandler(this.schemaGriglia_DragEnter);
            this.schemaGriglia.DragDrop += new System.Windows.Forms.DragEventHandler(this.schemaGriglia_DragDrop);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(345, 33);
            this.label4.TabIndex = 68;
            this.label4.Text = "Componenti di controllo";
            // 
            // modifica
            // 
            this.modifica.BackColor = System.Drawing.Color.Yellow;
            this.modifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifica.Location = new System.Drawing.Point(605, 142);
            this.modifica.Name = "modifica";
            this.modifica.Size = new System.Drawing.Size(124, 62);
            this.modifica.TabIndex = 69;
            this.modifica.Text = "Modifica contenuto";
            this.modifica.UseVisualStyleBackColor = false;
            this.modifica.Click += new System.EventHandler(this.modifica_Click);
            // 
            // elimina
            // 
            this.elimina.BackColor = System.Drawing.Color.Yellow;
            this.elimina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.elimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.elimina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elimina.Location = new System.Drawing.Point(743, 142);
            this.elimina.Name = "elimina";
            this.elimina.Size = new System.Drawing.Size(124, 62);
            this.elimina.TabIndex = 70;
            this.elimina.Text = "Elimina contenuto";
            this.elimina.UseVisualStyleBackColor = false;
            this.elimina.Click += new System.EventHandler(this.elimina_Click);
            // 
            // svuotaCella
            // 
            this.svuotaCella.BackColor = System.Drawing.Color.Yellow;
            this.svuotaCella.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.svuotaCella.Cursor = System.Windows.Forms.Cursors.Hand;
            this.svuotaCella.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svuotaCella.Location = new System.Drawing.Point(880, 142);
            this.svuotaCella.Name = "svuotaCella";
            this.svuotaCella.Size = new System.Drawing.Size(124, 62);
            this.svuotaCella.TabIndex = 71;
            this.svuotaCella.Text = "Svuota casella";
            this.svuotaCella.UseVisualStyleBackColor = false;
            this.svuotaCella.Click += new System.EventHandler(this.svuotaCella_Click);
            // 
            // scegliOggetto
            // 
            this.scegliOggetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scegliOggetto.ForeColor = System.Drawing.Color.White;
            this.scegliOggetto.Location = new System.Drawing.Point(13, 90);
            this.scegliOggetto.Name = "scegliOggetto";
            this.scegliOggetto.Size = new System.Drawing.Size(586, 170);
            this.scegliOggetto.TabIndex = 64;
            this.scegliOggetto.Text = resources.GetString("scegliOggetto.Text");
            // 
            // PosizionaComponentiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.svuotaCella);
            this.Controls.Add(this.schemaGriglia);
            this.Controls.Add(this.scegliOggetto);
            this.Controls.Add(this.elimina);
            this.Controls.Add(this.modifica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.play);
            this.Controls.Add(this.pausa);
            this.Controls.Add(this.aggiungi);
            this.Controls.Add(this.noComponenti);
            this.Controls.Add(this.ElencoRisorse);
            this.Name = "PosizionaComponentiForm";
            this.Text = "FormVisualizzaElementiAuthoring";
            this.VisibleChanged += new System.EventHandler(this.PosizionaComponentiForm_VisibleChanged);
            this.Controls.SetChildIndex(this.ElencoRisorse, 0);
            this.Controls.SetChildIndex(this.noComponenti, 0);
            this.Controls.SetChildIndex(this.aggiungi, 0);
            this.Controls.SetChildIndex(this.pausa, 0);
            this.Controls.SetChildIndex(this.play, 0);
            this.Controls.SetChildIndex(this.stop, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.modifica, 0);
            this.Controls.SetChildIndex(this.elimina, 0);
            this.Controls.SetChildIndex(this.scegliOggetto, 0);
            this.Controls.SetChildIndex(this.schemaGriglia, 0);
            this.Controls.SetChildIndex(this.svuotaCella, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemaGriglia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noComponenti;
        private System.Windows.Forms.DataGridView ElencoRisorse;
        private Button aggiungi;
        private DataGridView schemaGriglia;
        private Label stop;
        private Label pausa;
        private Label play;
        private Label label4;
        private Button modifica;
        private Button elimina;
        private Button svuotaCella;
        private Label scegliOggetto;
    }
}