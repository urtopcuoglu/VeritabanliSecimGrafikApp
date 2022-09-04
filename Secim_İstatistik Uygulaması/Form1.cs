using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Secim_İstatistik_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=THINKPAD-E470;Initial Catalog=DBSecim_İstatistik;Integrated Security=True");
        private void btnOyGiris_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("insert into TBLİLCE (ILCE_ADI,A_PARTI,B_PARTI,C_PARTI,D_PARTI,E_PARTI) values (@P1,@P2,@P3,@P4,@P5,@P6)",conn);
            komut.Parameters.AddWithValue("@P1",txtİlce.Text);
            komut.Parameters.AddWithValue("@P2",txtA.Text);
            komut.Parameters.AddWithValue("@P3",txtB.Text);
            komut.Parameters.AddWithValue("@P4",txtC.Text);
            komut.Parameters.AddWithValue("@P5",txtD.Text);
            komut.Parameters.AddWithValue("@P6",txtE.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Oy Girişi Başarılı");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frGrafik = new FrmGrafikler();
            frGrafik.Show();
        }
    }
}
