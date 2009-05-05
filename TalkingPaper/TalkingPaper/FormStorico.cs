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
    public partial class FormStorico : Common.FormSchema
    {

        public FormStorico(ArrayList arrayStorico ,ArrayList arrayData )
        {
            int cont;
            string testo = "";
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            cont = 0;
            Contenuto2[] arr_cont = (Contenuto2[])arrayStorico.ToArray(typeof(Contenuto2));
            DateTime[] arr_data = (DateTime[]) arrayData.ToArray(typeof(DateTime));

            if( arr_cont.Length != arr_data.Length)
            {
                Console.WriteLine("Errore nelle dimensioni array");
            }else
            {

            for( cont = 0 ; cont < arr_cont.Length ; cont++)
            {
                testo += arr_cont[cont].Nome +" " +  arr_cont[cont].IDcontenuto + 
                    " " +arr_data[cont].ToString() + "\n\n"; 
            }
                this.richTextBox1.Text += testo;

            
            }
           }


        private void buttonChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStorico_Load(object sender, EventArgs e)
        {

        }

        
    }
}