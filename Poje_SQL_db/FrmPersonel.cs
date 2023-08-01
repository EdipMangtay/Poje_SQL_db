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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True");

        private void BtnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLPERSONEL", baglanti);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();




        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into TBLPERSONEL(PERSONELADSOYAD,PERSONELMAAS) VALUES (@P1,@P2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtperad.Text);
            komut1.Parameters.AddWithValue("@p2", decimal.Parse(txtpermaas.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Kaydedildi");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtpersonelid.Visible = true;
            label1.Visible = true;

            txtpersonelid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtperad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // cell stun anlamında
            txtpermaas.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Delete from TBLPERSONEL where PERSONELID =@P1", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtpersonelid.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Silindi");
        }

        private void Btnguncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TBLPERSONEL set PERSONELMAAS= @P1 WHERE PERSONELID= @P2", baglanti);
            komut4.Parameters.AddWithValue("@p2", txtpersonelid.Text);
            komut4.Parameters.AddWithValue("@p1", decimal.Parse(txtpermaas.Text));
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");


        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {

        }
    }
}
