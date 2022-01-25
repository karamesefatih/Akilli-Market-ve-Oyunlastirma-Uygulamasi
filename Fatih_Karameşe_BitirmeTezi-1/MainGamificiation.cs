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
    public partial class MainGamificiation : DevExpress.XtraEditors.XtraForm
    {
        public MainGamificiation()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fLogin giriş = new fLogin();
            giriş.Show();
            this.Hide();
        }
    }
}