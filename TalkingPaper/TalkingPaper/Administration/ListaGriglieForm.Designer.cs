using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Administration
{
    partial class ListaGriglieForm
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
            this.noGriglie = new System.Windows.Forms.Label();
            this.SchemaGriglia = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.indietro = new System.Windows.Forms.Button();
            this.pannello = new System.Windows.Forms.Panel();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchemaGriglia)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.AutoSize = false;
            this.sottotitolo.Size = new System.Drawing.Size(704, 69);
            this.sottotitolo.Text = "Seleziona la griglia che desideri modificare dalla lista";
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
            // noGriglie
            // 
            this.noGriglie.AutoSize = true;
            this.noGriglie.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noGriglie.ForeColor = System.Drawing.Color.White;
            this.noGriglie.Location = new System.Drawing.Point(-50, 154);
            this.noGriglie.Name = "noGriglie";
            this.noGriglie.Size = new System.Drawing.Size(355, 32);
            this.noGriglie.TabIndex = 26;
            this.noGriglie.Text = "Non sono presenti griglie";
            this.noGriglie.Visible = false;
            // 
            // SchemaGriglia
            // 
            this.SchemaGriglia.AllowUserToAddRows = false;
            this.SchemaGriglia.AllowUserToDeleteRows = false;
            this.SchemaGriglia.AllowUserToResizeRows = false;
            this.SchemaGriglia.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.SchemaGriglia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SchemaGriglia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SchemaGriglia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SchemaGriglia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SchemaGriglia.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SchemaGriglia.DefaultCellStyle = dataGridViewCellStyle2;
            this.SchemaGriglia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.SchemaGriglia.EnableHeadersVisualStyles = false;
            this.SchemaGriglia.GridColor = System.Drawing.Color.OrangeRed;
            this.SchemaGriglia.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SchemaGriglia.Location = new System.Drawing.Point(13, 18);
            this.SchemaGriglia.MultiSelect = false;
            this.SchemaGriglia.Name = "SchemaGriglia";
            this.SchemaGriglia.ReadOnly = true;
            this.SchemaGriglia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SchemaGriglia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SchemaGriglia.RowHeadersVisible = false;
            this.SchemaGriglia.RowHeadersWidth = 120;
            this.SchemaGriglia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.SchemaGriglia.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.SchemaGriglia.RowTemplate.Height = 33;
            this.SchemaGriglia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SchemaGriglia.ShowEditingIcon = false;
            this.SchemaGriglia.Size = new System.Drawing.Size(639, 344);
            this.SchemaGriglia.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Red;
            this.groupBox2.Controls.Add(this.noGriglie);
            this.groupBox2.Controls.Add(this.SchemaGriglia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(334, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 377);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Yellow;
            this.indietro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indietro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.indietro.Location = new System.Drawing.Point(0, 0);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(75, 23);
            this.indietro.TabIndex = 0;
            this.indietro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.indietro.UseVisualStyleBackColor = false;
            // 
            // pannello
            // 
            this.pannello.AutoScroll = true;
            this.pannello.Location = new System.Drawing.Point(18, 154);
            this.pannello.Name = "pannello";
            this.pannello.Size = new System.Drawing.Size(310, 408);
            this.pannello.TabIndex = 54;
            // 
            // ListaGriglieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pannello);
            this.Name = "ListaGriglieForm";
            this.Text = "Scegli una griglia";
            this.Controls.SetChildIndex(this.pannello, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchemaGriglia)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noGriglie;
        private System.Windows.Forms.DataGridView SchemaGriglia;
        private System.Windows.Forms.GroupBox groupBox2;
        private Button indietro;
        private System.Windows.Forms.Panel pannello;
    }
}