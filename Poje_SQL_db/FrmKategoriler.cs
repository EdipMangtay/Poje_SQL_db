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
using System.Net.Http.Headers;

namespace Poje_SQL_db
{
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }
        // Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True
        SqlConnection baglanti = new SqlConnection(@"Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True");
        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TBLKATEGORI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut); // Veri bağlayıcıdır
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("insert into TBLKATEGORI(KATEGORIAD) VALUES (@p1) ", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtkategorıad.Text);
            komut2.ExecuteNonQuery();          
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkdategorid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkategorıad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // cell stun anlamında
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TBLKATEGORI where KATEGORIID = @p1",baglanti);
            komut3.Parameters.AddWithValue("@p1", txtkdategorid.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void Btnguncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TBLKATEGORI set KATEGORIAD =@P1 where KATEGORIID = @p2",baglanti);
            komut4.Parameters.AddWithValue("@P1", txtkategorıad.Text);
            komut4.Parameters.AddWithValue("@p2", int.Parse(txtkdategorid.Text));
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
        }

        
    }
}
