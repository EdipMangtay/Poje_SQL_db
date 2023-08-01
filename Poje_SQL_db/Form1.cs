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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MANGTAY\SQLDERS;Initial Catalog=SatisVt;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriler fr = new FrmKategoriler();
            fr.Show();

        }

        private void Btnmusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri f2 = new FrmMusteri();
            f2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ürünlerin durum seviyesi
            SqlCommand komut = new SqlCommand("Execute TEST4",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // GRAFİĞE VERİ ÇEKME İŞLEMLERİ

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select KATEGORIAD,COUNT(*) AS 'STOK SAYISI' FROM TBLKATEGORI INNER JOIN TBLURUNLER ON TBLKATEGORI.KATEGORIID = TBLURUNLER.KATEGORI GROUP BY KATEGORIAD", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["KATEGORILER"].Points.AddXY(dr[0],dr[1]);
            }
            baglanti.Close();

            // GRAFİĞE VERİ ÇEKME 2
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select MUSTERISEHIR, COUNT(*) FROM TBLMUSTERI GROUP BY MUSTERISEHIR", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chart2.Series["SEHIR"].Points.AddXY(dr3[0], dr3[1]);
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUrunler fr3 = new FrmUrunler();
            fr3.Show();
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmPersonel fr4 = new FrmPersonel();
            fr4.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Frmislem fr5 = new Frmislem();
            fr5.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kasa frm = new Kasa();
            frm.Show();
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
