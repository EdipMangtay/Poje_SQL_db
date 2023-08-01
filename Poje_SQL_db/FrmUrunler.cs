using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poje_SQL_db
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            txturunid.Visible = true;
            label.Visible = true;

            baglanti.Open();
            SqlCommand komut = new SqlCommand(" select * from TBLURUNLER ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("INSERT INTO TBLURUNLER(URUNAD,URUNMARKA,KATEGORI,URUNALISFIYAT,URUNSATISFIYAT,URUNSTOK) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut1.Parameters.AddWithValue("@p1", txturunad.Text);
            komut1.Parameters.AddWithValue("@p2", txturunmarka.Text);
            komut1.Parameters.AddWithValue("@p3", txtkategori.Text);
            komut1.Parameters.AddWithValue("@p4", decimal.Parse(txtalıs.Text));
            komut1.Parameters.AddWithValue("@p5", decimal.Parse(txtsatıs.Text));
            komut1.Parameters.AddWithValue("@p6", txtstok.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txturunid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txturunad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txturunmarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtkategori.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtalıs.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsatıs.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtstok.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


        }

        private void Btnguncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TBLURUNLER set URUNAD =@P1 where URUNID = @p2", baglanti);
            komut4.Parameters.AddWithValue("@P1", txturunad.Text);
            komut4.Parameters.AddWithValue("@p2", txturunmarka.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Başarılı");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // yolum arızalı deleti, bir daha yaz
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TBLURUNLER where URUNID = @p1", baglanti);
            komut3.Parameters.AddWithValue("@p1",txturunid.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {

        }
    }
}
