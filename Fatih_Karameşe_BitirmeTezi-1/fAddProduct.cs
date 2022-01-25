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
    public partial class fAddProduct : DevExpress.XtraEditors.XtraForm
    {
        public fAddProduct()
        {
            InitializeComponent();
        }
        BitirmeEntities db = new BitirmeEntities();
        private void tbUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (tbUrunAra.Text != "")
            {
                string urunad = tbUrunAra.Text;
                var urunler = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                gridUrun.DataSource = urunler;
            }

        }

        private void gridUrun_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUrun.Rows.Count > 0)
            {
                string barkod = gridUrun.CurrentRow.Cells["Barkod"].Value.ToString();
                string UrunAdı = gridUrun.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat = Convert.ToDouble(gridUrun.CurrentRow.Cells["SatisFiyat"].Value.ToString());
                int id = Convert.ToInt16(BUTONID.Text);
                var guncelleme = db.HizliUrun.Find(id);
                guncelleme.Barkod = barkod;
                guncelleme.UrunAd = UrunAdı;
                guncelleme.Fıyat = fiyat;
                db.SaveChanges();
                MessageBox.Show("Buton Tanımlandı");
                //Maşn Page ile aynı buton atamayı yaptım
                fSellPage mainPage = (fSellPage)Application.OpenForms["SellPage"];
                if (mainPage != null)
                {
                    SimpleButton b = mainPage.Controls.Find("bh" + id, true).FirstOrDefault() as SimpleButton;
                    b.Text = UrunAdı + "\n" + fiyat.ToString("C2");
                }
            }
        }

        private void cbGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGoster.Checked)
            {
                 gridUrun.DataSource = db.Urun.ToList();
                İslemler.GridDüzenle(gridUrun);
            }
            else
            {
                gridUrun.DataSource = null;
            }
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            var urunler = db.Urun.ToList();
            gridUrun.DataSource = urunler;
        }
    }
}