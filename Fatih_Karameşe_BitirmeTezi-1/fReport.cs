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
    public partial class fReport : DevExpress.XtraEditors.XtraForm
    {
        public fReport()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fMainStore login = new fMainStore();
            login.Show();
            this.Hide();
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            tKomisyon.Text = İslemler.KartKomisyon().ToString();
            btnKaydet_Click(null, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void btnKaydet_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime baslangıc = DateTime.Parse(Baslangıç.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(dbitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            using (var db = new BitirmeEntities() )
            {
                if (listBox1.SelectedIndex == 0) //Tümünü getir
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis).OrderByDescending(x => x.Tarih).Load();
                    var islemOzet = db.IslemOzet.Local.ToBindingList();
                    gridSatışList.DataSource = islemOzet;

                    tSatısNakit.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Nakit)).ToString("C2");
                    tSatısKart.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(s => s.Kart)).ToString("C2");

                    tİadeNakit.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    tİadeKart.Text = Convert.ToDouble(islemOzet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");

                    tGelirKart.Text = Convert.ToDouble(islemOzet.Where(X => X.Gelir == true).Sum(s => s.Kart)).ToString("c2");
                    tGelirNakit.Text = Convert.ToDouble(islemOzet.Where(X=>X.Gelir== true).Sum(s=>s.Nakit)).ToString("c2");

                    tGiderKart.Text = Convert.ToDouble(islemOzet.Where(X => X.Gider == true).Sum(s => s.Kart)).ToString("c2");
                    tGiderNakit.Text = Convert.ToDouble(islemOzet.Where(X => X.Gider == true).Sum(s => s.Nakit)).ToString("c2");

                    db.Satis.Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis).Load();
                    var satistablosu = db.Satis.Local.ToBindingList();
                    double kdvtutarı = İslemler.DoubleYap(satistablosu.Where(x => x.İade == false).Sum(x => x.KdvTutari).ToString());
                    double kdvtutariiade = İslemler.DoubleYap(satistablosu.Where(x => x.İade == true).Sum(x => x.KdvTutari).ToString());
                    tKDV.Text = (kdvtutarı - kdvtutariiade).ToString("c2");
                }
                else if(listBox1.SelectedIndex==1)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis && x.Iade == false && x.Gelir == false && x.Gider == false).Load();
                    var islemözet = db.IslemOzet.Local.ToBindingList();
                    gridSatışList.DataSource = islemözet;
                }
                else if (listBox1.SelectedIndex == 2)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis && x.Iade == true).Load();
                    var islemözet = db.IslemOzet.Local.ToBindingList();
                    gridSatışList.DataSource = islemözet;
                }
                else if (listBox1.SelectedIndex == 3)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis && x.Gelir == true).Load();
                    var islemözet = db.IslemOzet.Local.ToBindingList();
                    gridSatışList.DataSource = islemözet;
                }
                else if (listBox1.SelectedIndex == 4)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangıc && x.Tarih <= bitis && x.Gider == true).Load();
                    var islemözet = db.IslemOzet.Local.ToBindingList();
                    gridSatışList.DataSource = islemözet;
                }
            }
            İslemler.GridDüzenle(gridSatışList);
            Cursor.Current = Cursors.Default;


        }

        private void gridSatışList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2 || e.ColumnIndex==6 | e.ColumnIndex==7)
            {
                if(e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Evet" : "Hayır";
                        e.FormattingApplied = true;
                }
            }
        }

        private void bGelirEkle_Click(object sender, EventArgs e)
        {
            fInOut fInOut = new fInOut();
            fInOut.gelirgider = "GELİR";
            fInOut.kullanıcı = lKullanıcı.Text;
            fInOut.ShowDialog();
        }

        private void bGiderEkle_Click(object sender, EventArgs e)
        {
            fInOut fInOut = new fInOut();
            fInOut.gelirgider = "GİDER";
            fInOut.kullanıcı = lKullanıcı.Text;
            fInOut.ShowDialog();
        }

        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridSatışList.Rows.Count > 0)
            {
                int islemno = Convert.ToInt32(gridSatışList.CurrentRow.Cells["IslemNo"].Value.ToString());
                if (islemno != 0)
                {
                    fShowDetails f = new fShowDetails();
                    f.islemno = islemno;
                    f.ShowDialog();

                }

            }
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            Raporlar.Baslik = "GENEL RAPOR";
            Raporlar.SatisKart = tSatısKart.Text;
            Raporlar.SatisNakit = tSatısNakit.Text;
            Raporlar.İadeKart = tİadeNakit.Text;
            Raporlar.İadeNakit = tİadeNakit.Text;
            Raporlar.GelirKart = tGelirKart.Text;
            Raporlar.GelirNakit = tGelirNakit.Text;
            Raporlar.GiderKart = tGiderKart.Text;
            Raporlar.GiderNakit = tGiderNakit.Text;
            Raporlar.TarihBaslangic = Baslangıç.Value.ToShortDateString();
            Raporlar.TarihBitis = dbitis.Value.ToShortDateString();
            Raporlar.KdvToplam = tKDV.Text;
            Raporlar.KartKomisyon = tKomisyon.Text;
            Raporlar.RaporSayfasiRaporu(gridSatışList);
        }
    }
}