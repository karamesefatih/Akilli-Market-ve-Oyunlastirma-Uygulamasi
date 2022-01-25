using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fatih_Karameşe_BitirmeTezi_1
{
    public partial class fBackup : DevExpress.XtraEditors.XtraForm
    {
        public fBackup()
        {
            InitializeComponent();
        }

        private void btnYedekSeç_Click(object sender, EventArgs e)
        {
            if (tYedekSeç.Text != "")
            {
                try
                {
                    string strSql = @"data source=(LocalDB)\MSSQLLocalDb;attachdbfilename=|DataDirectory|\Bitirme.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                    Cursor.Current = Cursors.WaitCursor;
                    string yedekyolu = tYedekSeç.Text;
                    Application.DoEvents();
                    string str = Application.StartupPath + @"\Bitirme.mdf";
                    using (SqlConnection connection = new SqlConnection(strSql))
                    {
                        connection.Open();
                        SqlCommand isle = new SqlCommand(@"USE Master; If Exists(Select * From sys.database where name='Bitirme') Drop Database[" + str + "];RESTORE DATABASE[" + str + "] FROM DISK=N'"+tYedekSeç.Text+"'",connection);
                        isle.ExecuteNonQuery();
                        connection.Close();
                    }
                    MessageBox.Show("Veriler Yüklenmiştir");
                    Process.Start(Application.StartupPath + "\\Fatih_Karameşe_BitirmeTezi-1.exe");
                    Cursor.Current = Cursors.Default;
                    Application.Exit();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
    }
}