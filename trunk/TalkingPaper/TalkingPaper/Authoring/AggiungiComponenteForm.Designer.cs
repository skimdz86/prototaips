using TalkingPaper.Common;
using System.Windows.Forms;
namespace TalkingPaper.Authoring
{
    partial class AggiungiComponenteForm
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
            this.PreviewAudio = new System.Windows.Forms.Button();
            this.PreviewVideo = new System.Windows.Forms.Button();
            this.PreviewImmagine = new System.Windows.Forms.Button();
            this.PreviewTesto = new System.Windows.Forms.Button();
            this.EliminaTesto = new System.Windows.Forms.Button();
            this.EliminaImmagine = new System.Windows.Forms.Button();
            this.EliminaVideo = new System.Windows.Forms.Button();
            this.EliminaAudio = new System.Windows.Forms.Button();
            this.SfogliaTesto = new System.Windows.Forms.Button();
            this.SfogliaImmagine = new System.Windows.Forms.Button();
            this.SfogliaVideo = new System.Windows.Forms.Button();
            this.testoLabel = new System.Windows.Forms.Label();
            this.immagineLabel = new System.Windows.Forms.Label();
            this.videoLabel = new System.Windows.Forms.Label();
            this.testoBox = new System.Windows.Forms.TextBox();
            this.immagineBox = new System.Windows.Forms.TextBox();
            this.videoBox = new System.Windows.Forms.TextBox();
            this.SfogliaAudio = new System.Windows.Forms.Button();
            this.suonoBox = new System.Windows.Forms.TextBox();
            this.nomeBox = new System.Windows.Forms.TextBox();
            this.suonoLabel = new System.Windows.Forms.Label();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.labelTesto2 = new System.Windows.Forms.Label();
            this.boxSotto.SuspendLayout();
            this.boxSopra.SuspendLayout();
            this.SuspendLayout();
            // 
            // sottotitolo
            // 
            this.sottotitolo.AutoSize = false;
            this.sottotitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sottotitolo.Location = new System.Drawing.Point(12, 88);
            this.sottotitolo.Size = new System.Drawing.Size(728, 74);
            this.sottotitolo.Text = "Dai un nome al nuovo componente e cerca il suono o il video da inserire";
            // 
            // home
            // 
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // annulla
            // 
            this.annulla.Click += new System.EventHandler(this.annulla_Click_1);
            // 
            // ok
            // 
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // PreviewAudio
            // 
            this.PreviewAudio.BackColor = System.Drawing.Color.Yellow;
            this.PreviewAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewAudio.Location = new System.Drawing.Point(891, 214);
            this.PreviewAudio.Name = "PreviewAudio";
            this.PreviewAudio.Size = new System.Drawing.Size(120, 62);
            this.PreviewAudio.TabIndex = 44;
            this.PreviewAudio.Text = "Che suono ho scelto?";
            this.PreviewAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewAudio.UseVisualStyleBackColor = false;
            this.PreviewAudio.Click += new System.EventHandler(this.PreviewAudio_Click);
            // 
            // PreviewVideo
            // 
            this.PreviewVideo.BackColor = System.Drawing.Color.Yellow;
            this.PreviewVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewVideo.Location = new System.Drawing.Point(891, 282);
            this.PreviewVideo.Name = "PreviewVideo";
            this.PreviewVideo.Size = new System.Drawing.Size(120, 62);
            this.PreviewVideo.TabIndex = 45;
            this.PreviewVideo.Text = "Che video ho scelto?";
            this.PreviewVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewVideo.UseVisualStyleBackColor = false;
            this.PreviewVideo.Click += new System.EventHandler(this.PreviewVideo_Click);
            // 
            // PreviewImmagine
            // 
            this.PreviewImmagine.BackColor = System.Drawing.Color.Yellow;
            this.PreviewImmagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewImmagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewImmagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewImmagine.Location = new System.Drawing.Point(891, 406);
            this.PreviewImmagine.Name = "PreviewImmagine";
            this.PreviewImmagine.Size = new System.Drawing.Size(120, 62);
            this.PreviewImmagine.TabIndex = 46;
            this.PreviewImmagine.Text = "Che immagine ho scelto?";
            this.PreviewImmagine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewImmagine.UseVisualStyleBackColor = false;
            this.PreviewImmagine.Click += new System.EventHandler(this.PreviewImmagine_Click);
            // 
            // PreviewTesto
            // 
            this.PreviewTesto.BackColor = System.Drawing.Color.Yellow;
            this.PreviewTesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviewTesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.PreviewTesto.Location = new System.Drawing.Point(891, 474);
            this.PreviewTesto.Name = "PreviewTesto";
            this.PreviewTesto.Size = new System.Drawing.Size(120, 62);
            this.PreviewTesto.TabIndex = 47;
            this.PreviewTesto.Text = "Che testo ho scelto?";
            this.PreviewTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PreviewTesto.UseVisualStyleBackColor = false;
            this.PreviewTesto.Click += new System.EventHandler(this.PreviewTesto_Click);
            // 
            // EliminaTesto
            // 
            this.EliminaTesto.BackColor = System.Drawing.Color.Yellow;
            this.EliminaTesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaTesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaTesto.Location = new System.Drawing.Point(765, 474);
            this.EliminaTesto.Name = "EliminaTesto";
            this.EliminaTesto.Size = new System.Drawing.Size(120, 62);
            this.EliminaTesto.TabIndex = 48;
            this.EliminaTesto.Text = "Elimina il testo";
            this.EliminaTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaTesto.UseVisualStyleBackColor = false;
            this.EliminaTesto.Click += new System.EventHandler(this.EliminaTesto_Click);
            // 
            // EliminaImmagine
            // 
            this.EliminaImmagine.BackColor = System.Drawing.Color.Yellow;
            this.EliminaImmagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaImmagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaImmagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaImmagine.Location = new System.Drawing.Point(765, 406);
            this.EliminaImmagine.Name = "EliminaImmagine";
            this.EliminaImmagine.Size = new System.Drawing.Size(120, 62);
            this.EliminaImmagine.TabIndex = 49;
            this.EliminaImmagine.Text = "Elimina l\'immagine";
            this.EliminaImmagine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaImmagine.UseVisualStyleBackColor = false;
            this.EliminaImmagine.Click += new System.EventHandler(this.EliminaImmagine_Click);
            // 
            // EliminaVideo
            // 
            this.EliminaVideo.BackColor = System.Drawing.Color.Yellow;
            this.EliminaVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaVideo.Location = new System.Drawing.Point(765, 282);
            this.EliminaVideo.Name = "EliminaVideo";
            this.EliminaVideo.Size = new System.Drawing.Size(120, 62);
            this.EliminaVideo.TabIndex = 50;
            this.EliminaVideo.Text = "Elimina il video";
            this.EliminaVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaVideo.UseVisualStyleBackColor = false;
            this.EliminaVideo.Click += new System.EventHandler(this.EliminaVideo_Click);
            // 
            // EliminaAudio
            // 
            this.EliminaAudio.BackColor = System.Drawing.Color.Yellow;
            this.EliminaAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EliminaAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EliminaAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.EliminaAudio.Location = new System.Drawing.Point(765, 214);
            this.EliminaAudio.Name = "EliminaAudio";
            this.EliminaAudio.Size = new System.Drawing.Size(120, 62);
            this.EliminaAudio.TabIndex = 51;
            this.EliminaAudio.Text = "Elimina il suono";
            this.EliminaAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EliminaAudio.UseVisualStyleBackColor = false;
            this.EliminaAudio.Click += new System.EventHandler(this.EliminaAudio_Click);
            // 
            // SfogliaTesto
            // 
            this.SfogliaTesto.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaTesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaTesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaTesto.Location = new System.Drawing.Point(636, 474);
            this.SfogliaTesto.Name = "SfogliaTesto";
            this.SfogliaTesto.Size = new System.Drawing.Size(120, 62);
            this.SfogliaTesto.TabIndex = 52;
            this.SfogliaTesto.Text = "Scegli il testo";
            this.SfogliaTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaTesto.UseVisualStyleBackColor = false;
            this.SfogliaTesto.Click += new System.EventHandler(this.SfogliaTesto_Click);
            // 
            // SfogliaImmagine
            // 
            this.SfogliaImmagine.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaImmagine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaImmagine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaImmagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaImmagine.Location = new System.Drawing.Point(636, 406);
            this.SfogliaImmagine.Name = "SfogliaImmagine";
            this.SfogliaImmagine.Size = new System.Drawing.Size(120, 62);
            this.SfogliaImmagine.TabIndex = 53;
            this.SfogliaImmagine.Text = "Scegli l\'immagine";
            this.SfogliaImmagine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaImmagine.UseVisualStyleBackColor = false;
            this.SfogliaImmagine.Click += new System.EventHandler(this.SfogliaImmagine_Click);
            // 
            // SfogliaVideo
            // 
            this.SfogliaVideo.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaVideo.Location = new System.Drawing.Point(636, 282);
            this.SfogliaVideo.Name = "SfogliaVideo";
            this.SfogliaVideo.Size = new System.Drawing.Size(120, 62);
            this.SfogliaVideo.TabIndex = 54;
            this.SfogliaVideo.Text = "Scegli il video";
            this.SfogliaVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaVideo.UseVisualStyleBackColor = false;
            this.SfogliaVideo.Click += new System.EventHandler(this.SfogliaVideo_Click);
            // 
            // testoLabel
            // 
            this.testoLabel.AutoSize = true;
            this.testoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testoLabel.ForeColor = System.Drawing.Color.White;
            this.testoLabel.Location = new System.Drawing.Point(36, 493);
            this.testoLabel.Name = "testoLabel";
            this.testoLabel.Size = new System.Drawing.Size(62, 24);
            this.testoLabel.TabIndex = 42;
            this.testoLabel.Text = "Testo";
            // 
            // immagineLabel
            // 
            this.immagineLabel.AutoSize = true;
            this.immagineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.immagineLabel.ForeColor = System.Drawing.Color.White;
            this.immagineLabel.Location = new System.Drawing.Point(36, 431);
            this.immagineLabel.Name = "immagineLabel";
            this.immagineLabel.Size = new System.Drawing.Size(101, 24);
            this.immagineLabel.TabIndex = 41;
            this.immagineLabel.Text = "Immagine";
            // 
            // videoLabel
            // 
            this.videoLabel.AutoSize = true;
            this.videoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoLabel.ForeColor = System.Drawing.Color.White;
            this.videoLabel.Location = new System.Drawing.Point(31, 306);
            this.videoLabel.Name = "videoLabel";
            this.videoLabel.Size = new System.Drawing.Size(65, 24);
            this.videoLabel.TabIndex = 40;
            this.videoLabel.Text = "Video";
            // 
            // testoBox
            // 
            this.testoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testoBox.Location = new System.Drawing.Point(195, 493);
            this.testoBox.Name = "testoBox";
            this.testoBox.ReadOnly = true;
            this.testoBox.Size = new System.Drawing.Size(394, 26);
            this.testoBox.TabIndex = 39;
            // 
            // immagineBox
            // 
            this.immagineBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.immagineBox.Location = new System.Drawing.Point(195, 429);
            this.immagineBox.Name = "immagineBox";
            this.immagineBox.ReadOnly = true;
            this.immagineBox.Size = new System.Drawing.Size(394, 26);
            this.immagineBox.TabIndex = 38;
            // 
            // videoBox
            // 
            this.videoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoBox.Location = new System.Drawing.Point(190, 304);
            this.videoBox.Name = "videoBox";
            this.videoBox.ReadOnly = true;
            this.videoBox.Size = new System.Drawing.Size(394, 26);
            this.videoBox.TabIndex = 37;
            // 
            // SfogliaAudio
            // 
            this.SfogliaAudio.BackColor = System.Drawing.Color.Yellow;
            this.SfogliaAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SfogliaAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SfogliaAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.SfogliaAudio.Location = new System.Drawing.Point(636, 214);
            this.SfogliaAudio.Name = "SfogliaAudio";
            this.SfogliaAudio.Size = new System.Drawing.Size(120, 62);
            this.SfogliaAudio.TabIndex = 56;
            this.SfogliaAudio.Text = "Scegli il suono";
            this.SfogliaAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SfogliaAudio.UseVisualStyleBackColor = false;
            this.SfogliaAudio.Click += new System.EventHandler(this.SfogliaAudio_Click);
            // 
            // suonoBox
            // 
            this.suonoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suonoBox.Location = new System.Drawing.Point(194, 235);
            this.suonoBox.Name = "suonoBox";
            this.suonoBox.ReadOnly = true;
            this.suonoBox.Size = new System.Drawing.Size(394, 26);
            this.suonoBox.TabIndex = 32;
            // 
            // nomeBox
            // 
            this.nomeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeBox.Location = new System.Drawing.Point(190, 174);
            this.nomeBox.Name = "nomeBox";
            this.nomeBox.Size = new System.Drawing.Size(394, 26);
            this.nomeBox.TabIndex = 31;
            // 
            // suonoLabel
            // 
            this.suonoLabel.AutoSize = true;
            this.suonoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suonoLabel.ForeColor = System.Drawing.Color.White;
            this.suonoLabel.Location = new System.Drawing.Point(31, 235);
            this.suonoLabel.Name = "suonoLabel";
            this.suonoLabel.Size = new System.Drawing.Size(71, 24);
            this.suonoLabel.TabIndex = 30;
            this.suonoLabel.Text = "Suono";
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeLabel.ForeColor = System.Drawing.Color.White;
            this.nomeLabel.Location = new System.Drawing.Point(36, 174);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(66, 24);
            this.nomeLabel.TabIndex = 29;
            this.nomeLabel.Text = "Nome";
            // 
            // labelTesto2
            // 
            this.labelTesto2.AutoSize = true;
            this.labelTesto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesto2.ForeColor = System.Drawing.Color.White;
            this.labelTesto2.Location = new System.Drawing.Point(12, 370);
            this.labelTesto2.Name = "labelTesto2";
            this.labelTesto2.Size = new System.Drawing.Size(911, 29);
            this.labelTesto2.TabIndex = 57;
            this.labelTesto2.Text = "Vuoi selezionare una immagine o un testo da stampare per il tuo componente";
            // 
            // AggiungiComponenteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1028, 739);
            this.Controls.Add(this.labelTesto2);
            this.Controls.Add(this.PreviewAudio);
            this.Controls.Add(this.PreviewVideo);
            this.Controls.Add(this.PreviewImmagine);
            this.Controls.Add(this.EliminaImmagine);
            this.Controls.Add(this.PreviewTesto);
            this.Controls.Add(this.EliminaVideo);
            this.Controls.Add(this.EliminaTesto);
            this.Controls.Add(this.SfogliaTesto);
            this.Controls.Add(this.EliminaAudio);
            this.Controls.Add(this.SfogliaVideo);
            this.Controls.Add(this.SfogliaImmagine);
            this.Controls.Add(this.testoBox);
            this.Controls.Add(this.testoLabel);
            this.Controls.Add(this.immagineLabel);
            this.Controls.Add(this.immagineBox);
            this.Controls.Add(this.videoLabel);
            this.Controls.Add(this.suonoBox);
            this.Controls.Add(this.SfogliaAudio);
            this.Controls.Add(this.videoBox);
            this.Controls.Add(this.nomeBox);
            this.Controls.Add(this.suonoLabel);
            this.Controls.Add(this.nomeLabel);
            this.Name = "AggiungiComponenteForm";
            this.Text = "NuovoComponente";
            this.Load += new System.EventHandler(this.NuovoComponente_Load);
            this.Controls.SetChildIndex(this.boxSopra, 0);
            this.Controls.SetChildIndex(this.boxSotto, 0);
            this.Controls.SetChildIndex(this.nomeLabel, 0);
            this.Controls.SetChildIndex(this.suonoLabel, 0);
            this.Controls.SetChildIndex(this.nomeBox, 0);
            this.Controls.SetChildIndex(this.videoBox, 0);
            this.Controls.SetChildIndex(this.SfogliaAudio, 0);
            this.Controls.SetChildIndex(this.suonoBox, 0);
            this.Controls.SetChildIndex(this.videoLabel, 0);
            this.Controls.SetChildIndex(this.immagineBox, 0);
            this.Controls.SetChildIndex(this.immagineLabel, 0);
            this.Controls.SetChildIndex(this.testoLabel, 0);
            this.Controls.SetChildIndex(this.testoBox, 0);
            this.Controls.SetChildIndex(this.SfogliaImmagine, 0);
            this.Controls.SetChildIndex(this.SfogliaVideo, 0);
            this.Controls.SetChildIndex(this.EliminaAudio, 0);
            this.Controls.SetChildIndex(this.SfogliaTesto, 0);
            this.Controls.SetChildIndex(this.EliminaTesto, 0);
            this.Controls.SetChildIndex(this.EliminaVideo, 0);
            this.Controls.SetChildIndex(this.PreviewTesto, 0);
            this.Controls.SetChildIndex(this.EliminaImmagine, 0);
            this.Controls.SetChildIndex(this.PreviewImmagine, 0);
            this.Controls.SetChildIndex(this.sottotitolo, 0);
            this.Controls.SetChildIndex(this.titolo, 0);
            this.Controls.SetChildIndex(this.PreviewVideo, 0);
            this.Controls.SetChildIndex(this.PreviewAudio, 0);
            this.Controls.SetChildIndex(this.labelTesto2, 0);
            this.boxSotto.ResumeLayout(false);
            this.boxSotto.PerformLayout();
            this.boxSopra.ResumeLayout(false);
            this.boxSopra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PreviewAudio;
        private Button PreviewVideo;
        private Button PreviewImmagine;
        private Button PreviewTesto;
        private Button EliminaTesto;
        private Button EliminaImmagine;
        private Button EliminaVideo;
        private Button EliminaAudio;
        private Button SfogliaTesto;
        private Button SfogliaImmagine;
        private Button SfogliaVideo;
        private System.Windows.Forms.Label testoLabel;
        private System.Windows.Forms.Label immagineLabel;
        private System.Windows.Forms.Label videoLabel;
        private System.Windows.Forms.TextBox testoBox;
        private System.Windows.Forms.TextBox immagineBox;
        private System.Windows.Forms.TextBox videoBox;
        private Button SfogliaAudio;
        private System.Windows.Forms.TextBox suonoBox;
        private System.Windows.Forms.TextBox nomeBox;
        private System.Windows.Forms.Label suonoLabel;
        private System.Windows.Forms.Label nomeLabel;
        private Label labelTesto2;
    }
}