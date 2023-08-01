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
using System.Xml;

namespace Poje_SQL_db
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True");
        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select * from TBLMUSTERI", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void FrmMusteri_Load(object sender, EventArgs e)
        {         
            Listele();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from iller",baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                cmbsehir.Items.Add(dr["SEHİR"]);

            }
            baglanti.Close();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLMUSTERI (MUSTERIAD,MUSTERISOYAD,MUSTERISEHIR,MUSTERIBAKIYE) VALUES (@P1,@P2,@P3,@P4)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtbakiye.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri sisteme kaydedildi");
            Listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Delete FROM TBLMUSTERI where MUSTERIID = @P1", baglanti);
            komut2.Parameters.AddWithValue("@p1", Txtid.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Müşteri Silindi");
            baglanti.Close();
            Listele();


        }

        private void Btnguncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("Update TBLMUSTERI set MUSTERIAD = @P1,MUSTERISOYAD =@P2,MUSTERISEHIR = @P3,MUSTERIBAKIYE =@P4 WHERE MUSTERIID = @P5", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtad.Text);
            komut3.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut3.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut3.Parameters.AddWithValue("@p4", decimal.Parse(txtbakiye.Text));
            komut3.Parameters.AddWithValue("@p5", Txtid.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi başarılı");
            Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TBLMUSTERI where MUSTERIAD=@P1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
