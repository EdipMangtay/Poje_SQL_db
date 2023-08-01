using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poje_SQL_db
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        SatisVtEntities db = new SatisVtEntities();

        private void button1_Click(object sender, EventArgs e)
        {
                var sorgu = from x in db.TBLADMINs where x.USERNAME == textBox1.Text && x.PASS == textBox2.Text select x;
            if (sorgu.Any())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş");

            }
        }
    }
}
