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
    public partial class View_policy : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        
        public View_policy()
        {
            InitializeComponent();
        }

        private void View_policy_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select pname from policyinfo", con);
                SqlDataReader reader = cmd1.ExecuteReader();
                AutoCompleteStringCollection MyCollection1 = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection1.Add(reader.GetString(0));
                }
                reader.Close();
                cust_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cust_txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cust_txt.AutoCompleteCustomSource = MyCollection1;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }

            try
            {
                dataGridView1.Refresh();
                con.Open();
               
                cmd = new SqlCommand("select * from policyinfo", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                headertext1();
                da.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();
      
        }


        public void headertext()
        {
            dataGridView1.Columns[0].HeaderText = "Plan Type";
            dataGridView1.Columns[1].HeaderText = "Plan Name";
            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[3].HeaderText = "Policy Term";
            dataGridView1.Columns[4].HeaderText = "PPT";
            dataGridView1.Columns[5].HeaderText = "Min Entry age";
            dataGridView1.Columns[6].HeaderText = "Max Entry age";
            dataGridView1.Columns[7].HeaderText = "Min SA";
            dataGridView1.Columns[8].HeaderText = "Max SA";
            dataGridView1.Columns[9].HeaderText = "Payment Mode";
        }

        public void headertext1()
        {
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 210;
            dataGridView1.Columns[2].Width = 320;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
        }

        private void searchbyname_Click(object sender, EventArgs e)
        {
            
            try
            {
                dataGridView1.Refresh();
                con.Open();
         
                cmd = new SqlCommand("select * from policyinfo where pname='" + cust_txt .Text  + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                headertext1();
                da.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Refresh();
                con.Open();

                cmd = new SqlCommand("select * from policyinfo", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                headertext1();
                da.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();
      
        }


    }
}
