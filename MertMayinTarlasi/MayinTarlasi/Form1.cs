using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            butonuret();
        }

        private void butonuret()
        {
            flowLayoutPanel1.Controls.Clear();

            Random rnd = new Random();

            List<int> mayinlar = new List<int>();
            for (int i = 1; mayinlar.Count < 15; i++)
            {
                int sayi = rnd.Next(1, 69);
                if (!mayinlar.Contains(sayi))
                {
                    mayinlar.Add(sayi);
                }
            }


            for (int i = 1; i < 69; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(35, 35);
                btn.Text = i.ToString();

                if (mayinlar.Contains(i))
                {
                    btn.Tag = true;
                }
                else
                {
                    btn.Tag = false;
                }
                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        int secilen = 0;
        int bulunan = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            Button basilanButton = (Button)sender;
            bool mayin = (bool)basilanButton.Tag;
            secilen++;
            if(mayin)
            {
                basilanButton.BackColor = Color.Red;
                basilanButton.Enabled = false;
                MessageBox.Show("Mayın bulundu", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bulunan++;
                secilen--;
            }
            else
            {
                basilanButton.BackColor = Color.Yellow;
            }
            textBox1.Text = secilen.ToString();
            textBox2.Text = bulunan.ToString();

            if (bulunan>=15)
            {
                DialogResult dialog = MessageBox.Show("Mayınlar patladı.Devam etmek ister misiniz?", "Bilgilendirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                    {
                    butonuret();
                    bulunan = 0;
                    secilen = 0;
                    }
            }
        }
    }
}
