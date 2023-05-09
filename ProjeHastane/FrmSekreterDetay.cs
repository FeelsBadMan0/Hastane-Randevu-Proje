using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjeHastane
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string tc;
        private void FrmSekreterDetay_Load(object sender, System.EventArgs e)
        {
            lblTC.Text = tc;

            //Ad Soyad
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad from TBLSEKRETER where SekreterTC=" + lblTC.Text, bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString();
            }



            //Branslar Datagrid
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLBRANSLAR", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Doktorlar Datagrid
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' '+DoktorSoyad) as 'Doktor Adı',DoktorBrans from TBLDOKTORLAR", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branslar

            SqlCommand cmd2 = new SqlCommand("Select BransAd from TBLBRANSLAR", bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0].ToString());
            }


        }

        private void btnKaydet_Click(object sender, System.EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into TBLRANDEVULAR (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@p1", mskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@p2", mskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from TBLDOKTORLAR where DoktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }

            bgl.baglanti().Close();

        }

        private void btnOlustur_Click(object sender, System.EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLDUYURULAR (DUYURU) values(@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoktorPanel_Click(object sender, System.EventArgs e)
        {
            FrmDoktorPaneli dr = new FrmDoktorPaneli();
            dr.Show();
        }

        private void btnBransPanel_Click(object sender, System.EventArgs e)
        {
            FrmBrans br = new FrmBrans();
            br.Show();
        }

        private void btnRandevuListesi_Click(object sender, System.EventArgs e)
        {
            FrmRandevuListesi fr = new FrmRandevuListesi();
            fr.Show();
        }

        private void btnDuyurular_Click(object sender, System.EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }
    }
}
