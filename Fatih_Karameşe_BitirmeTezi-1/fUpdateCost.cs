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
    public partial class fUpdateCost : DevExpress.XtraEditors.XtraForm
    {
        public fUpdateCost()
        {
            InitializeComponent();
        }
        private void temizle()
        {
            lBarkod.Text = "";
            lÜrün.Text = "";
            lFiyat.Text = "";
        }
        private void fUpdateCost_Load(object sender, EventArgs e)
        {
            temizle();
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using(var db=new BitirmeEntities())
                {
                    if (db.Urun.Any(x => x.Barkod == tBarkod.Text))
                    {
                        var getir = db.Urun.Where(x => x.Barkod == tBarkod.Text).SingleOrDefault();
                        lBarkod.Text = getir.Barkod;
                        lÜrün.Text = getir.UrunAd;
                        double mevcutfiyat = Convert.ToDouble(getir.SatisFiyat);
                        lFiyat.Text = mevcutfiyat.ToString("C2");
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı Değil");
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(tYeniFiyat.Text!="" && lBarkod.Text != "")
            {
                using(var db=new BitirmeEntities())
                {
                    var güncellenecek = db.Urun.Where(x => x.Barkod == lBarkod.Text).SingleOrDefault();
                    güncellenecek.SatisFiyat = İslemler.DoubleYap(tYeniFiyat.Text);
                    int kdvOranı = Convert.ToInt16(güncellenecek.KdvOrani);
                    Math.Round(İslemler.DoubleYap(tYeniFiyat.Text) * kdvOranı/100,2);
                    db.SaveChanges();
                    MessageBox.Show("Yeni Fiyat Kaydedildi");
                    temizle();
                    tYeniFiyat.Clear();
                    tBarkod.Clear();
                }
            }
            else
            {
                MessageBox.Show("Ürün Okutunuz");
            }
        }
    }
}