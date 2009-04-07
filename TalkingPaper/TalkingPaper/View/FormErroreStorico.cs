using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TalkingPaper
{
    public partial class FormErroreStorico : FormSchema
    {

        public FormErroreStorico(ArrayList arrayStorico, ArrayList arrayData)
        {
            int cont;
            string testo = "";
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 80, true);
            cont = 0;
            String[] arr_cont = (String[])arrayStorico.ToArray(typeof(String));
            DateTime[] arr_data = (DateTime[])arrayData.ToArray(typeof(DateTime));

            if (arr_cont.Length != arr_data.Length)
            {
                Console.WriteLine("Errore nelle dimensioni array");
            }
            else
            {

                for (cont = 0; cont < arr_cont.Length; cont++)
                {
                    testo += arr_cont[cont].ToString() + " "
                        + arr_data[cont].ToString() + "\n\n";
                }
                this.richTextBox1.Text += testo;


            }

        }

        private void buttonChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormErroreStorico_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add by mac
            if (pictureBoxPost2.Visible = true)
            {
                pictureBoxPost2.Visible = false;
                textBoxPost.Visible = false;
            }
            else
            {
                pictureBoxPost2.Visible = true;
                textBoxPost.Visible = true;
            }

        }

        private void buttonChiudi_Click_1(object sender, EventArgs e)
        {
            this.Close();
        
        }
    }
}