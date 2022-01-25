using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fatih_Karameşe_BitirmeTezi_1
{
    public partial class fCreateProduct : DevExpress.XtraEditors.XtraForm
    {
        public fCreateProduct()
        {
            InitializeComponent();
        }

        private void ÜrünEkle_Load(object sender, EventArgs e)
        {
            gridSatışList.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
            tUrunSayısı.Text = db.Urun.Count().ToString();
            İslemler.GridDüzenle(gridSatışList);
            cÜrünGrubu.DisplayMember = "UrunGrupAdı";
            cÜrünGrubu.ValueMember = "Id";
            cÜrünGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAdı).ToList();


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        BitirmeEntities db = new BitirmeEntities();
        //Kaydet butonunun aynısı
        private void tbarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tbarkod.Text.Trim();
                if (db.Urun.Any(a => a.Barkod == barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    tUrunAdi.Text = urun.UrunAd;
                    tAciklama.Text = urun.Aciklama;
                    cÜrünGrubu.Text = urun.UrunGrup;
                    tAlisFiyati.Text = urun.AlisFiyat.ToString();
                    tSatisFiyati.Text = urun.SatisFiyat.ToString();
                    tMiktar.Text = urun.Miktar.ToString();
                    tKDVOrani.Text = urun.KdvOrani.ToString();
                    if (urun.Birim == "Kg")
                    {
                        csÜrünTipi.Checked = true;
                    }
                    else
                    {
                        csÜrünTipi.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Kayıtlı Olmayan Ürün,Kaydedebilirsiniz");
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (tbarkod.Text != "" && tUrunAdi.Text != "" && cÜrünGrubu.Text != "" && tAlisFiyati.Text != "" && tAlisFiyati.Text != "" && tKDVOrani.Text != "" && tMiktar.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tbarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == tbarkod.Text).SingleOrDefault();

                    guncelle.Barkod = tbarkod.Text;
                    guncelle.UrunAd = tUrunAdi.Text;
                    guncelle.Aciklama = tAciklama.Text;
                    guncelle.UrunGrup = cÜrünGrubu.Text;
                    guncelle.AlisFiyat = Convert.ToDouble(tAlisFiyati.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(tSatisFiyati.Text);
                    guncelle.KdvOrani = Convert.ToInt16(tKDVOrani.Text);
                    guncelle.KdvTutari = Math.Round(İslemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKDVOrani.Text) / 100, 2);
                    guncelle.Miktar = Convert.ToDouble(tMiktar.Text);
                    guncelle.Onay = true;
                    if (csÜrünTipi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                    guncelle.Birim = "Adet";
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lkullanıcı.Text;
                    gridSatışList.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();

                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = tbarkod.Text;
                    urun.UrunAd = tUrunAdi.Text;
                    urun.Aciklama = tAciklama.Text;
                    urun.UrunGrup = cÜrünGrubu.Text;
                    urun.AlisFiyat = Convert.ToDouble(tAlisFiyati.Text);
                    urun.SatisFiyat = Convert.ToDouble(tSatisFiyati.Text);
                    urun.KdvOrani = Convert.ToInt16(tKDVOrani.Text);
                    urun.KdvTutari = Math.Round(İslemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKDVOrani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(tMiktar.Text);
                    urun.Onay = true;
                    if (csÜrünTipi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }
                    urun.Birim = "Adet";
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lkullanıcı.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    if (tbarkod.Text.Length == 8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }

                    delete();
                    gridSatışList.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                    İslemler.GridDüzenle(gridSatışList);
                }
                İslemler.StokHareket(tbarkod.Text,tUrunAdi.Text,"Adet",Convert.ToDouble(tMiktar.Text),cÜrünGrubu.Text,lkullanıcı.Text);
                delete();
            }
            else
            {
                MessageBox.Show("BİLGİ GİRİŞLERİNİ KONTROL EDİNİZ!!'");
                tbarkod.Focus();
            }
        }
        private void delete()
        {
            tbarkod.Clear();
            tUrunAra.Clear();
            tAciklama.Clear();
            tAlisFiyati.Text = "0";
            tSatisFiyati.Text = "0";
            tMiktar.Text = "0";
            tKDVOrani.Text = "8";
            tbarkod.Focus();
            csÜrünTipi.Checked = false;
        }
        //datagridviewde arama yapar
        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {

            if (tUrunAra.Text != "")
            {
                string urunad = tUrunAra.Text;
                var urunler = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                gridSatışList.DataSource = urunler;
            }

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            delete();
        }
        //comboboxu doldurdum

        public void grupdoldur()
        {
            cÜrünGrubu.DisplayMember = "UrunGrupAdı";
            cÜrünGrubu.ValueMember = "Id";
            cÜrünGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAdı).ToList();
        }
        private void btnÜrünGrubu_Click(object sender, EventArgs e)
        {
            fCreateGroupOfProduct urunGrubuEkle = new fCreateGroupOfProduct();
            urunGrubuEkle.Show();
        }
        //8den düşük karakterliyse başına 0 ekleme
        private void BtnBarkod_Click(object sender, EventArgs e)
        {
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8 - karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            tbarkod.Text = olusanbarkod;
            tUrunAdi.Focus();
        }

        private void tSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08 &&e.KeyChar!=(char)44)           
            {
                e.Handled = true;
            }
        }

        private void cÜrünGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRapor_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            fMainStore giriş = new fMainStore();
            giriş.Show();
            this.Hide();
        }

        private void csSatis_CheckedChanged(object sender, EventArgs e)
        {
            if (csÜrünTipi.Checked)
            {
                csÜrünTipi.Text = "Gramajlı Ürün İşlemi";
                BtnBarkod.Enabled = false;
            }
            else
            {
                csÜrünTipi.Text = "Normal Ürün İşlemi";
                BtnBarkod.Enabled = true;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbarkod.Text = gridSatışList.CurrentRow.Cells["Barkod"].Value.ToString();
            tUrunAdi.Text = gridSatışList.CurrentRow.Cells["UrunAd"].Value.ToString();
            tAciklama.Text = gridSatışList.CurrentRow.Cells["Aciklama"].Value.ToString();
            csÜrünTipi.Text = gridSatışList.CurrentRow.Cells["UrunGrup"].Value.ToString();
            tAlisFiyati.Text = gridSatışList.CurrentRow.Cells["AlisFiyat"].Value.ToString();
            tSatisFiyati.Text = gridSatışList.CurrentRow.Cells["SatisFiyat"].Value.ToString();
            tKDVOrani.Text = gridSatışList.CurrentRow.Cells["KdcPrani"].Value.ToString();
            tMiktar.Text = gridSatışList.CurrentRow.Cells["Miktar"].Value.ToString();
            string birim = gridSatışList.CurrentRow.Cells["Birim"].Value.ToString();
            if (birim == "Kg")
            {
                csÜrünTipi.Checked = true;
            }
            else
            {
                csÜrünTipi.Checked = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("!! UYARI : \n BU İŞLEMDEN SONRA ONAYLANMAMIŞ BÜTÜN ÜRÜNLER SİLİNECEKTİR\n DEVAM ETMEK İSTİYOR MUSUNUZ? ");
            if (onay == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                db.Urun.RemoveRange(db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList());
                gridSatışList.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                MessageBox.Show("KULLANILMAYAN ÜRÜNLER SİLİNDİ");
                Cursor.Current = Cursors.Default;
            }
        }
    }
}