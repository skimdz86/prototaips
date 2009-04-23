using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
using QuartzTypeLib;
using NHibernate;
using NHibernate.Cfg;
using RFIDlibrary;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace TalkingPaper.Postering
{
    class StampaTesto
    {
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();
        private Microsoft.Office.Interop.Word.Application Word;
        // stringa che contiene l'intero documento
        private string documentContents;
        private string stringToPrint;
        private string path;
        private NuovoComponente nuovo;
        
        public StampaTesto(string path, string tipo,NuovoComponente nuovo) {
            Word = new Microsoft.Office.Interop.Word.Application();
            this.path = path;
            this.nuovo = nuovo;
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
            if ((tipo.CompareTo(".doc")) == 0)
            {
                ReadWord();
            }
            else
            {
                ReadDocument();
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Height = 700;
            printPreviewDialog1.Width = 1000;
            printPreviewDialog1.ShowDialog();

        }

        private void ReadWord() {
            Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            object file = path;
            object nullobj = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref nullobj, ref nullobj, ref nullobj, 
                ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, 
                ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
            doc.ActiveWindow.Selection.WholeStory();
            doc.ActiveWindow.Selection.Copy();
            IDataObject data = Clipboard.GetDataObject();
            stringToPrint = data.GetData(DataFormats.Text).ToString();
            doc.Close(ref nullobj, ref nullobj, ref nullobj);
        }

        private void ReadDocument()
        {
            //string docName = "ciao.txt";
            //string docPath = @"d:\";
            int indice = path.LastIndexOf("\\");
            int lenght = path.Length - (indice + 1);
            string nome_file = path.Substring(indice + 1, lenght);
            printDocument1.DocumentName = nome_file;
            using (FileStream stream = new FileStream(path, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, nuovo.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, nuovo.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }

    }
}
