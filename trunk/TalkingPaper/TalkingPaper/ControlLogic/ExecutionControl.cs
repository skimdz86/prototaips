﻿using System;
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

        private ArrayList idInseriti = new ArrayList();

        public List<Model.Poster> getListaPoster()
        {
            return Global.dataHandler.getListaPoster();
        }

        public Model.Poster getPoster(String nomePoster)
        {
            return Global.dataHandler.getPoster(nomePoster);
        }

        public Model.Griglia getGriglia(String nomeGriglia)
        {
            return Global.dataHandler.getGriglia(nomeGriglia);
        }

        public bool inizializzaReader(Form caller)
        {
            Global.reader.readerStatusUpdate += statusUpdate;
            bool result = Global.reader.startRead();
            lastRead = "";
            resetLastRead = new Timer();
            resetLastRead.Interval = 5000;
            resetLastRead.Tick += reset;
            resetLastRead.Start();
            if (!result)
            {
                return false;
            }
            this.caller = caller;
            return true;
        }

        public void statusUpdate(string id)
        {
            if (caller != null)
            {
                if (caller is Execution.EsecuzioneCartelloneForm)
                    ((Execution.EsecuzioneCartelloneForm)caller).rfid_StatusUpdateEvent(id);
                else throw new Exception("Errore in ExecutionControl.statusUpdate");
            }
        }

        public void stopReader()
        {
            resetLastRead.Stop();
            Global.reader.close();
        }

        public Model.Contenuto getContenutoFromTag(String nomePoster, String tag)
        {
            return Global.dataHandler.getContenutoFromTag(nomePoster, tag);
        }

        public bool verificaId(string id)
        {
            if (id.Equals(lastRead)) return false;
            else lastRead = id;

            return true;
        }

        public void reset(object sender, EventArgs e)
        {
            lastRead = "";
        }


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

        public void setDocumentTesto(PrintDocument printDocument, string percorso, int[] coordinate)
        {
            string tipo = percorso.Substring(percorso.Length - 3, 3);
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

        }

        public void setDocumentImmagine(PrintDocument printDocument, string percorso, int[] coordinate)
        {
            printDocument.PrintPage += printDocument_PrintPage;

            this.coordinate = alfabeto[coordinate[1] - 1].ToString() + coordinate[0];
            immagine = Image.FromFile(percorso);

            if (immagine.Width > 827)
            {
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4O", 842, 595);
            }
        }

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

                if (Global.isNotEmpty(documentContent))
                {
                    if (height < e.PageSettings.PaperSize.Height)
                    {
                        int charactersOnPage = 0;
                        int linesPerPage = 0;
                        e.Graphics.MeasureString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        new SizeF(e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height - (height + 50)), StringFormat.GenericTypographic,
                        out charactersOnPage, out linesPerPage);
                        if (charactersOnPage == documentContent.Length)
                        {
                            e.Graphics.DrawString(documentContent, new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black,
                    new PointF(e.MarginBounds.Left, height + 50), StringFormat.GenericTypographic);
                            e.HasMorePages = false;
                        }
                        else
                        {
                            e.HasMorePages = true;
                            document.DefaultPageSettings.PaperSize = new PaperSize("A4V", 595, 842);
                            e.PageSettings.PaperSize = new PaperSize("A4V", 595, 842);
                        }
                        
                    }
                    else
                    {
                        e.HasMorePages = true;
                        document.DefaultPageSettings.PaperSize = new PaperSize("A4V", 595, 842);
                        e.PageSettings.PaperSize = new PaperSize("A4V", 595, 842);
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

            if (Global.isNotEmpty(coordinate))
            {
                e.Graphics.DrawString(coordinate, new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(e.PageSettings.PaperSize.Width - 80, e.PageSettings.PaperSize.Height - 80));
            }
        }

        

    }
}
