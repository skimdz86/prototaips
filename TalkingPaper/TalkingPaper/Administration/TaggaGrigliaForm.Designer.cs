using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Administration
{
    partial class TaggaGrigliaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaggaGrigliaForm));
            this.ElencoTag = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag)).BeginInit();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.Size = new System.Drawing.Size(305, 33);
            this.sottotitolo.Text = "Tagging della Griglia";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annulla.Click += new System.EventHandler(this.annulla_Click);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // ElencoTag
            // 
            this.ElencoTag.AllowUserToAddRows = false;
            this.ElencoTag.AllowUserToDeleteRows = false;
            this.ElencoTag.AllowUserToResizeRows = false;
            this.ElencoTag.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.ElencoTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ElencoTag.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ElencoTag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ElencoTag.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ElencoTag.DefaultCellStyle = dataGridViewCellStyle2;
            this.ElencoTag.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ElencoTag.EnableHeadersVisualStyles = false;
            this.ElencoTag.GridColor = System.Drawing.Color.OrangeRed;
            this.ElencoTag.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ElencoTag.Location = new System.Drawing.Point(9, 237);
            this.ElencoTag.MinimumSize = new System.Drawing.Size(900, 300);
            this.ElencoTag.MultiSelect = false;
            this.ElencoTag.Name = "ElencoTag";
            this.ElencoTag.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ElencoTag.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ElencoTag.RowHeadersVisible = false;
            this.ElencoTag.RowHeadersWidth = 120;
            this.ElencoTag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ElencoTag.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ElencoTag.RowTemplate.Height = 33;
            this.ElencoTag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ElencoTag.ShowEditingIcon = false;
            this.ElencoTag.Size = new System.Drawing.Size(1007, 313);
            this.ElencoTag.TabIndex = 0;
            this.ElencoTag.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ElencoTag_CellClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(990, 99);
            this.label3.TabIndex = 0;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // TaggaGrigliaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.CancelButton = this.annulla;
            this.ClientSize = new System.Drawing.Size(1028, 732);
            this.Controls.Add(this.ElencoTag);
            this.Controls.Add(this.label3);
            this.Name = "TaggaGrigliaForm";
            this.Text = "Identificare il supporto e mettere i tag";
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.ElencoTag, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElencoTag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ElencoTag;
        private System.Windows.Forms.Label label3;
        
    }
}