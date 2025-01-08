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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAU9GPN\\SQLEXPRESS; Initial Catalog=PersonelVeriTabani; Integrated Security=True");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Kullanici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            if (dr1.Read())
            {
                FrmAnaForm AnaFr = new FrmAnaForm();
                AnaFr.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre");
            }
            baglanti.Close();

        }
    }
}
