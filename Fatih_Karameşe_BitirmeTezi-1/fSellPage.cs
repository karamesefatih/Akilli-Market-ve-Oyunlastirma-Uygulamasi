using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fatih_Karameşe_BitirmeTezi_1
{
    public partial class fSellPage : DevExpress.XtraEditors.XtraForm
    {
        public fSellPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            HizliButon();
            // BUTONLARI TL DEĞERİNDE GETİR
            b5.Text = 5.ToString("C2");
            b10.Text = 10.ToString("C2");
            b20.Text = 20.ToString("C2");
            b50.Text = 50.ToString("C2");
            b100.Text = 100.ToString("C2");
            b200.Text = 200.ToString("C2");
            using(var db=new BitirmeEntities())
            {
                var sabit = db.Sabit.FirstOrDefault();
                chYazdırma.Checked = Convert.ToBoolean(sabit.Yazici);
            }
            


        }
        // Butonların isimlerini database den solduran fonksiyon
        private void HizliButon() {
           
            var hizliurun = db.HizliUrun.ToList();
            foreach(var item in hizliurun)
            {
                SimpleButton bh = this.Controls.Find("bh" + item.Id,true).FirstOrDefault() as SimpleButton;
                if(bh != null)
                {
                    double fiyat = İslemler.DoubleYap(item.Fıyat.ToString());
                    bh.Text = item.UrunAd + "\n" + fiyat.ToString("C2");
                }
            }
            geneltoplam();
        }
        //Bütün butonların çalışmasını sağlayan fonksiyon
        private void HizliButonClick(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;
            int buttonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));

            if (b.Text.ToString().StartsWith("-"))
            {
                fAddProduct urunEkle = new fAddProduct();
                urunEkle.BUTONID.Text = buttonid.ToString();
                urunEkle.ShowDialog();
                
            }
            else
            {
                var urunbarkod = db.HizliUrun.Where(a => a.Id == buttonid).Select(a => a.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                listeyeürüngetir(urun, urunbarkod, Convert.ToDouble(tbMiktar.Text));
                geneltoplam();
            }
        }

        private void tablePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
        BitirmeEntities db = new BitirmeEntities();
       

        //eğer barkod doğruysa  ürünleri listeye getir ve fiyatı ekle
        private void tbBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string barkod = tbBarkod.Text.Trim();
                if (barkod.Length <= 2)
                {
                    tbMiktar.Text = barkod;
                    tbBarkod.Clear();
                    tbBarkod.Focus();
                }
                else
                {
                    //Barkod da ki numaranın enter sonucu aranmasıyla ekrana barkodun bilgilerini getirdim
                    if (db.Urun.Any(a => a.Barkod == barkod))
                    {
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        listeyeürüngetir(urun, barkod, Convert.ToDouble(tbMiktar.Text));

                    }
                    else
                    {
                        //kg olması durumunda
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if (db.Terazi.Any(a => a.TeraziOnEk == onek))
                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.Urun.Any(a => a.Barkod == teraziurunno))
                            {
                                var urunterazi = db.Urun.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                listeyeürüngetir(urunterazi, teraziurunno, miktarkg);
                            }
                            else
                            {
                                Console.Beep(900, 2000);
                                MessageBox.Show("Kg Ürün Ekleme Sayfası");
                            }
                        }
                        else
                        {
                            Console.Beep(900, 2000);
                            fCreateProduct ü = new fCreateProduct();
                            ü.tbarkod.Text = barkod;
                            ü.ShowDialog();
                        }

                    }
                }
                gridSatışList.ClearSelection();
                geneltoplam();
               
            }
        }
        private void listeyeürüngetir(Urun urun,string barkod,double miktar)
        {
            int satir = gridSatışList.Rows.Count;
          //  double miktar = Convert.ToDouble(tbMiktar.Text);
            bool eklenmismi = false;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    if (gridSatışList.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridSatışList.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridSatışList.Rows[i].Cells["Miktar"].Value);
                        gridSatışList.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridSatışList.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatışList.Rows[i].Cells["Fiyat"].Value), 2);
                        eklenmismi = true;
                    }
                }
            }
            if (!eklenmismi)
            {
                gridSatışList.Rows.Add();
                gridSatışList.Rows[satir].Cells["Barkod"].Value = barkod;
                gridSatışList.Rows[satir].Cells["UrunAdı"].Value = urun.UrunAd;
                gridSatışList.Rows[satir].Cells["Fiyat"].Value = urun.SatisFiyat;
                gridSatışList.Rows[satir].Cells["Miktar"].Value = miktar;
                gridSatışList.Rows[satir].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
                gridSatışList.Rows[satir].Cells["KdvTutari"].Value = urun.KdvTutari;
                gridSatışList.Rows[satir].Cells["AlisFiyati"].Value = urun.AlisFiyat;
                gridSatışList.Rows[satir].Cells["Urungrup"].Value = urun.UrunGrup;
                gridSatışList.Rows[satir].Cells["Birim"].Value = urun.Birim;
            }
        }
        private void geneltoplam()
        {
            if (gridSatışList.Rows.Count > 0)
            {
                double toplam = 0;
                for (int i=0;i< gridSatışList.Rows.Count; i++)
                {
                    toplam += Convert.ToDouble(gridSatışList.Rows[i].Cells["Toplam"].Value);
                }
                tbToplam.Text = toplam.ToString("C2");
                tbMiktar.Text = "1";
                tbBarkod.Clear();
                tbBarkod.Focus();
            }

        }
        //Ürün çıkart
        private void gridSatışList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridSatışList.Rows.Remove(gridSatışList.CurrentRow);
            gridSatışList.ClearSelection();
            geneltoplam();
            tbBarkod.Focus();

        }
        //BUTON TEMİZLEME


        private void bh_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                SimpleButton b = (SimpleButton)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int buttonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length-2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + buttonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int buttonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrun.Find(buttonid);
            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fıyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            SimpleButton b = this.Controls.Find("bh" + buttonid, true).FirstOrDefault() as SimpleButton;
            b.Text = "-" + "\n" + fiyat.ToString("C2") ;
        }
        private void bnx_Click(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;
            if (b.Text == ",")
            {
                int virgul = tbNumarater.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    tbNumarater.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (tbNumarater.Text.Length > 0)
                {
                    tbNumarater.Text = tbNumarater.Text.Substring(0, tbNumarater.Text.Length - 1);
                }
               
            }
            else
            {
                tbNumarater.Text += b.Text;
            }
        }

        private void bAdet_Click(object sender, EventArgs e)
        {
            if (tbNumarater.Text != "")
            {
                tbMiktar.Text = tbNumarater.Text;
                tbNumarater.Clear();
                tbBarkod.Clear();
                tbBarkod.Focus();
            }
        }

        private void bOdenen_Click(object sender, EventArgs e)
        {
            if (tbNumarater.Text != "")
            {
                double sonuc = İslemler.DoubleYap(tbNumarater.Text) - İslemler.DoubleYap(tbToplam.Text);
                tbParaÜstü.Text = sonuc.ToString("C2");
                tbNumarater.Clear();
                tbBarkod.Focus();

            }
        }
        private void Paraustuhesapla_Click(object sender,EventArgs e) {
            SimpleButton b = (SimpleButton)sender;
            double sonuc = İslemler.DoubleYap(b.Text) - İslemler.DoubleYap(tbToplam.Text);
            tbÖdenen.Text = İslemler.DoubleYap(tbNumarater.Text).ToString("C2");
            
            tbParaÜstü.Text = sonuc.ToString("c2");
        }
        private void bBarkod_Click(object sender, EventArgs e)
        {
            if (tbNumarater.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tbNumarater.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == tbNumarater.Text).FirstOrDefault();
                    listeyeürüngetir(urun, tbNumarater.Text, Convert.ToDouble(tbMiktar.Text));
                    tbNumarater.Clear();
                    tbBarkod.Focus();
                }
            }
        }

        private void bDiger_Click(object sender, EventArgs e)
        {
            if (tbNumarater.Text != "")
            {
                int satir = gridSatışList.Rows.Count;
                gridSatışList.Rows.Add();
                gridSatışList.Rows[satir].Cells["Barkod"].Value = "1111111111116";
                gridSatışList.Rows[satir].Cells["UrunAdı"].Value = "Barkodsuz ürün";
                gridSatışList.Rows[satir].Cells["UrunGrup"].Value = "Barkodsuz ürün";
                gridSatışList.Rows[satir].Cells["Birim"].Value = "Adet";
                gridSatışList.Rows[satir].Cells["AlisFiyati"].Value = 0;
                gridSatışList.Rows[satir].Cells["Miktar"].Value = 1;
                gridSatışList.Rows[satir].Cells["Fiyat"].Value = Convert.ToDouble(tbNumarater.Text);
                gridSatışList.Rows[satir].Cells["KdvTutari"].Value = 0;
                gridSatışList.Rows[satir].Cells["Toplam"].Value = Convert.ToDouble(tbNumarater.Text);
                tbNumarater.Text = "";
                geneltoplam();
                tbBarkod.Focus();
                
            
            }
        }
        //satış yaptıktan sonra verileri ikinci datagridviewde tutuyorum
        private void bekle()
        {
            int satir = gridSatışList.Rows.Count;
            int sutun = gridSatışList.Columns.Count;
            if(satir > 0)
            {
                for(int i = 0;i < satir; i++){
                    dataGridView1.Rows.Add();
                    for(int j = 0; j < sutun - 1; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = gridSatışList.Rows[i].Cells[j].Value;
                    }

                }
            }
        }
        private void beklemedençık()
        {
            int satir = dataGridView1.Rows.Count;
            int sutun = dataGridView1.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridSatışList.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridSatışList.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
                    }

                }
            }
        }
        private void bHizliİslem_Click(object sender, EventArgs e)
        {
            if(bHizliİslem.Text =="İşlem Beklet")
            {
                bekle();
                bHizliİslem.BackColor = Color.OrangeRed;
                bHizliİslem.Text = "İşlem Bekleniyor";
                gridSatışList.Rows.Clear();
            }
            else
            {
                beklemedençık();
                bHizliİslem.Text = "İşlem Beklet";
                dataGridView1.Rows.Clear();

            }
           
        }

        private void bİade_Click(object sender, EventArgs e)
        {
            if (csSatis.Checked)
            {
                csSatis.Checked = false;
                csSatis.Text = "SATIŞ YAPILIYOR";
            }
            else
            {
                csSatis.Checked = true;
                csSatis.Text = "İADE YAPILIYOR";
            }
        }

        private void bFis_Click(object sender, EventArgs e)
        {
             
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            delete();
        }
        private void delete()
        {
            tbMiktar.Text = "1";
            tbBarkod.Clear();
            tbÖdenen.Clear();
            tbParaÜstü.Clear();
            tbToplam.Text = 0.ToString("C2");
            csSatis.Checked = false;
            tbNumarater.Clear();
            gridSatışList.Rows.Clear();
            tbBarkod.Focus();
           
        }
        //3 kere çağırmamak için metod oluşturdum
        public void satışyap(string ödemeşekli)
        {
            int satir = gridSatışList.Rows.Count;
            bool satisiade = csSatis.Checked;
            double alisfiyattoplam = 0;
            if (satir > 0)
            {
                int? islemno = db.İslem.First().İslemNo;
                Satis satis = new Satis();

                for (int i = 0; i < satir; i++)
                {
                    satis.IslemNo = islemno;

                    satis.IslemNo = islemno;
                    satis.UrunAd = gridSatışList.Rows[i].Cells["UrunAdı"].Value.ToString();
                    satis.UrunGrup = gridSatışList.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.Barkod = gridSatışList.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.Birim = gridSatışList.Rows[i].Cells["Birim"].Value.ToString();
                    satis.AlisFiyat = İslemler.DoubleYap(gridSatışList.Rows[i].Cells["AlisFiyati"].Value.ToString());
                    satis.SatisFiyat = İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Toplam"].Value.ToString());
                    satis.KdvTutari = İslemler.DoubleYap(gridSatışList.Rows[i].Cells["KdvTutari"].Value.ToString()) * İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = lbKullanıcı.Text;
                    db.Satis.Add(satis);
                    db.SaveChanges();
                   
                    if (!satisiade)
                    {
                        İslemler.StokAzalt(gridSatışList.Rows[i].Cells["Barkod"].Value.ToString(), İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Miktar"].Value.ToString()));

                    }
                    else
                    {
                        İslemler.StokArtir(gridSatışList.Rows[i].Cells["Barkod"].Value.ToString(), İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Miktar"].Value.ToString()));

                    }
                    alisfiyattoplam += İslemler.DoubleYap(gridSatışList.Rows[i].Cells["AlisFiyati"].Value.ToString()) * İslemler.DoubleYap(gridSatışList.Rows[i].Cells["Miktar"].Value.ToString());
             
                }
                IslemOzet io = new IslemOzet();
                io.IslemNo = islemno;
                io.Iade = satisiade;
                io.AlisFiyatToplam = alisfiyattoplam;
                io.Gelir = false;
                io.Gider = false;
                if (satisiade)
                {
                    io.Açiklama = "iade işlemi(" + ödemeşekli + ")";
                }
                else
                {
                    io.Açiklama = ödemeşekli + "Satış";
                }
                io.OdemeSekli = ödemeşekli;
                io.Kullanıcı = lbKullanıcı.Text;
                io.Tarih = DateTime.Now;
                switch (ödemeşekli)
                {
                    case "Nakit":
                        io.Kart = 0;
                        io.Nakit = İslemler.DoubleYap(tbToplam.Text);
                        break;
                    case "Kart":
                        io.Nakit = 0;
                        io.Kart = İslemler.DoubleYap(tbToplam.Text);
                        break;
                    case "Kart-Nakit":
                        io.Nakit = İslemler.DoubleYap(nakit.Text);
                        io.Kart = İslemler.DoubleYap(kart.Text);
                        break;
                }
                db.IslemOzet.Add(io);
                db.SaveChanges();

                var islemnoartir = db.İslem.First();
                islemnoartir.İslemNo += 1;
                db.SaveChanges();
                if (chYazdırma.Checked)
                {
                    //Yazdır
                    Yazdır yazdır = new Yazdır(islemno);
                
                    yazdır.YazdırmayaBaşla();
                }
                delete();
            }
        }

        private void btnNakit_Click(object sender, EventArgs e)
        {
            satışyap("Nakit");
        
        }
        private void btnKart_Click(object sender, EventArgs e)
        {
            satışyap("Kart");
          
        }
        private void btnNakitKart_Click(object sender, EventArgs e)
        {
            fCardCash kartNakit = new fCardCash();
            kartNakit.Show();
        }

        private void tbBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void tbNumarater_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void SellPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                satışyap("Nakit");
            }
            if (e.KeyCode == Keys.F6)
            {
                satışyap("Kart");
            }
            if (e.KeyCode == Keys.F7)
            {
                fCardCash kartNakit = new fCardCash();
                kartNakit.Show();
            }
       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
         
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            fMainStore login = new fMainStore();
            login.Show();
            this.Hide();
        }

        private void tbBarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void csSatis_CheckedChanged(object sender, EventArgs e)
        {
            if (csSatis.Checked)
            {
                csSatis.Text = "İade Yapılıyor";
                csSatis.BackColor = Color.Red;
            }
            else
            {
                csSatis.Text = "Satış Yapılıyor";
                csSatis.BackColor = Color.Green;
            }
        }

        private void chYazdırma_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
