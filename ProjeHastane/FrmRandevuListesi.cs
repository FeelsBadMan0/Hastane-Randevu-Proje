using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjeHastane
{
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLRANDEVULAR", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

    }
}
