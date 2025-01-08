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

namespace Personel_Kayit
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAU9GPN\\SQLEXPRESS; Initial Catalog=PersonelVeriTabani; Integrated Security=True");

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //Şehirlerdeki kişi sayısı
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select  PerSehir,Count(*) from Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //Meslek maaş
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select PerMeslek,AVG(PerMaas) from Tbl_Personel group by PerMeslek ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }


            baglanti.Close();
        }
    }
}
