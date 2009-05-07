using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TalkingPaper.Common;

namespace TalkingPaper.Config
{
    public partial class FormRfidConfig : Common.FormSchema
    {
        private Reader.IReader reader;
        private Administration.AdminHomeForm amministrazione;
        /**
         * 
         * Nella FormRfidConfig mettere dei controlli se ciò che è inserito è corretto: 
         * ricorda errore non gestito se metti COM4 invece che 4 !!!
         * 
         * */
        public FormRfidConfig(Administration.AdminHomeForm amministrazione, string directory_principale)
        {
            InitializeComponent();
            RidimensionaForm n = new RidimensionaForm(this, 90, false);
            string currentPath = Directory.GetCurrentDirectory();
            this.amministrazione = amministrazione;
            //cfgmng = new Config_manager(currentPath);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            amministrazione.Visible = true;
            this.Close();
        }

        private void config_button_Click(object sender, EventArgs e)
        {
            //Prima di salvare i dati dovrei fare un controllo degli stessi...

            //devo fare in modo che qua si salvi il file xml dei dati inseriti
            //  Ma come posso fare per capire se almeno una volta è stato settato??


            if(reader.saveConfiguration(port_number_val.Text, cFrame_val.Text, bRate_val.Text, to_val.Text))
            {
                Console.WriteLine("File di Rfid Configurazione scritto correttamente");
                MessageBox.Show("Scrittura File","File di Rfid Configurazione scritto correttamente", MessageBoxButtons.OK , MessageBoxIcon.Information);
                //prova di lettura
                //cfgmng.read_config_rfid_xml();
                amministrazione.Visible = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("ERRORE","Errore nella creazione, prova a reinserire i dati",MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Apertura della finestra FormRfidConfigHelp");
            FormRfidConfigHelp fh = new FormRfidConfigHelp(this);
            //fh.Activate(); 
            fh.Show();

           this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             * Devo verificare che l'RFID Reader sia connesso correttamente
             * */
            int handlerRfid;

            this.labelOK.Visible = false;
            this.labelNO.Visible = false;
            this.labelNO2.Visible = false;
            this.Button_Salva.Enabled = false;
            try
            {
                handlerRfid = Global.reader.connect();
                //handlerRfid = reader.configure(Convert.ToInt32(port_number_val.Text), cFrame_val.Text, bRate_val.Text, (short)Convert.ToInt16(to_val.Text));
                if (handlerRfid <= 0)
                {
                    Console.WriteLine("Connessione NON avvenuta!!!!Hanlder = " + handlerRfid);
                    this.labelNO.Visible = true;
                    this.labelNO2.Visible = true;
                    this.Button_Salva.Enabled = false;
                }
                else
                {
                    Console.WriteLine("Connessione avvenuta con successo, con hanlder = " + handlerRfid);
                    this.labelOK.Visible = true;
                    this.Button_Salva.Enabled = true;
                }
            }catch(System.FormatException format_ex)
            {
                Console.WriteLine("Errore di inserimento nella form\nmessagge = " + format_ex.Message);
                MessageBox.Show("Errore di inserimento dati nella form, prego rinserire",format_ex.Message
                ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.buttonHelp.Visible = true;
            }

        }

        private void Port_n_Leave(object sender, EventArgs e)
        {
            //Verifico che sia stato inserito un valore corretto...inizio dalla port number
            try
            {
                Console.WriteLine("E' stato immesso per Port Number il valore " + this.port_number_val.Text + "\nConverto " + Convert.ToInt32(port_number_val.Text));
                this.buttonTestConnection.Enabled = true;
            }
            catch (FormatException format_ex)
            {
                Console.WriteLine("Errore di inserimento nella form\nmessagge = " + format_ex.Message);
                MessageBox.Show("Errore di inserimento dati nella form, prego rinserire", format_ex.Message
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.buttonTestConnection.Enabled = false;
                this.buttonHelp.Visible = true;
                this.buttonHelp.Focus();

                this.buttonHelp.Focus();

            }
            /*
             * Devo controllare che siano solo interi...come fare???
             * 
             * if( controllo corretto )
             *                   this.buttonTestConnection.Enabled = true;
             * else
             *  messaggio di errore...
             * */

        }

        private void On_Enter(object sender, EventArgs e)
        {
           Console.WriteLine("La FormRfidConfig si sta attivando, voglio il focus sul PortNumber");
            this.port_number_val.Focus();
        }

        private void FormRfidConfig_Load(object sender, EventArgs e)
        {
        }


    }
}