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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ElencoControlli3 = new System.Windows.Forms.DataGridView();
            this.ElencoControlli2 = new System.Windows.Forms.DataGridView();
            this.ElencoControlli1 = new System.Windows.Forms.DataGridView();
            this.noComponenti = new System.Windows.Forms.Label();
            this.ElencoRisorse = new System.Windows.Forms.DataGridView();
            this.schemaGriglia = new System.Windows.Forms.DataGridView();
            this.controlloBox = new System.Windows.Forms.GroupBox();
            this.aggiungi = new System.Windows.Forms.Button();
            this.scegliOggetto = new System.Windows.Forms.Label();
            this.trascina = new System.Windows.Forms.Label();
            this.yan = new System.Windows.Forms.Button();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoControlli3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoControlli2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoControlli1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemaGriglia)).BeginInit();
            this.controlloBox.SuspendLayout();
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
            // ElencoControlli3
            // 
            this.ElencoControlli3.AllowUserToAddRows = false;
            this.ElencoControlli3.AllowUserToDeleteRows = false;
            this.ElencoControlli3.AllowUserToResizeRows = false;
            this.ElencoControlli3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ElencoControlli3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ElencoControlli3.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.ElencoControlli3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoControlli3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ElencoControlli3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoControlli3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ElencoControlli3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoControlli3.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoControlli3.DefaultCellStyle = dataGridViewCellStyle2;
            this.ElencoControlli3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoControlli3.EnableHeadersVisualStyles = false;
            this.ElencoControlli3.GridColor = System.Drawing.Color.Cyan;
            this.ElencoControlli3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoControlli3.Location = new System.Drawing.Point(394, 46);
            this.ElencoControlli3.MultiSelect = false;
            this.ElencoControlli3.Name = "ElencoControlli3";
            this.ElencoControlli3.ReadOnly = true;
            this.ElencoControlli3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoControlli3.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ElencoControlli3.RowHeadersVisible = false;
            this.ElencoControlli3.RowHeadersWidth = 120;
            this.ElencoControlli3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoControlli3.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoControlli3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoControlli3.ShowEditingIcon = false;
            this.ElencoControlli3.Size = new System.Drawing.Size(161, 80);
            this.ElencoControlli3.TabIndex = 51;
            // 
            // ElencoControlli2
            // 
            this.ElencoControlli2.AllowUserToAddRows = false;
            this.ElencoControlli2.AllowUserToDeleteRows = false;
            this.ElencoControlli2.AllowUserToResizeRows = false;
            this.ElencoControlli2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ElencoControlli2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ElencoControlli2.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.ElencoControlli2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoControlli2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ElencoControlli2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoControlli2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ElencoControlli2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoControlli2.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoControlli2.DefaultCellStyle = dataGridViewCellStyle6;
            this.ElencoControlli2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoControlli2.EnableHeadersVisualStyles = false;
            this.ElencoControlli2.GridColor = System.Drawing.Color.Cyan;
            this.ElencoControlli2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoControlli2.Location = new System.Drawing.Point(204, 46);
            this.ElencoControlli2.MultiSelect = false;
            this.ElencoControlli2.Name = "ElencoControlli2";
            this.ElencoControlli2.ReadOnly = true;
            this.ElencoControlli2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoControlli2.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ElencoControlli2.RowHeadersVisible = false;
            this.ElencoControlli2.RowHeadersWidth = 120;
            this.ElencoControlli2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoControlli2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.ElencoControlli2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoControlli2.ShowEditingIcon = false;
            this.ElencoControlli2.Size = new System.Drawing.Size(161, 80);
            this.ElencoControlli2.TabIndex = 50;
            // 
            // ElencoControlli1
            // 
            this.ElencoControlli1.AllowUserToAddRows = false;
            this.ElencoControlli1.AllowUserToDeleteRows = false;
            this.ElencoControlli1.AllowUserToResizeRows = false;
            this.ElencoControlli1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ElencoControlli1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ElencoControlli1.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.ElencoControlli1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoControlli1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ElencoControlli1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoControlli1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ElencoControlli1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoControlli1.ColumnHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoControlli1.DefaultCellStyle = dataGridViewCellStyle10;
            this.ElencoControlli1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoControlli1.EnableHeadersVisualStyles = false;
            this.ElencoControlli1.GridColor = System.Drawing.Color.Cyan;
            this.ElencoControlli1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoControlli1.Location = new System.Drawing.Point(16, 46);
            this.ElencoControlli1.MultiSelect = false;
            this.ElencoControlli1.Name = "ElencoControlli1";
            this.ElencoControlli1.ReadOnly = true;
            this.ElencoControlli1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoControlli1.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.ElencoControlli1.RowHeadersVisible = false;
            this.ElencoControlli1.RowHeadersWidth = 120;
            this.ElencoControlli1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoControlli1.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.ElencoControlli1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoControlli1.ShowEditingIcon = false;
            this.ElencoControlli1.Size = new System.Drawing.Size(161, 80);
            this.ElencoControlli1.TabIndex = 49;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoRisorse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.ElencoRisorse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElencoRisorse.ColumnHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoRisorse.DefaultCellStyle = dataGridViewCellStyle14;
            this.ElencoRisorse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoRisorse.EnableHeadersVisualStyles = false;
            this.ElencoRisorse.GridColor = System.Drawing.Color.Cyan;
            this.ElencoRisorse.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoRisorse.Location = new System.Drawing.Point(14, 224);
            this.ElencoRisorse.MultiSelect = false;
            this.ElencoRisorse.Name = "ElencoRisorse";
            this.ElencoRisorse.ReadOnly = true;
            this.ElencoRisorse.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoRisorse.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.ElencoRisorse.RowHeadersVisible = false;
            this.ElencoRisorse.RowHeadersWidth = 120;
            this.ElencoRisorse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoRisorse.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.ElencoRisorse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoRisorse.ShowEditingIcon = false;
            this.ElencoRisorse.Size = new System.Drawing.Size(336, 368);
            this.ElencoRisorse.TabIndex = 42;
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.schemaGriglia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.schemaGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.schemaGriglia.ColumnHeadersVisible = false;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.schemaGriglia.DefaultCellStyle = dataGridViewCellStyle18;
            this.schemaGriglia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.schemaGriglia.EnableHeadersVisualStyles = false;
            this.schemaGriglia.GridColor = System.Drawing.Color.DarkRed;
            this.schemaGriglia.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.schemaGriglia.Location = new System.Drawing.Point(375, 224);
            this.schemaGriglia.MultiSelect = false;
            this.schemaGriglia.Name = "schemaGriglia";
            this.schemaGriglia.ReadOnly = true;
            this.schemaGriglia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.schemaGriglia.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.schemaGriglia.RowHeadersVisible = false;
            this.schemaGriglia.RowHeadersWidth = 120;
            this.schemaGriglia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.schemaGriglia.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.schemaGriglia.RowTemplate.Height = 33;
            this.schemaGriglia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.schemaGriglia.ShowEditingIcon = false;
            this.schemaGriglia.Size = new System.Drawing.Size(635, 360);
            this.schemaGriglia.TabIndex = 54;
            this.schemaGriglia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.schemaGriglia_CellContentClick);
            // 
            // controlloBox
            // 
            this.controlloBox.BackColor = System.Drawing.Color.Orange;
            this.controlloBox.Controls.Add(this.ElencoControlli1);
            this.controlloBox.Controls.Add(this.ElencoControlli3);
            this.controlloBox.Controls.Add(this.ElencoControlli2);
            this.controlloBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlloBox.ForeColor = System.Drawing.Color.White;
            this.controlloBox.Location = new System.Drawing.Point(5, 601);
            this.controlloBox.Name = "controlloBox";
            this.controlloBox.Size = new System.Drawing.Size(570, 132);
            this.controlloBox.TabIndex = 58;
            this.controlloBox.TabStop = false;
            this.controlloBox.Text = "Componenti di controllo";
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
            // yan
            // 
            this.yan.BackColor = System.Drawing.Color.Yellow;
            this.yan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yan.Location = new System.Drawing.Point(514, 21);
            this.yan.Name = "yan";
            this.yan.Size = new System.Drawing.Size(124, 62);
            this.yan.TabIndex = 66;
            this.yan.Text = "yan";
            this.yan.UseVisualStyleBackColor = false;
            this.yan.Click += new System.EventHandler(this.yan_Click);
            // 
            // PosizionaComponentiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.yan);
            this.Controls.Add(this.trascina);
            this.Controls.Add(this.controlloBox);
            this.Controls.Add(this.schemaGriglia);
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
            this.Controls.SetChildIndex(this.schemaGriglia, 0);
            this.Controls.SetChildIndex(this.controlloBox, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.trascina, 0);
            this.Controls.SetChildIndex(this.yan, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoControlli3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoControlli2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoControlli1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoRisorse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemaGriglia)).EndInit();
            this.controlloBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ElencoControlli3;
        private System.Windows.Forms.DataGridView ElencoControlli2;
        private System.Windows.Forms.DataGridView ElencoControlli1;
        private System.Windows.Forms.Label noComponenti;
        private System.Windows.Forms.DataGridView ElencoRisorse;
        private System.Windows.Forms.DataGridView schemaGriglia;
        private System.Windows.Forms.GroupBox controlloBox;
        private Button aggiungi;
        private System.Windows.Forms.Label scegliOggetto;
        private Label trascina;
        private Button yan;
    }
}