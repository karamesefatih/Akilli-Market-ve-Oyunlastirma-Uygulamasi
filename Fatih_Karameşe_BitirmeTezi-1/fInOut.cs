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
    public partial class fInOut : Form
    {
        public fInOut()
        {
            InitializeComponent();
        }
        public string gelirgider { get; set; }
        public string kullanıcı { get; set; }

        private void fInOut_Load(object sender, EventArgs e)
        {
            lGelirGider.Text = gelirgider + "İŞLEMİ YAPILIYOR";
        }
        public void bKaydet_Click(object sender, EventArgs e)
        {
            if (cÖdemeTürü.Text != "")
            {
                if (tNakit.Text != "" && tKart.Text != "")
                {
                    using(var db = new BitirmeEntities())
                    {
                        IslemOzet io = new IslemOzet();
                        io.IslemNo = 0;
                        io.Iade = false;
                        io.OdemeSekli = cÖdemeTürü.Text;
                        io.Nakit = İslemler.DoubleYap(tNakit.Text);
                        io.Kart = İslemler.DoubleYap(tKart.Text);
                        if (gelirgider == "GELİR")
                        {
                            io.Gelir = true;
                            io.Gider = false;
                        }
                        else
                        {
                            io.Gelir = false;
                            io.Gider = true;
                        }
                        io.AlisFiyatToplam = 0;
                        io.Açiklama = gelirgider + " - İşlemi " + tAciklama.Text;
                        io.Tarih = dbitis.Value;
                        io.Kullanıcı = kullanıcı;
                        db.IslemOzet.Add(io);
                        db.SaveChanges();
                        MessageBox.Show(gelirgider + " işlemi kaydedildi ");
                        tNakit.Text = "0";
                        tKart.Text = "0";
                        tAciklama.Clear();
                        cÖdemeTürü.Text = "";
                        fReport f = (fReport)Application.OpenForms["fReport"];
                        if (f != null)
                        {
                            f.btnKaydet_Click(null, null);
                        }
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Ödeme Türünü Belirtiniz");
            }
        }

        private void cÖdemeTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cÖdemeTürü.SelectedIndex == 0)
            {
                tNakit.Enabled = true;
                tKart.Enabled = false;
            }
            else if (cÖdemeTürü.SelectedIndex == 1)
            {
                tNakit.Enabled = false;
                tKart.Enabled = true;
            }
            else if (cÖdemeTürü.SelectedIndex == 2)
            {
                tNakit.Enabled = true;
                tKart.Enabled = true;
            }
            tNakit.Text = "0";
            tKart.Text = "0";
        }

        private void tAciklama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
