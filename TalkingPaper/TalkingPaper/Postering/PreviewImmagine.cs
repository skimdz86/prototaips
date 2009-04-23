using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;



namespace TalkingPaper.Postering
{
    public partial class PreviewImmagine : FormSchema
    {
        private string path;
        private NuovoComponente nuovo_cmponente;
        private ComponentiDelPoster elenco_componenti;
        
        public PreviewImmagine(string path, NuovoComponente componente_nuovo, ComponentiDelPoster elenco_componenti)
        {
            InitializeComponent();
            this.path = path;
            this.nuovo_cmponente = componente_nuovo;
            this.elenco_componenti = elenco_componenti;
            /// Declare a variable to hold a reference to your image.
            FileStream imageStream;
            try
            {
                /// Open your image for Read access as a new FileStream.
                imageStream = new FileStream(path, FileMode.Open, FileAccess.Read);

                /// Set the image for the PictureBox to reduce or to expand 
                /// to fit the size of the PictureBox.
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

                /// Set the location of the PictureBox based on the value of count.
                /// Because the count is always incremented by 2, you have to multiply the value of
                /// count by 64 so that image of size 128x128 can be propery displayed.
                //pictureBox1.Location = new System.Drawing.Point(count * 64, 0);

                /// Set the size of the PictureBox.
                pictureBox1.Size = new System.Drawing.Size(500, 401);

                /// Set the BorderStyle of the PictureBox.
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;

                /// Set the image of the PictureBox from the opened FileStream.
                pictureBox1.Image = System.Drawing.Image.FromStream(imageStream);

                /// Add the PictureBox to your Form1 object.
                this.Controls.Add(pictureBox1);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void ChiudiPreview_Click(object sender, EventArgs e)
        {
            if (elenco_componenti != null)
            {
                elenco_componenti.Enabled = true;
            }
            else {
                nuovo_cmponente.Enabled = true;
            }
            this.Close();
        }

        private void Stampa_Click(object sender, EventArgs e)
        {
            StampaImmagine stampa = new StampaImmagine(path);
        }

    }
}