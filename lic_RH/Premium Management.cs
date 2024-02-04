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
    public partial class Premium_Management : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;

        public Premium_Management()
        {
            InitializeComponent();
        }

        private void Premium_Management_Load(object sender, EventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("select cust_name from customer", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["cust_name"]);
            }
            dr.Close();
            con.Close();
            comboBox1.SelectedItem = comboBox1.SelectedIndex = 0;
            
        }
        string s;
        DateTime d1;
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
           
            cmd = new SqlCommand("select premi,mode,due from customer where cust_name='" + comboBox1.SelectedItem + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                textBox1.Text = (string)dr["premi"].ToString();
                textBox2.Text = (string)dr["mode"];
                d1 = Convert.ToDateTime(dr["due"]);

            }
            dr.Close();
            textBox3.Text = d1.ToShortDateString();
            con.Close();

        }
        DateTime d2,d3;
        DateTime x, y, z, w;
        string a, b, c, d;
        public void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {

                if (radioButton1.Checked && textBox2.Text =="Yearly")
                {
                   
                    x = DateTime.Parse(d1.AddYears (1).ToShortDateString ());
                    a = x.ToString("MM-dd-yyyy");

                    cmd = new SqlCommand("update customer set due='" + a + "' where cust_name='" + comboBox1.SelectedItem + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Information Updated");
                }
                else if (radioButton1.Checked && textBox2.Text =="Half Yearly")
                {
                    x = DateTime.Parse(d1.AddMonths (6).ToShortDateString());
                    a = x.ToString("MM-dd-yyyy");

                    cmd = new SqlCommand("update customer set due='" + a + "' where cust_name='" + comboBox1.SelectedItem + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Information Updated");
                }

                else if (radioButton1.Checked && textBox2.Text=="Quarterly")
                {
                    x = DateTime.Parse(d1.AddMonths (3).ToShortDateString());
                    a = x.ToString("MM-dd-yyyy");

                    cmd = new SqlCommand("update customer set due='" + a + "' where cust_name='" + comboBox1.SelectedItem + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Information Updated");
                }
                else if (radioButton1.Checked && textBox2.Text =="Monthly")
                {
                    x = DateTime.Parse(d1.AddMonths (1).ToShortDateString());
                    a = x.ToString("MM-dd-yyyy");

                    cmd = new SqlCommand("update customer set due='" + a + "' where cust_name='" + comboBox1.SelectedItem + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Information Updated");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

    }
}

