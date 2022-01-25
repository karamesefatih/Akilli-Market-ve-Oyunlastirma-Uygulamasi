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
    public partial class fMainStore : DevExpress.XtraEditors.XtraForm
    {
        public fMainStore()
        {
            InitializeComponent();
        }

        private void bSatisİslemi_Click(object sender, EventArgs e)
        {
            fSellPage sellPage = new fSellPage();
            sellPage.lbKullanıcı.Text = lKullanici.Text;
            sellPage.Show();
            this.Hide();
        }

        private void bRaporlar_Click(object sender, EventArgs e)
        {
            fReport rapor = new fReport();
            rapor.lkullanıci.Text = lKullanici.Text;
            rapor.Show();
            this.Hide();
        }

        private void bStokTakibi_Click(object sender, EventArgs e)
        {
            fStok stok = new fStok();
            stok.lkullanıci.Text = lKullanici.Text;
            stok.Show();
            this.Hide();
        }

        private void ÜrünGiris_Click(object sender, EventArgs e)
        {
            fCreateProduct ürünEkle = new fCreateProduct();
            ürünEkle.lkullanıci.Text = lKullanici.Text;
            ürünEkle.Show();
            this.Hide();
        }

        private void bAyarlar_Click(object sender, EventArgs e)
        {
            fSettings ayarlar = new fSettings();
            ayarlar.lkullanici.Text = lKullanici.Text;
            ayarlar.Show();
            this.Hide();
        }

        private void bKullaniciDegistir_Click(object sender, EventArgs e)
        {
            fLogin login = new fLogin();
            login.Show();
            this.Hide();
        }

        private void bCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bFiyatGüncelle_Click(object sender, EventArgs e)
        {
            fUpdateCost fUpdateCost = new fUpdateCost();
            fUpdateCost.ShowDialog();
        }

        private void bYedekle_Click(object sender, EventArgs e)
        {
            İslemler.Backup();
        }
    }
}