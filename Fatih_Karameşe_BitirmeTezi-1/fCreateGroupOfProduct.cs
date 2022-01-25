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
    public partial class fCreateGroupOfProduct : DevExpress.XtraEditors.XtraForm
    {
        public fCreateGroupOfProduct()
        {
            InitializeComponent();
        }
        BitirmeEntities db = new BitirmeEntities();
        private void UrunGrubuEkle_Load(object sender, EventArgs e)
        {
            grupdoldur();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                UrunGrup urunGrup = new UrunGrup();
                urunGrup.UrunGrupAdı = textBox1.Text;
                db.UrunGrup.Add(urunGrup);
                db.SaveChanges();
                grupdoldur();
                textBox1.Clear();
                MessageBox.Show("Ürün Grubu Eklenmiştir");
                fCreateProduct ürünEkle = (fCreateProduct)Application.OpenForms["ÜrünEkle"];
                if (ürünEkle!=null) {
                    ürünEkle.grupdoldur();
                }

            }
            else
            {
                MessageBox.Show("Ürün Grubu Ekleyiniz");
            }
        }
      
        private void grupdoldur()
        {
            lurungrubu.DisplayMember = "UrunGrupAdı";
            lurungrubu.ValueMember = "Id";
            lurungrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAdı).ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int grupid = Convert.ToInt32(lurungrubu.SelectedValue.ToString());
            string grupad = lurungrubu.Text;
            DialogResult onay = MessageBox.Show(grupad + "grubunu silmek istiyor musunuz?","Silme işlemi",MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                var grup = db.UrunGrup.FirstOrDefault(x => x.Id == grupid);
                db.UrunGrup.Remove(grup);
                db.SaveChanges();
                grupdoldur();
                textBox1.Focus();
                MessageBox.Show(grupad +"ürün grubu silindi");
                fCreateProduct urunEkle = (fCreateProduct)Application.OpenForms["ÜrünEkle"];
                urunEkle.grupdoldur();
            }

        }

        private void lurungrubu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}