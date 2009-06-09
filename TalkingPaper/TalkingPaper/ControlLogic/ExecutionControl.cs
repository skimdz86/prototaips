using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

namespace TalkingPaper.ControlLogic
{
    class ExecutionControl
    {
        private Form caller;
        private String lastRead = "";
        private Timer resetLastRead;
        private string documentContent;
        private Image immagine;
        private string coordinate;
        private char[] alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'Z' };

        /// <summary>
        /// Legge dalla base di dati la lista dei cartelloni salvati
        /// </summary>
        /// <returns></returns>
        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }

        /// <summary>
        /// Metodo per ottenere un cartellone specificandone il nome
        /// </summary>
        /// <param name="nomePoster"></param>
        /// <returns></returns>
        public Model.Poster getPoster(String nomePoster)
        {
            return Global.dataHandler.getPoster(nomePoster);
        }

        /// <summary>
        /// Metodo per salvare un cartellone nella base di dati
        /// </summary>
        /// <param name="poster"></param>
        /// <returns></returns>
        public bool salvaPoster(Model.Poster poster)
        {
            return Global.dataHandler.setPoster(poster);
        }

        /// <summary>
        /// Metodo per ottenere una griglia specificandone il nome
        /// </summary>
        /// <param name="nomeGriglia"></param>
        /// <returns></returns>
        public Model.Griglia getGriglia(String nomeGriglia)
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }

        /// <summary>
        /// Metodo per l'inizializzazione del reader. E' necessario fornire la form chiamante
        /// per poter attivare correttamente il delegato.
        /// </summary>
        /// <param name="caller"></param>
        /// <returns></returns>
        public bool inizializzaReader(Form caller)
        {
            Global.reader.readerStatusUpdate += statusUpdate;
            bool result = Global.reader.startRead();
            lastRead = "";
            resetLastRead = new Timer();
            resetLastRead.Interval = 8000;
            resetLastRead.Tick += reset;
            resetLastRead.Start();
            if (!result)
            {
                return false;
            }
            this.caller = caller;
            return true;
        }

        /// <summary>
        /// Delegato che invoca il metodo per la gestione di un dato letto dal reader
        /// </summary>
        /// <param name="id"></param>
        public void statusUpdate(string id)
        {
            if (caller != null)
            {
                if (caller is Execution.EsecuzioneCartelloneForm)
                    ((Execution.EsecuzioneCartelloneForm)caller).rfid_StatusUpdateEvent(id);
                else throw new Exception("Errore in ExecutionControl.statusUpdate");
            }
        }

        /// <summary>
        /// Termina la lettura dal reader
        /// </summary>
        public void stopReader()
        {
            resetLastRead.Stop();
            Global.reader.close();
        }

        /// <summary>
        /// Restituisce il contenuto associato ad un tag specificando il nome del cartellone
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Model.Contenuto getContenutoFromTag(String nomePoster, String tag)
        {
            return Global.dataHandler.getContenutoFromTag(nomePoster, tag);
        }

        /// <summary>
        /// Metodo che controlla se un dato letto dal reader è nuovo o è una ripetizione
        /// di un dato già letto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool verificaId(string id)
        {
            if (id.Equals(lastRead)) return false;
            else lastRead = id;

            return true;
        }

        /// <summary>
        /// Cancella l'indicazione sull'ultimo dato letto dal reader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void reset(object sender, EventArgs e)
        {
            lastRead = "";
        }

        /// <summary>
        /// Mostra l'anteprima di stampa di una immagine e di un documento di testo
        /// </summary>
        /// <param name="percorso"></param>
        public void anteprimaTestoImmagine(string percorsoTesto, string percorsoImmagine, int[] coordinate)
        {
            string tipo = percorsoTesto.Substring(percorsoTesto.Length - 3, 3);
            this.coordinate = alfabeto[coordinate[1] - 1].ToString() + coordinate[0];

            PrintDocument printDocument = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Height = 700;
            printPreviewDialog.Width = 1000;

            //testo
            documentContent = "";
            if (tipo.Equals("doc"))
            {
                Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                object file = percorsoTesto;
                object nullobj = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
                doc.ActiveWindow.Selection.WholeStory();
                doc.ActiveWindow.Selection.Copy();
                IDataObject data = Clipboard.GetDataObject();
                documentContent = data.GetData(DataFormats.Text).ToString();
                doc.Close(ref nullobj, ref nullobj, ref nullobj);
            }
            else
            {
                using (FileStream stream = new FileStream(percorsoTesto, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    documentContent = reader.ReadToEnd();
                }


            }

            //immagine

            immagine = Image.FromFile(percorsoImmagine);

            if (immagine.Width > immagine.Height)
            {
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4O", 842, 595);
            }


            printPreviewDialog.ShowDialog();
        }

        /// <summary>
        /// Mostra la scelta della opzioni di stampa per la stampa di una immagine e di un
        /// documento di testo
        /// </summary>
        /// <param name="percorso"></param>
        public void stampaTestoImmagine(string percorsoTesto, string percorsoImmagine, int[] coordinate)
        {
            string tipo = percorsoTesto.Substring(percorsoTesto.Length - 3, 3);
            this.coordinate = alfabeto[coordinate[1] - 1].ToString() + coordinate[0];

            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            printDialog.Document = printDocument;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;

            //testo
            documentContent = "";
            if (tipo.Equals("doc"))
            {
                Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                object file = percorsoTesto;
                object nullobj = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
                doc.ActiveWindow.Selection.WholeStory();
                doc.ActiveWindow.Selection.Copy();
                IDataObject data = Clipboard.GetDataObject();
                documentContent = data.GetData(DataFormats.Text).ToString();
                doc.Close(ref nullobj, ref nullobj, ref nullobj);
            }
            else
            {
                using (FileStream stream = new FileStream(percorsoTesto, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    documentContent = reader.ReadToEnd();
                }


            }

            //immagine

            immagine = Image.FromFile(percorsoImmagine);

            if (immagine.Width > immagine.Height)
            {
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4O", 842, 595);
            }


            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        /// <summary>
        /// Imposta un documento da stampare che deve contenere un testo del quale è specificato
        /// l'indirizzo e le coordinate nella griglia
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="percorso"></param>
        /// <param name="coordinate"></param>
        public void setDocumentTesto(PrintDocument printDocument, string percorso, int[] coordinate)
        {
            string tipo = percorso.Substring(percorso.Length - 3, 3);
            if (coordinate != null) 
                this.coordinate = alfabeto[coordinate[1] - 1].ToString() + coordinate[0];

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            documentContent = "";
            if (tipo.Equals("doc"))
            {
                Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                object file = percorso;
                object nullobj = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
                doc.ActiveWindow.Selection.WholeStory();
                doc.ActiveWindow.Selection.Copy();
                IDataObject data = Clipboard.GetDataObject();
                documentContent = data.GetData(DataFormats.Text).ToString();
                doc.Close(ref nullobj, ref nullobj, ref nullobj);
            }
            else
            {
                using (FileStream stream = new FileStream(percorso, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    documentContent = reader.ReadToEnd();
                }


            }
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4V", 595, 842);

        }

        /// <summary>
        /// Imposta un documento da stampare che deve contenere una immagine della quale è fornito
        /// il percorso e le coordinate nella griglia
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="percorso"></param>
        /// <param name="coordinate"></param>
        public void setDocumentImmagine(PrintDocument printDocument, string percorso, int[] coordinate)
        {
            printDocument.PrintPage += printDocument_PrintPage;
            if (coordinate != null)
                this.coordinate = alfabeto[coordinate[1] - 1].ToString() + coordinate[0];

            immagine = Image.FromFile(percorso);
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4V", 595, 842);
                       
        }

        /// <summary>
        /// Mostra la scelta della opzioni di stampa per la stampa di un documento di testo
        /// </summary>
        /// <param name="percorso"></param>
        /// <param name="coordinate"></param>
        public void stampaTesto(string percorso, int[] coordinate)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            setDocumentTesto(printDocument, percorso, coordinate);
            
            printDialog.Document = printDocument;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;

            DialogResult result = printDialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
            
        }

        /// <summary>
        /// Mostra l'anteprima di stampa di un documento di testo
        /// </summary>
        /// <param name="percorso"></param>
        /// <param name="coordinate"></param>
        public void anteprimaTesto(string percorso,int[] coordinate)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            setDocumentTesto(printDocument, percorso, coordinate);

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Height = 700;
            printPreviewDialog.Width = 1000;

            printPreviewDialog.ShowDialog();
        }

        /// <summary>
        /// Mostra la scelta della opzioni di stampa per la stampa di una immagine
        /// </summary>
        /// <param name="percorso"></param>
        /// <param name="coordinate"></param>
        public void stampaImmagine(string percorso, int[] coordinate)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            setDocumentImmagine(printDocument, percorso, coordinate);

            printDialog.Document = printDocument;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }

        }
        
        /// <summary>
        /// Mostra l'anteprima di stampa di una immagine
        /// </summary>
        /// <param name="percorso"></param>
        /// <param name="coordinate"></param>
        public void anteprimaImmagine(string percorso, int[] coordinate)
        {
            PrintDocument document = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            setDocumentImmagine(document, percorso, coordinate);

            printPreviewDialog.Document = document;
            printPreviewDialog.Height = 700;
            printPreviewDialog.Width = 1000;
            
            printPreviewDialog.ShowDialog();
        }

        /// <summary>
        /// Evento di rappresentazione della pagina da stampare
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDocument document = ((PrintDocument)sender);
            //viene stampata prima l'immagine
            if (immagine != null)
            {
                float width = immagine.Width;
                float height = immagine.Height;
                //Resize dell'immagine per entrare all'interno di mezzo foglio A4
                if (width > e.PageSettings.PaperSize.Width)
                {
                    height *= (1 - ((width - e.PageSettings.PaperSize.Width) / width));
                    width = e.PageSettings.PaperSize.Width;

                }
                if (immagine.Height > ( e.PageSettings.PaperSize.Height / 2)) 
                {
                    width *= (1 - ((height - (e.PageSettings.PaperSize.Height / 2)) / height));
                    height = e.PageSettings.PaperSize.Height / 2;
                }
                    

                e.Graphics.DrawImage(immagine, 40, 40, width, height);

                
                if (Global.isNotEmpty(documentContent))
                {
                    //se dopo la stampa resta spazio nella pagina stampo anche il testo nella stessa pagina
                    if (height < e.PageSettings.PaperSize.Height)
                    {
                        int charactersOnPage = 0;
                        int linesPerPage = 0;
                        e.Graphics.MeasureString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        new SizeF(e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - (height + 40 + 50) - 80), StringFormat.GenericTypographic,
                        out charactersOnPage, out linesPerPage);
                        //se riesco a stampare tutto
                        if (charactersOnPage == documentContent.Length)
                        {
                            e.Graphics.DrawString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black,
                    new Rectangle(40, (int)height + 40 + 50, e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - ((int)height + 40 + 50) - 80) , StringFormat.GenericTypographic);
                            e.HasMorePages = false;
                        }
                        else
                        {
                            //se il testo è troppo lungo comincio in una nuova pagina
                            e.HasMorePages = true;
                        }
                        
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                }
                immagine.Dispose();
                immagine = null;
            }

            else if (Global.isNotEmpty(documentContent))
            {
                
                int charactersOnPage = 0;
                int linesPerPage = 0;
                string backup = documentContent;

                // Sets the value of charactersOnPage to the number of characters 
                // of stringToPrint that will fit within the bounds of the page.
                e.Graphics.MeasureString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    new SizeF(e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - 80), StringFormat.GenericTypographic,
                    out charactersOnPage, out linesPerPage);

                // Draws the string within the bounds of the page.
                e.Graphics.DrawString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black,
                new Rectangle(40, 40, e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - 80), StringFormat.GenericTypographic);

                
                // Remove the portion of the string that has been printed.
                documentContent = documentContent.Substring(charactersOnPage);

                // Check to see if more pages are to be printed.
                e.HasMorePages = (documentContent.Length > 0);

                // If there are no more pages, reset the string to be printed.
                if (!e.HasMorePages)
                    documentContent = backup;
            }
            //stampo le coordinate alla fine
            if (Global.isNotEmpty(coordinate))
            {
                e.Graphics.DrawString(coordinate, new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - 80));
            }
        }

        

    }
}
