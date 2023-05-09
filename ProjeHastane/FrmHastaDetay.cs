using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjeHastane
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void gecmis()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLRANDEVULAR where HastaTC=" + lblTC.Text, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void aktif()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLRANDEVULAR where RandevuBrans='" + cmbBrans.Text + "' and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        public string tc;


        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;


            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("select HastaAd,HastaSoyad from TBLHASTALAR where HastaTC=" + lblTC.Text, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }

            bgl.baglanti().Close();

            //Randevu Geçmiş
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLRANDEVULAR where HastaTC=" + lblTC.Text, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from TBLBRANSLAR", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select doktorAd,doktorSoyad from TBLDOKTORLAR where doktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }

            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLRANDEVULAR where RandevuBrans='" + cmbBrans.Text + "' and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaBilgiDuzenle fr = new FrmHastaBilgiDuzenle();
            fr.tc = lblTC.Text;
            fr.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBLRANDEVULAR set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where RandevuID=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            komut.Parameters.AddWithValue("@p2", rchSikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Başarılı Bir Şekilde Randevu Aldınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gecmis();
            aktif();
        }
    }
}
