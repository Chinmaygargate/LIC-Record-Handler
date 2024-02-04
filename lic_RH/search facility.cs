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
    public partial class search_facility : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        string policyno, dom, due, doc,custname;
        int planno;
        public search_facility()
        {
            InitializeComponent();
        }

        private void search_facility_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select cust_name from customer", con);
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
                MessageBox.Show(""+ex);
            
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                custname = cust_txt.Text;
                cmd = new SqlCommand("select * from customer where cust_name='"+custname +"'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                da.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void to_picker_Leave(object sender, EventArgs e)
        {
           
        }
        DateTime d,d1;
        private void search_btn_Click(object sender, EventArgs e)
        {
            try
            {
                d = Convert.ToDateTime (from_picker.Value.ToShortDateString());
                d1 = Convert.ToDateTime(to_picker.Value.ToShortDateString());
                string sp = d.ToString("MM-dd-yyyy");
                string ps=d1.ToString ("MM-dd-yyyy");
                con.Open();
                cmd = new SqlCommand("select * from customer where doc between '" + sp + "' and '" + ps + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                int k;
                k=Convert.ToInt32 (dataGridView1.Rows.Count .ToString ());
                label24.Text = (k - 1).ToString ();
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
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Policy No";
            dataGridView1.Columns[2].HeaderText = "Branch";
            dataGridView1.Columns[3].HeaderText = "Date";
            dataGridView1.Columns[4].HeaderText = "Contact";
            dataGridView1.Columns[5].HeaderText = "DOB";
            dataGridView1.Columns[6].HeaderText = "DOC";
            dataGridView1.Columns[7].HeaderText = "PlanNo";
            dataGridView1.Columns[8].HeaderText = "P-Term";
            dataGridView1.Columns[9].HeaderText = "PPT";
            dataGridView1.Columns[10].HeaderText = "SA";
            dataGridView1.Columns[11].HeaderText = "DOM";
            dataGridView1.Columns[12].HeaderText = "Premium";
            dataGridView1.Columns[13].HeaderText = "Mode";
            dataGridView1.Columns[14].HeaderText = "CGST";
            dataGridView1.Columns[15].HeaderText = "SGST";
            dataGridView1.Columns[16].HeaderText = "Age";
            dataGridView1.Columns[17].HeaderText = "DLP";
            dataGridView1.Columns[18].HeaderText = "Agent-Code";
            dataGridView1.Columns[19].HeaderText = "Agent Name";
            dataGridView1.Columns[20].HeaderText = "Next-Due";
        }
        string crnames;
        private void searchbyname_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Refresh();
                con.Open();
                crnames = cust_txt.Text;
                cmd = new SqlCommand("select * from customer where cust_name='" + crnames+ "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                int k;
                k = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
                label24.Text = (k - 1).ToString();
                da.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();
        }

        public void selectrow()
        {
            try
            {
                DateTime d1, d2, d3, d4, d5;
                label5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label21.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                label22.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                label29.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
               
                d1 = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                label30.Text = d1.ToShortDateString();

                DateTime d = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
                label31.Text = d.ToShortDateString();
                
                label32.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[8].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                label33.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                
                d2 = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[11].Value.ToString());
                label34.Text = d2.ToShortDateString();
                
              
                label35.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                label36.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                label37.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                label38.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                label39.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                
                d2 = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[17].Value.ToString());
                label40.Text = d2.ToShortDateString();
               
                
                label41.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                label42.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                
                d3 = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[20].Value.ToString());
                label43.Text = d3.ToShortDateString();
                
            }
            catch (Exception ex)
            {
               
            
            }
            }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            selectrow();
        }

        private void this_month_btn_Click(object sender, EventArgs e)
        {
            try
            {
                d = Convert.ToDateTime(from_picker.Value.ToShortDateString());
                d1 = Convert.ToDateTime(to_picker.Value.ToShortDateString());
                string sp = d.ToString("MM-dd-yyyy");
                string ps = d1.ToString("MM-dd-yyyy");
                con.Open();
                cmd = new SqlCommand("select * from customer where due between '" + sp + "' and '" + ps + "' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                int k;
                k = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
                label24.Text = (k - 1).ToString();
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
