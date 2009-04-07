using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkingPaper
{
    class RidimensionaForm
    {
        private Screen schermo;
        private Rectangle res;
        private double resV;
        private double resO;
        private double FV;
        private double FO;
        private double rapportoHV;
        private double rapV;
        private double rapO;
        private Boolean LavoraSulVerticale;
        private Single k;
        private SizeF nuovo_size;

        public RidimensionaForm(Form f, int percentuale, bool ridimensiona)
        {
            schermo = Screen.FromRectangle(f.Bounds);
            res = schermo.WorkingArea;
            resV = res.Height;
            resO = res.Width;
            FV = f.Height;
            FO = f.Width;

            if (FO == 1036.0)
            { // se la risoluzione è più piccola di quella della finestra viene impostato il valore max
                FO = 1200.0;
                FV = 775.0;
            }

            //la finestra è stata progettata con risoluzione 1280x800

            double dimV = (FV * resV) / 800;
            double dimO = (FO * resO) / 1280;

            
            //trovo i rapporti per scalare la form
            rapV = dimV/FV; //percentuale di schermo occupata dalla form in verticale
            rapO = dimO / FO; //percentuale di schermo occupata dalla form in orizzontale

            if (rapO > 1) //la finestra è più grande dello schermo
            {
                rapO = (1 / rapO);
                rapV = (1 / rapV);
            }
            nuovo_size = new SizeF((float)rapO, (float)rapV);
            

            f.Scale(nuovo_size);
            if (ridimensiona == true)
            {
                ApplicaRidimensionamentoAiFont(f, nuovo_size);
            }


            f.Size = new Size((int)dimO, (int)dimV);


/*            if (rapV >= rapO)
            {
                LavoraSulVerticale = true;
            }
            else
                LavoraSulVerticale = false;
            if (LavoraSulVerticale == true)
            {
                // k = Convert.ToSingle(percentuale / (rapV * 100));
                k =(float)(global.percentScale * rapV);
            }
            else
            {
                k = (float)(global.percentScale * rapO);
                //k = Convert.ToSingle(percentuale / (rapO * 100));
            }
            k = global.percentScale;
            nuovo_size = new SizeF(k, k);
            f.Scale(nuovo_size);
            if (ridimensiona == true)
            {
                ApplicaRidimensionamentoAiFont(f, k);
            }
             
           

            SizeF percent = new SizeF(global.percentScale, global.percentScale);
            f.Scale(percent);
            if (ridimensiona == true)
            {
                ApplicaRidimensionamentoAiFont(f, percent);
            }
            */
        }

        private void ApplicaRidimensionamentoAiFont(Form f,SizeF percent)
        {
            foreach (Control c in f.Controls)
            {
                CambiaFontDelControllo(c, percent.Width);
            }
        }



        private void CambiaFontDelControllo(Control c, Single k)
        {
            c.Font = new Font(c.Font.FontFamily, c.Font.Size * k, c.Font.Style, c.Font.Unit);
            foreach (Control ct in c.Controls)
            {
                CambiaFontDelControllo(ct, k);
            }
        }

        public static void ReScaleControl(Control c,float ResizeFactor)
        {
            c.Font = new Font(c.Font.FontFamily, c.Font.Size * ResizeFactor, c.Font.Style, c.Font.Unit);
            c.Scale(new SizeF(ResizeFactor, ResizeFactor));
            foreach (Control ct in c.Controls) //ripeto la stessa operazione per i controlli dentro a questo
            {
                ReScaleControl(ct, ResizeFactor);
            }

        }
        public static void ReScaleTab(DataGridView d, float ResizeFactor)
        {
            d.Scale(new SizeF(ResizeFactor, ResizeFactor));
            d.RowHeadersWidth = (int)(d.RowHeadersWidth * ResizeFactor);
            d.ColumnHeadersHeight = (int)(d.ColumnHeadersHeight * 0.3);
            for (int i = 0; i < d.ColumnCount; i++)
                for (int j = 0; j < d.RowCount; j++)
                {
                    //d[i, j].Size = new Size((int)(d[i, j].Size.Width * ResizeFactor), (int)(d[i, j].Size.Width * ResizeFactor));
                    
                    d[i, j].Style.Font=new Font(d.Font.FontFamily, d.Font.Size * (ResizeFactor+(float)0.1), d.Font.Style, d.Font.Unit);    
                }

        }

    }
}

