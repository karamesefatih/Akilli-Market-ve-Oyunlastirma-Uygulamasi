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
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (tkullanici.Text != "" && tsifre.Text != "")
            {
                try
                {
                    using (var db = new BitirmeEntities())
                    {
                        
                            var asd = db.Kullanıvılar.Where(x => x.Kullanıcı == tkullanici.Text && x.Sifre == tsifre.Text).FirstOrDefault();
                            if (asd != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                fMainStore f = new fMainStore();
                                f.bSatisİslemi.Enabled = (bool)asd.Satis;
                                f.bRaporlar.Enabled = (bool)asd.Rapor;
                                f.bStokTakibi.Enabled = (bool)asd.stok;
                                f.bÜrünGiris.Enabled = (bool)asd.ürüngiris;
                                f.bAyarlar.Enabled = (bool)asd.kullanıcılar;
                                f.bFiyatGüncelle.Enabled = (bool)asd.fiyatgüncelle;
                                f.bYedekle.Enabled = (bool)asd.yedekleme;
                                f.lKullanici.Text = asd.AdSoyad;
                                var isyeri = db.Sabit.FirstOrDefault();
                                f.lisyeri.Text = isyeri.Unvan;
                                f.Show();
                                this.Hide();
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı veya eksik giriş yaptınız!");
                            }
                        }
                    }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
    }
}