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

        public List<Model.Griglia> leggiGriglie()
        {
            return Global.dataHandler.getListaGriglie();
        }

        public Model.Griglia getGriglia(String nomeGriglia)
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }
        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }
        public Model.Poster getPoster(String nomePoster) 
        {
            return Global.dataHandler.getPoster(nomePoster);
        }
        public bool salvaPoster(Model.Poster poster) 
        {
            return Global.dataHandler.setPoster(poster);
        }

        public int getIndexFromNomeContenuto(List<Model.Contenuto> lista, string nome)
        {
            int index;
            for (index = 0; index < lista.Count; index++)
            {
                if (lista[index].getNomeContenuto().Equals(nome)) return index;
            }
            return -1;
        }

        public Model.Contenuto getContenutoFromNome(List<Model.Contenuto> lista, string nome)
        {
            foreach (Model.Contenuto contenuto in lista)
            {
                if (contenuto.getNomeContenuto().Equals(nome)) return contenuto;
            }
            return null;
        }

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

        public void setDocumentImmagine(PrintDocument printDocument, string percorso)
        {
            printDocument.PrintPage += printDocument_PrintPage;

            
            immagine = Image.FromFile(percorso);

            if ((immagine.Width > 842) && (immagine.Width > immagine.Height))
            {
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4O", 842, 595);
            }
            
        }

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


        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDocument document = ((PrintDocument)sender);
            if (immagine != null)
            {
                float width = immagine.Width;
                float height = immagine.Height;
                if (width > e.PageSettings.PaperSize.Width)
                {
                    height *= (1 - ((width - e.PageSettings.PaperSize.Width) / width));
                    width = e.PageSettings.PaperSize.Width;

                }
                if (immagine.Height > e.PageSettings.PaperSize.Height)
                {
                    width *= (1 - ((height - e.PageSettings.PaperSize.Height) / height));
                    height = e.PageSettings.PaperSize.Height;
                }


                e.Graphics.DrawImage(immagine, 0, 0, width, height);

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
                    e.MarginBounds.Size, StringFormat.GenericTypographic,
                    out charactersOnPage, out linesPerPage);

                // Draws the string within the bounds of the page.
                e.Graphics.DrawString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);


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
