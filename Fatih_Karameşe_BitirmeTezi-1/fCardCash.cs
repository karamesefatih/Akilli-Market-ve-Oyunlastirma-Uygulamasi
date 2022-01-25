using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fatih_Karameşe_BitirmeTezi_1
{
    public partial class fCardCash : DevExpress.XtraEditors.XtraForm
    {
        public fCardCash()
        {
            InitializeComponent();
        }
        //nAKİT VERİLEN PARAYI GENEL TOPLAMDAN ÇIKARTTIM
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    hesapla();
                }
            }
        }

        private void KartNakit_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;
            if (b.Text == ",")
            {
                int virgul = textBox1.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    textBox1.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }

            }
            else
            {
                textBox1.Text += b.Text;
            }
        }
        private void hesapla()
        {
            fSellPage s = (fSellPage)Application.OpenForms["fSellPage"];
            double nakit = İslemler.DoubleYap(textBox1.Text);
            double geneltoplam = İslemler.DoubleYap(s.tbToplam.Text);
            double kart = geneltoplam - nakit;
            s.nakit.Text = nakit.ToString("C2");
            s.kart.Text = kart.ToString("C2");
            s.satışyap("Kart-Nakit");
            this.Hide();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                hesapla();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08)
            {
                e.Handled = true;
            }
        }
    }
}