using System;
using System.Collections.Generic;
using System.Text;
using TalkingPaper.Common;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TalkingPaper.ControlLogic
{
    class AuthoringControl
    {
        String documentContent;
        Image immagine;

        /// <summary>
        /// Legge dalla base di dati la lista delle griglie salvate
        /// </summary>
        /// <returns></returns>
        public List<Model.Griglia> leggiGriglie()
        {
            return Global.dataHandler.getListaGriglie();
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
        /// Restituisce l'indice del contenuto con nome specificato all'interno della lista
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public int getIndexFromNomeContenuto(List<Model.Contenuto> lista, string nome)
        {
            int index;
            for (index = 0; index < lista.Count; index++)
            {
                if (lista[index].getNomeContenuto().Equals(nome)) return index;
            }
            return -1;
        }

        /// <summary>
        /// Restituisce un contenuto tra quelli all'interno di una lista, di cui si specifica
        /// il nome
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Model.Contenuto getContenutoFromNome(List<Model.Contenuto> lista, string nome)
        {
            foreach (Model.Contenuto contenuto in lista)
            {
                if (contenuto.getNomeContenuto().Equals(nome)) return contenuto;
            }
            return null;
        }

        /// <summary>
        /// Imposta un documento da stampare che deve contenere un testo del quale è specificato
        /// l'indirizzo
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="percorso"></param>
        public void setDocumentTesto(PrintDocument printDocument, string percorso)
        {
            string tipo = percorso.Substring(percorso.Length - 3, 3);
            

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

        }

        /// <summary>
        /// Imposta un documento da stampare che deve contenere una immagine della quale è fornito
        /// il percorso
        /// </summary>
        /// <param name="printDocument"></param>
        /// <param name="percorso"></param>
        public void setDocumentImmagine(PrintDocument printDocument, string percorso)
        {
            printDocument.PrintPage += printDocument_PrintPage;

            
            immagine = Image.FromFile(percorso);

            
        }

        /// <summary>
        /// Mostra l'anteprima di stampa di un documento di testo
        /// </summary>
        /// <param name="percorso"></param>
        public void anteprimaTesto(string percorso)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            setDocumentTesto(printDocument, percorso);

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Height = 700;
            printPreviewDialog.Width = 1000;

            printPreviewDialog.ShowDialog();
        }

        /// <summary>
        /// Mostra l'anteprima di stampa di una immagine
        /// </summary>
        /// <param name="percorso"></param>
        public void anteprimaImmagine(string percorso)
        {
            PrintDocument document = new PrintDocument();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            setDocumentImmagine(document, percorso);

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
            //stampo prima l'immagine
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
                if (immagine.Height > (e.PageSettings.PaperSize.Height / 2))
                {
                    width *= (1 - ((height - (e.PageSettings.PaperSize.Height / 2)) / height));
                    height = e.PageSettings.PaperSize.Height / 2;
                }


                e.Graphics.DrawImage(immagine, 40, 40, width, height);

                immagine.Dispose();
                immagine = null;
            }
            //stampo il testo
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

            
        }
    }
}
