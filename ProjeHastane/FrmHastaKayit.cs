using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjeHastane
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        void temizle()
        {
            txtHastaAd.Text = "";
            txtHastaSoyad.Text = "";
            mskHastaTC.Text = "";
            mskHastaTel.Text = "";
            txtHastaSifre.Text = "";
            cmbHastaCinsiyet.Text = "";
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnKayıtYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLHASTALAR (HastaAd,HastaSoyad,HastaTC,HastaTel,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtHastaAd.Text);
            komut.Parameters.AddWithValue("@p2", txtHastaSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskHastaTC.Text);
            komut.Parameters.AddWithValue("@p4", mskHastaTel.Text);
            komut.Parameters.AddWithValue("@p5", txtHastaSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbHastaCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir. Şifreniz :" + txtHastaSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }
    }
}
