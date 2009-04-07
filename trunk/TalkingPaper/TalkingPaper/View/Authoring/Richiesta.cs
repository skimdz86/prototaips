using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper.Authoring
{
    public partial class Richiesta : FormSchema
    {
        private AuthoringInsterting inserimento;
        private bool  modifica;
        /*private int id_vecchio;
        private int id_nuovo;
        private string nome_vecchio;
        private string nome_nuovo;*/

        public Richiesta(AuthoringInsterting inserimento)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, true);
            /*this.nome_nuovo = nome_nuovo;
            this.nome_vecchio = nome_vecchio;
            this.id_nuovo = id_nuovo;
            this.id_vecchio = id_vecchio;*/
            this.inserimento = inserimento;
        }

        private void Richiesta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            inserimento.Visible=true;
            modifica = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            inserimento.Visible = true;
            modifica = false;
        }

        public bool GetModifica() {
            return modifica;
        }
    }
}