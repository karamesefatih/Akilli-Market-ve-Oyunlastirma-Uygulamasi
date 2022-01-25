using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fatih_Karameşe_BitirmeTezi_1
{
    public partial class fStok : DevExpress.XtraEditors.XtraForm
    {
        public fStok()
        {
            InitializeComponent();
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            using (var db = new BitirmeEntities())
            {
                if (cmbİslemTuru.Text != "")
                { 
                    string urungurubu = cmbUrunGrubu.Text;
                    if (cmbİslemTuru.SelectedIndex == 0)
                    {
                        if (rbTumu.Checked)
                        {
                            db.Urun.OrderBy(x => x.Miktar).Load();
                            gridSatışList.DataSource = db.Urun.Local.ToBindingList();
                        }else if (rbUrunGrubunaGore.Checked)
                        {
                            db.Urun.Where(x => x.UrunGrup == urungurubu).OrderBy(x => x.Miktar).Load();
                            gridSatışList.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Ürün Grubunu Seçiniz");
                        }
                    }
                    else if (cmbİslemTuru.SelectedIndex == 1)
                    {
                        DateTime baslangic = DateTime.Parse(Baslangıç.Value.ToShortDateString());
                        DateTime bitis = DateTime.Parse(Bitis.Value.ToShortDateString());
                        bitis = bitis.AddDays(1);
                        if (rbTumu.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x=> x.Tarih>=baslangic && x.Tarih<=bitis).Load();
                            gridSatışList.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else if (rbUrunGrubunaGore.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.UrunGrup.Contains(urungurubu)).Load();
                            gridSatışList.DataSource = db.StokHareket.Local.ToBindingList();

                        }
                        else 
                        {
                            MessageBox.Show("Lütfen Filtreleme Türünü Seçiniz");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen İşlem Türünü Seçiniz");
                }
            }
            İslemler.GridDüzenle(gridSatışList);
        }
        BitirmeEntities dbx = new BitirmeEntities();
        private void Stok_Load(object sender, EventArgs e)
        {
            cmbUrunGrubu.DisplayMember="UrunGrupAdı";
            cmbUrunGrubu.ValueMember = "ıd";
            cmbUrunGrubu.DataSource = dbx.UrunGrup.OrderBy(a => a.UrunGrupAdı).ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fMainStore login = new fMainStore();
            login.Show();
            this.Hide();
        }

        private void tbUrunAra_TextChanged(object sender, EventArgs e)
        {

            if (tbUrunAra.Text.Length >= 3)
            {
                string urunad = tbUrunAra.Text;
                using (var db=new BitirmeEntities())
                {
                    if (cmbİslemTuru.SelectedIndex == 0)
                    {
                        db.Urun.Where(x => x.UrunAd.Contains(urunad)).Load();
                        gridSatışList.DataSource = db.Urun.Local.ToBindingList();
                    }
                    else if (cmbİslemTuru.SelectedIndex == 1)
                    {
                        db.StokHareket.Where(x => x.UrunAd.Contains(urunad)).Load();
                        gridSatışList.DataSource = db.StokHareket.Local.ToBindingList();
                    }
                }
                İslemler.GridDüzenle(gridSatışList);
            }
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            if (cmbİslemTuru.SelectedIndex == 0)
            {
                Raporlar.Baslik = cmbİslemTuru.Text + " RAPORU";
                Raporlar.TarihBaslangic = Baslangıç.Value.ToShortDateString();
                Raporlar.TarihBitis = Bitis.Value.ToShortDateString();
                Raporlar.StokRaporu(gridSatışList);
            }
            else if (cmbİslemTuru.SelectedIndex == 1)
            {
                Raporlar.Baslik = cmbİslemTuru.Text + " RAPORU";
                Raporlar.TarihBaslangic = Baslangıç.Value.ToShortDateString();
                Raporlar.TarihBitis = Bitis.Value.ToShortDateString();
                Raporlar.StokIzlemeRaporu(gridSatışList);
            }

        }
    }
}