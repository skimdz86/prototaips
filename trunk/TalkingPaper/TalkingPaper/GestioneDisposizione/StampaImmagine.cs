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
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace TalkingPaper.GestioneDisposizione
{
    class StampaImmagine
    {
        private string path;
        //private Image nuova;
        private PrintDocument doc;
        private Image nuova1;
        private int width;
        private int height;
        private string directory;
        private string directory_temporanea;
        private string estensione;
        private string coordinate;
        //private PaperSize verticale = new PaperSize("A4V",21,29);
        //private PaperSize orizzontale = new PaperSize("A4O", 29, 21);

        public StampaImmagine(string path,string coordinate)
        {
            this.path = path;
            int ind = path.LastIndexOf("\\");
            int ind2 = path.LastIndexOf("/");
            int indice;
            this.coordinate = coordinate;
            if (ind >= ind2)
            {
                indice = ind;
            }
            else
            {
                indice = ind2;
            }
            directory = path.Substring(0, indice + 1);
            this.directory_temporanea = directory + @"Temp";
            System.IO.Directory.CreateDirectory(directory_temporanea);
            estensione = path.Substring(path.Length - 3);
            doc = new PrintDocument();
            PreviewImmagine_Click();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // System.Drawing.Font font = new System.Drawing.Font("Arial", 30);
            //float x = e.MarginBounds.Left;
            //float y = e.MarginBounds.Top;
            PointF f;
            e.Graphics.DrawImage(nuova1, 0, 0);
            NuovoComponente nuovo = new NuovoComponente();
            if (doc.DefaultPageSettings.PaperSize.Width > doc.DefaultPageSettings.PaperSize.Height)
            {
                f = new PointF(100, 540);
            }
            else
            {
                f = new PointF(100, 840);
            }
            //e.Graphics.DrawString("Ciao", nuovo.Font, Brushes.Black,
            //e.MarginBounds, StringFormat.GenericTypographic);
            if (coordinate != null)
            {
                e.Graphics.DrawString("Coordinate: " + coordinate, nuovo.Font, Brushes.Black, f);
            }
        }

        private void PreviewImmagine_Click()
        {
            //Image nuova1;
            //nuova1 = Image.FromFile(path);
            ControllaDimensioni();
            //doc.PrintPage += this.Doc_PrintPage;
            if ((height >= 500) || (width >= 800))
            {
                /*int altezza = height;
                int larghezza = width;
                while ((altezza >= 500) || (larghezza >= 800)) {
                    altezza = altezza - 10;
                    larghezza = larghezza - 10;
                }*/
                float al = height;
                float lar = width;
                double rap;
                int larghezza;
                int altezza;
                if (height >= width)
                {
                    rap = lar / al;
                    altezza = 790;
                    larghezza = (int)(altezza * rap);
                    while (larghezza >= 540)
                    {
                        altezza = altezza - 10;
                        larghezza = (int)(altezza * rap);
                    }
                }
                else
                {
                    rap = al / lar;
                    larghezza = 790;
                    altezza = (int)(larghezza * rap);
                    while (altezza >= 500)
                    {
                        larghezza = larghezza - 10;
                        altezza = (int)(larghezza * rap);
                    }
                }

                FileStream file = new FileStream(path, FileMode.Open);
                //file.Close();
                path = ResizeAndSave(file, larghezza, altezza, path, file);
                //file.Close();
                nuova1 = Image.FromFile(path);
            }
            nuova1 = Image.FromFile(path);
            doc.PrintPage += this.Doc_PrintPage;
            if (nuova1.Width > nuova1.Height)
            {
                PaperSize paper = new PaperSize("A4O", 842, 595);
                doc.DefaultPageSettings.PaperSize = paper;
            }
            //doc.Print();
            PrintPreviewDialog dl = new PrintPreviewDialog();
            dl.Document = doc;
            dl.Width = 900;
            dl.Height = 500;
            dl.ShowDialog();
            nuova1.Dispose();
            if (System.IO.Directory.Exists(directory_temporanea))
            {
                System.IO.Directory.Delete(directory_temporanea, true);
            }
        }

        private string ResizeAndSave(Stream imgStr, int Width, int Height, string FileName, FileStream file)
        {
            //creo il bitmap dallo stream

            System.Drawing.Image bmpStream = System.Drawing.Image.FromStream(imgStr);
            file.Close();
            //creo un nuovo bitmap ridimensionandolo

            Bitmap img = new Bitmap(bmpStream, new Size(Width, Height));
            //salvo l'immagine ridimensionata

            //img.Save("D:\\Documents and Settings\\IO\\Documenti\\IO\\prov", System.Drawing.Imaging.ImageFormat.Jpeg);
            string nuovo_pa = directory_temporanea + "\\temp1." + estensione;
            img.Save(directory_temporanea + "\\temp1." + estensione);
            return nuovo_pa;
            //Response.Write("fatto!");
        }

        private void ControllaDimensioni()
        {
            Image nuova;
            nuova = Image.FromFile(path);
            width = nuova.Width;
            height = nuova.Height;
            nuova.Dispose();
        }

    }
}