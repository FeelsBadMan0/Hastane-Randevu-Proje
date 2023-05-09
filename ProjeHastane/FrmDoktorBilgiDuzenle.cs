using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjeHastane
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskDoktorTC.Text = tc;

            SqlCommand cmd = new SqlCommand("Select BransAd from TBLBRANSLAR", bgl.baglanti());
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                cmbDoktorBrans.Items.Add(dr1[0]);
            }


            SqlCommand komut = new SqlCommand("Select * from tbldoktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskDoktorTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtDoktorAd.Text = dr[1].ToString();
                txtDoktorSoyad.Text = dr[2].ToString();
                cmbDoktorBrans.Text = dr[3].ToString();
                txtDoktorSifre.Text = dr[5].ToString();

            }

            bgl.baglanti().Close();


        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLDOKTORLAR set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtDoktorAd.Text);
            komut.Parameters.AddWithValue("@p2", txtDoktorSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbDoktorBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtDoktorSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskDoktorTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileniriz Başarılı Bir Şekilde Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
