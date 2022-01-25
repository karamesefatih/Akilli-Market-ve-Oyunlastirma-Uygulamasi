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
    public partial class fShowDetails : DevExpress.XtraEditors.XtraForm
    {
        public fShowDetails()
        {
            InitializeComponent();
        }
        public int islemno { get; set; }
        private void fShowDetails_Load(object sender, EventArgs e)
        {
            lislemno.Text = "İşlem No : " + islemno.ToString();
            using(var db = new BitirmeEntities())
            {
                gridSatışList.DataSource = db.Satis.Select(s=>new {s.IslemNo,s.UrunAd,s.UrunGrup,s.Miktar,s.Toplam }).Where(x => x.IslemNo == islemno).ToList();
                İslemler.GridDüzenle(gridSatışList);
            }
        }
    }
}