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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        // SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-QAU9GPN\\SQLEXPRESS; Initial Catalog = PersonelVeriTabani; Integrated Security = True; Trust Server Certificate=True");
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAU9GPN\\SQLEXPRESS; Initial Catalog=PersonelVeriTabani; Integrated Security=True");

        void temizle()
        {
            txtID.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtMeslek.Clear();
            mskTxtMaas.Clear();
            cmbBxSehir.Text = "";
            rdBtnBekar.Checked = false;
            rdBtnEvli.Checked = false;
            txtAd.Focus();
        }
        void boshata()
        {

        }

        Boolean durum;



        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.

         }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "")
            {
                MessageBox.Show("Ad ve Soyadı doldurunuz");

            }
            else
            {

                baglanti.Open();

                SqlCommand ekle = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,Durum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                ekle.Parameters.AddWithValue("@p1", txtAd.Text);
                ekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
                ekle.Parameters.AddWithValue("@p3", cmbBxSehir.Text);
                ekle.Parameters.AddWithValue("@p4", mskTxtMaas.Text);
                ekle.Parameters.AddWithValue("@p5", txtMeslek.Text);
                ekle.Parameters.AddWithValue("@p6", durum);
                ekle.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Eklendi");

            }

        }

        private void rdBtnEvli_CheckedChanged(object sender, EventArgs e)
        {
            durum = true;
        }

        private void rdBtnBekar_CheckedChanged(object sender, EventArgs e)
        {
            durum = false;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBxSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTxtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            durum = Convert.ToBoolean(dataGridView1.Rows[secilen].Cells[6].Value);
            if(durum==true)
            {
                rdBtnEvli.Checked = true;
                rdBtnBekar.Checked = false;
            }
            else
            {
                rdBtnEvli.Checked = false;
                rdBtnBekar.Checked = true;
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete from Tbl_Personel where PerId=@k1",baglanti);
            sil.Parameters.AddWithValue("@k1", txtID.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand Guncelle = new SqlCommand("Update Tbl_Personel set PerAd=@a2,PerSoyad=@a3,PerSehir=@a4,PerMaas=@a5,PerMeslek=@a6,Durum=@a7 where PerId=@a1", baglanti);
            Guncelle.Parameters.AddWithValue("@a1", txtID.Text);
            Guncelle.Parameters.AddWithValue("@a2", txtAd.Text);
            Guncelle.Parameters.AddWithValue("@a3", txtSoyad.Text);
            Guncelle.Parameters.AddWithValue("@a4", cmbBxSehir.Text);
            Guncelle.Parameters.AddWithValue("@a5", mskTxtMaas.Text);
            Guncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            Guncelle.Parameters.AddWithValue("@a7", rdBtnEvli.Checked ? 1:0);
            Guncelle.ExecuteNonQuery();


            baglanti.Close();
            MessageBox.Show("Güncellendi");
        }

        private void btnIstatislik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
         
        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            //FrmRaporlar frr = new FrmRaporlar();
            //frr.Show();
        }
    }
}
