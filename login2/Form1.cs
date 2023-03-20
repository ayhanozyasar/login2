using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace login2
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
       
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection("Data Source=DESKTOP-5B9OBO8;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select*From Kullanici_bilgi where kullanici_adi='" + textBox1.Text +
                "'And sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                MessageBox.Show("Tebrikler giriş başarılı");

                Form2 f2 = new Form2();
                
                f2.Show();
                
                
            }
            else
            {
                MessageBox.Show("Giriş başarısız");
            }
           con.Close();
        }
    }
}
