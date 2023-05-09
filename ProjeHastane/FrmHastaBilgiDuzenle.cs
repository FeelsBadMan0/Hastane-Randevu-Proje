using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjeHastane
{
    public partial class FrmHastaBilgiDuzenle : Form
    {
        public FrmHastaBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tc;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmHastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskHastaTC.Text = tc;

            SqlCommand komut = new SqlCommand("Select * from TBLHASTALAR where HastaTC=" + tc, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtHastaAd.Text = dr[1].ToString();
                txtHastaSoyad.Text = dr[2].ToString();
                mskHastaTel.Text = dr[4].ToString();
                txtHastaSifre.Text = dr[5].ToString();
                cmbHastaCinsiyet.Text = dr[6].ToString();

            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update TBLHASTALAR set HastaAd=@p1,HastaSoyad=@p2,HastaTel=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=" + mskHastaTC.Text, bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtHastaAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtHastaSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskHastaTel.Text);
            komut2.Parameters.AddWithValue("@p4", txtHastaSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbHastaCinsiyet.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
