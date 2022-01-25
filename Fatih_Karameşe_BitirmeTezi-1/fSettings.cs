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
    public partial class fSettings : DevExpress.XtraEditors.XtraForm
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void temizle()
        {

            tAdSoyad.Clear();
            tTelefon.Clear(); 
             tEposta.Clear(); 
            tKullanıcıAdı.Clear(); 
            tSifreTekrar.Clear();
            tsifre.Clear();
            cSatışEkranı.Checked = false;
             cRapor.Checked = false;
             cStok.Checked = false;
            cÜrünGiriş.Checked = false;
            cAyarlar.Checked = false;
            cFiyatGüncelleme.Checked = false;
            cYedekleme.Checked = false;
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Kaydet")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanıcıAdı.Text != "" && tsifre.Text != "" && tSifreTekrar.Text != "")
                {
                    if (tsifre.Text == tSifreTekrar.Text)
                    {
                        try
                        {
                            using (var db = new BitirmeEntities())
                            {
                                if (!db.Kullanıvılar.Any(x => x.Kullanıcı == tKullanıcıAdı.Text))
                                {
                                    Kullanıvılar t = new Kullanıvılar();
                                    t.AdSoyad = tAdSoyad.Text;
                                    t.Telefon = tTelefon.Text;
                                    t.EPosta = tEposta.Text;
                                    t.Kullanıcı = tKullanıcıAdı.Text.Trim();
                                    t.Sifre = tSifreTekrar.Text;

                                    t.Satis = cSatışEkranı.Checked;
                                    t.Rapor = cRapor.Checked;
                                    t.stok = cStok.Checked;
                                    t.ürüngiris = cÜrünGiriş.Checked;
                                    t.kullanıcılar = cAyarlar.Checked;
                                    t.fiyatgüncelle = cFiyatGüncelleme.Checked;
                                    t.yedekleme = cYedekleme.Checked;
                                    db.Kullanıvılar.Add(t);
                                    db.SaveChanges();
                                    doldur();
                                    temizle();

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ögeleri Giriniz" + "\nAd Soyad\nKullanıcı Adı\n Şifre\nTelefon");
                }
            }
            else if (btnKaydet.Text == "Düzenle")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanıcıAdı.Text != "" && tsifre.Text != "" && tSifreTekrar.Text != "")
                {
                    if (tsifre.Text == tSifreTekrar.Text)
                    {
                        int id = Convert.ToInt32(lkullanici.Text);
                        using (var db = new BitirmeEntities())
                        {
                            var guncelle = db.Kullanıvılar.Where(x => x.Id == id).FirstOrDefault();

                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.Telefon = tTelefon.Text;
                            guncelle.EPosta = tEposta.Text;
                            guncelle.Kullanıcı = tKullanıcıAdı.Text.Trim();
                            guncelle.Sifre = tSifreTekrar.Text;
                            guncelle.Satis = cSatışEkranı.Checked;
                            guncelle.Rapor = cRapor.Checked;
                            guncelle.stok = cStok.Checked;
                            guncelle.ürüngiris = cÜrünGiriş.Checked;
                            guncelle.kullanıcılar = cAyarlar.Checked;
                            guncelle.fiyatgüncelle = cFiyatGüncelleme.Checked;
                            guncelle.yedekleme = cYedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme işlemi başarıyla tanımlanmıştır");
                            btnKaydet.Text = "Kaydet";
                            temizle();
                            doldur();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ögeleri Giriniz" + "\nAd Soyad\nKullanıcı Adı\n Şifre\nTelefon");
                }
            }
            else
            {
                MessageBox.Show("asdasd uyuşmuyor");
            }
        }


        private void Ayarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doldur();
            Cursor.Current = Cursors.Default;

        }
        private void doldur()
        {
            using (var db = new BitirmeEntities())
            {
                if (db.Kullanıvılar.Any())
                {
                    gridSatışList.DataSource = db.Kullanıvılar.Select(x => new { x.Id, x.AdSoyad, x.Kullanıcı, x.Telefon }).ToList();
                }
                İslemler.SabitVarsayılan();

                var sabitler = db.Sabit.FirstOrDefault();
                tnumeric1.Text = sabitler.KartKomisyon.ToString();

                var teraziörnek = db.Terazi.ToList();
                cbTerazi.DisplayMember = "TeraziOnEk";
                cbTerazi.ValueMember = "Id";
                cbTerazi.DataSource = teraziörnek;

                tAdSoyad2.Text = sabitler.AdSoyad;
                tÜnvan.Text = sabitler.Unvan;
                tAdres.Text = sabitler.Adres;
                tTelefon2.Text = sabitler.Telefon;
                tEPosta2.Text = sabitler.Eposta;


            }
        }
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridSatışList.Rows.Count > 0)
            {
                int id = Convert.ToInt32(gridSatışList.CurrentRow.Cells["ID"].Value.ToString());
                lkullanici.Text = id.ToString();
                using(var db = new BitirmeEntities())
                {
                    var getir = db.Kullanıvılar.Where(x => x.Id == id).FirstOrDefault();
                    tAdSoyad.Text = getir.AdSoyad;
                    tTelefon.Text = getir.Telefon;
                    tEposta.Text = getir.EPosta;
                    tKullanıcıAdı.Text = getir.Kullanıcı;
                    tsifre.Text = getir.Sifre;
                    tSifreTekrar.Text = getir.Sifre;
                    cSatışEkranı.Checked = (bool)getir.Satis;
                    cRapor.Checked = (bool)getir.Rapor;
                    cStok.Checked = (bool)getir.stok;
                    cÜrünGiriş.Checked = (bool)getir.ürüngiris;
                    cAyarlar.Checked = (bool)getir.kullanıcılar;
                    cFiyatGüncelleme.Checked = (bool)getir.fiyatgüncelle;
                    cYedekleme.Checked = (bool)getir.yedekleme;
                    btnKaydet.Text = "Düzenle";
                    doldur();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz");
            }
        }


        private void csSatis_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new BitirmeEntities())
            {
                if (csSatis.Checked)
                {
                    csSatis.BackColor = Color.Red;
                    İslemler.SabitVarsayılan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    csSatis.Text = "Yazma Durumu PASİF";
                }
                else
                {
                    csSatis.BackColor = Color.LimeGreen;
                    İslemler.SabitVarsayılan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    csSatis.Text = "Yazma Durumu AKTİF";
                }
            }
           
        }

        private void btnKomisyon_Click(object sender, EventArgs e)
        {
            if(tnumeric1.Text != "")
            {
                using(var db = new BitirmeEntities())
                {
                    var sabit = db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(tnumeric1.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart komisyonu ayarlandı");
                }
            }
            else
            {
                MessageBox.Show("Eksik veya hatalı bilgi girdiniz");
                
            }
        }

        private void btnTerazi_Click(object sender, EventArgs e)
        {
            if (tTerazi.Text != "")
            {
                int onek = Convert.ToInt16(tTerazi.Text);
                using(var db = new BitirmeEntities())
                {
                    if (db.Terazi.Any(x => x.TeraziOnEk == onek))
                    {
                        MessageBox.Show(onek.ToString() + " önek zaten kayıtlı");
                    }
                    else
                    {
                        Terazi t = new Terazi();
                        t.TeraziOnEk = onek;
                        db.Terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Bilgiler başarıyla kaydedilmiştir");
                        cbTerazi.DisplayMember = "TeraziOnEk";
                        cbTerazi.ValueMember = "Id";
                        cbTerazi.DataSource = db.Terazi.ToList();
                        tTerazi.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Hatalı veya eksik bilgi girdiniz");
            }
        }

        private void btnTeraziSil_Click(object sender, EventArgs e)
        {
            int onekid = Convert.ToInt16(cbTerazi.SelectedIndex);
            DialogResult onay = MessageBox.Show(cbTerazi.Text + " ön eki silmek istiyor musunuz?", "Terazi Ön Ek Silme İşlemi",MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                using (var db = new BitirmeEntities())
                {
                    var onek = db.Terazi.Find(onekid);
                    db.Terazi.Remove(onek);
                    db.SaveChanges();
                    cbTerazi.DisplayMember = "TeraziOnEk";
                    cbTerazi.DisplayMember = "Id";
                    cbTerazi.DataSource = db.Terazi.ToList();
                    MessageBox.Show("Ön Ek silinmiştir");
                }
            }
            else
            {
                MessageBox.Show("Ön Ek Seçiniz");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void saveisyeri()
        {
            if (tAdSoyad2.Text != "" && tÜnvan.Text != "" && tAdres.Text != "" && tTelefon2.Text != "" && tEPosta2.Text != "")
            {
                using (var db = new BitirmeEntities())
                {
                    var isyeri = db.Sabit.FirstOrDefault();
                    isyeri.AdSoyad = tAdSoyad2.Text;
                    isyeri.Unvan = tÜnvan.Text;
                    isyeri.Adres = tAdres.Text;
                    isyeri.Telefon = tTelefon2.Text;
                    isyeri.Eposta = tEPosta2.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri Bilgileri Başarıyla Kaydedilmiştir");
                    var yeni = db.Sabit.FirstOrDefault();
                    tAdSoyad2.Text = yeni.AdSoyad;
                    tÜnvan.Text = yeni.Unvan;
                    tAdres.Text = yeni.Adres;
                    tTelefon2.Text = yeni.Telefon;
                    tEPosta2.Text = yeni.Eposta;
                }
            }
            else
            {
                MessageBox.Show("Eksik veya Hatalı Bilgi Girdiniz!");
            }
        }
        private void btnİsyeri_Click(object sender, EventArgs e)
        {
            saveisyeri();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fMainStore f = new fMainStore();
            f.Show();
            this.Hide();
        }
        //FOCUSLAMA İŞLEMLERİ KULLACI KAYIT
        private void tAdSoyad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tTelefon.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if(e.KeyCode == Keys.Down)
            {
                tTelefon.Focus();
            }
        }

        private void tTelefon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tEposta.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tEposta.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tAdSoyad.Focus();
            }
        }

        private void tEposta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tKullanıcıAdı.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tKullanıcıAdı.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tTelefon.Focus();
            }
        }

        private void tKullanıcıAdı_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsifre.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tsifre.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tEposta.Focus();
            }
        }
        private void tsifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tSifreTekrar.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tSifreTekrar.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tKullanıcıAdı.Focus();
            }
        }
        private void tSifreTekrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnKaydet.Text == "Kaydet")
                {
                    if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanıcıAdı.Text != "" && tsifre.Text != "" && tSifreTekrar.Text != "")
                    {
                        if (tsifre.Text == tSifreTekrar.Text)
                        {
                            try
                            {
                                using (var db = new BitirmeEntities())
                                {
                                    if (!db.Kullanıvılar.Any(x => x.Kullanıcı == tKullanıcıAdı.Text))
                                    {
                                        Kullanıvılar t = new Kullanıvılar();
                                        t.AdSoyad = tAdSoyad.Text;
                                        t.Telefon = tTelefon.Text;
                                        t.EPosta = tEposta.Text;
                                        t.Kullanıcı = tKullanıcıAdı.Text.Trim();
                                        t.Sifre = tSifreTekrar.Text;

                                        t.Satis = cSatışEkranı.Checked;
                                        t.Rapor = cRapor.Checked;
                                        t.stok = cStok.Checked;
                                        t.ürüngiris = cÜrünGiriş.Checked;
                                        t.kullanıcılar = cAyarlar.Checked;
                                        t.fiyatgüncelle = cFiyatGüncelleme.Checked;
                                        t.yedekleme = cYedekleme.Checked;
                                        db.Kullanıvılar.Add(t);
                                        db.SaveChanges();
                                        doldur();
                                        temizle();

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Şifreler uyuşmuyor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen ögeleri Giriniz" + "\nAd Soyad\nKullanıcı Adı\n Şifre\nTelefon");
                    }
                }
                else if (btnKaydet.Text == "Düzenle")
                {
                    if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanıcıAdı.Text != "" && tsifre.Text != "" && tSifreTekrar.Text != "")
                    {
                        if (tsifre.Text == tSifreTekrar.Text)
                        {
                            int id = Convert.ToInt32(lkullanici.Text);
                            using (var db = new BitirmeEntities())
                            {
                                var guncelle = db.Kullanıvılar.Where(x => x.Id == id).FirstOrDefault();

                                guncelle.AdSoyad = tAdSoyad.Text;
                                guncelle.Telefon = tTelefon.Text;
                                guncelle.EPosta = tEposta.Text;
                                guncelle.Kullanıcı = tKullanıcıAdı.Text.Trim();
                                guncelle.Sifre = tSifreTekrar.Text;
                                guncelle.Satis = cSatışEkranı.Checked;
                                guncelle.Rapor = cRapor.Checked;
                                guncelle.stok = cStok.Checked;
                                guncelle.ürüngiris = cÜrünGiriş.Checked;
                                guncelle.kullanıcılar = cAyarlar.Checked;
                                guncelle.fiyatgüncelle = cFiyatGüncelleme.Checked;
                                guncelle.yedekleme = cYedekleme.Checked;
                                db.SaveChanges();
                                MessageBox.Show("Güncelleme işlemi başarıyla tanımlanmıştır");
                                btnKaydet.Text = "Kaydet";
                                temizle();
                                doldur();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Şifreler uyuşmuyor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen ögeleri Giriniz" + "\nAd Soyad\nKullanıcı Adı\n Şifre\nTelefon");
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                tsifre.Focus();
            }
        }
        //FOCUSLAMA İŞYERİ BİLGİ
        private void tAdSoyad2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tÜnvan.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tÜnvan.Focus();
            }
        }

        private void tÜnvan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tAdres.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tAdres.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tAdSoyad2.Focus();
            }
        }

        private void tAdres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tTelefon2.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tTelefon2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tÜnvan.Focus();
            }
        }

        private void tTelefon2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tEPosta2.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                tEPosta2.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                tAdres.Focus();
            }
        }

        private void tEPosta2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveisyeri();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tTelefon2.Focus();
            }
        }

        private void YazıcıTeraziKomisyon_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fMainStore f = new fMainStore();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fMainStore f = new fMainStore();
            f.Show();
            this.Hide();
        }
    }
}