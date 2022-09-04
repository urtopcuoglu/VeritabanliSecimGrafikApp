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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=THINKPAD-E470;Initial Catalog=DBSecim_İstatistik;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //İlçe İsimlerini Combobox'a Getirme
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ILCE_ADI from TBLİLCE",conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            conn.Close();
            //Grafiklere Toplam Sonuç Getirme
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT SUM(A_PARTI),SUM(B_PARTI),SUM(C_PARTI),SUM(D_PARTI),SUM(E_PARTI) FROM TBLİLCE",conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ",dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ",dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr2[4]);
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLİLCE WHERE ILCE_ADI=@P1", conn);
            komut.Parameters.AddWithValue("@P1",comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                pbA.Value = int.Parse(dr[2].ToString());
                pb2.Value = int.Parse(dr[3].ToString());
                pb3.Value = int.Parse(dr[4].ToString());
                pb4.Value = int.Parse(dr[5].ToString());
                pb5.Value = int.Parse(dr[6].ToString());

                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
            }
            conn.Close();
        }
    }
}
