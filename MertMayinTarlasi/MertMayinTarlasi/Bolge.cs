using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MertMayinTarlasi
{
    class Bolge : Button, IComparable
    {
        private int koordinatX;
        private int koordinatY;

        public int KoordinatX { get { return koordinatX; } }
        public int KoordinatY { get { return koordinatY; } }

        private bool mayinliMi;
        public bool MayinliMi {  get {  return mayinliMi;  } }

        private bool bayrakVarmi;
        public bool BayrakVarMi { get { return bayrakVarmi; } }

        private bool acildiMi;
        public bool AcildiMi {  get { return acildiMi;} }


        public Bolge(Point p, int koorX, int koorY)
        {
            this.Width = 37;
            this.Height = 37;
            this.Location = p;
            koordinatX = koorX;
            koordinatY = koorY;

            bayrakVarmi = false;
        }

        public void bayrakDurumunuDegistir()
        {
            bayrakVarmi = !bayrakVarmi;

            if (bayrakVarmi)
                this.Image = Properties.Resources.Bayrak;
            else
                this.Image = null;
        }
        public void mayinYerlestir()
        {
            mayinliMi = true;
        }

        public void bolgeyiAc (int cevresindekiMayinSayisi)
        {
            if (cevresindekiMayinSayisi != 0)
            {
                this.Text = cevresindekiMayinSayisi.ToString();
                this.Font = new Font(FontFamily.GenericSerif, 20, FontStyle.Bold);
            }
            this.Enabled = false;
            this.acildiMi = true;

        }


        public void bolgeyiAc()
        {
            if (mayinliMi)
            { 
                this.Image = Properties.Resources.bombaBayrakli;
            else
                this.Image = Properties.Resources.bombaPatlamayan;
        }
            else
        {
                if (bayrakVarmi)
                    this.Image = Properties.Resources.yanlisTahmin;
                else
                    this.Enabled = false;
        }
            this.acildiMi = true;
        }


        public void bolgetyiPatlat()
        {
            this.Image = Properties.Resources.bombaTiklanan;
            acildiMi = true;
        }

        public int Compareto(object obj)
        {
            if (this.koordinatX == (obj as Bolge).koordinatX && this.koordinatY == (obj as Bolge).koordinatY)
                return 0;
            else
                return -1;
        }








    }

}