using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace lic_RH
{
    public partial class Premium_calci : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        string a, b, c, d,  f,g;
        string p, q, r, s, t, u;
        public Premium_calci()
        {
            InitializeComponent();
        }

        private void Premium_calci_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                p = comboBox1 .SelectedItem.ToString () ;
                q = textBox1.Text;
                r = textBox2.Text;
                a = textBox3.Text;
                b = textBox4.Text;
                c = textBox5.Text;
                d = textBox6.Text;
                f = textBox7.Text;
                t = textBox8.Text;
                u = textBox9.Text;
                con.Open();
                
                cmd = new SqlCommand("insert into policyinfo values('"+p+"','"+q+"','"+r+"','"+a+"','"+b+"','"+c+"','"+d+"','"+f+"','"+t+"','"+u+"')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information successfully stored", "Information");
     
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clr()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            
        }

          
    }
}
