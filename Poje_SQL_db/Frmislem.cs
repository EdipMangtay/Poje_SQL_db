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
    public partial class Frmislem : Form
    {
        public Frmislem()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Execute HAREKETLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Delete from TBLHAREKET WHERE HAREKETID =@P1", baglanti);
            komut1.Parameters.AddWithValue("@p1", txthareketid.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem silindi");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txthareketid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txturun.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmusterı.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtpersonel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtadet.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txttutar.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            maskeddate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("insert into TBLHAREKET(URUN,MUSTERI,PERSONEL,ADET,TUTAR,TARIH) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut3.Parameters.AddWithValue("@p1", txturun.Text);
            komut3.Parameters.AddWithValue("@p2", txtmusterı.Text);
            komut3.Parameters.AddWithValue("@p3", txtpersonel.Text);
            komut3.Parameters.AddWithValue("@p4", txtadet.Text);
            komut3.Parameters.AddWithValue("@p5", txttutar.Text);
            komut3.Parameters.AddWithValue("@p6",Convert.ToDateTime(maskeddate.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Girildi");








        }

        private void Frmislem_Load(object sender, EventArgs e)
        {

        }
    }
}
