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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAU9GPN\\SQLEXPRESS; Initial Catalog=PersonelVeriTabani; Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            //toplam personel
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblTplmPer.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //evli personel
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where durum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPer.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //bekar personel
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where durum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBkrPer.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select  count(distinct PerSehir) from Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSay.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblTplmMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select AVG(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


            //sercan test kişi, mass toplamı, maas ortalaması
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select count(PerID),Sum(Permaas),AVG(Permaas) from Tbl_Personel", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while(dr7.Read())
            {
                lbl7ToplamPer.Text = dr7[0].ToString();
                lbl7TopMaas.Text= dr7[1].ToString();
                lbl7OrtMaas.Text = dr7[2].ToString();
            }



        }
    }
}
