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
    public partial class Maturity_clients : Form
    {

        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        string username, password;
        SqlDataReader dr;
        
        public Maturity_clients()
        {
            InitializeComponent();
        }
        DateTime d, d1;
        private void Maturity_clients_Load(object sender, EventArgs e)
        {
         
            DateTime d = DateTime.Now;
            DateTime  m = new DateTime(d.Year, d.Month, 1);
            DateTime l = m.AddMonths(1).AddDays(-1);

            d = Convert.ToDateTime(m.ToShortDateString());
            d1 = Convert.ToDateTime(l.ToShortDateString());
            string sp = d.ToString("MM-dd-yyyy");
            string ps = d1.ToString("MM-dd-yyyy");



            con.Open();

            cmd = new SqlCommand("select cust_name,dom from customer where dom between '" + sp + "' and '" + ps + "' ", con);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            headertext();
            headsize();
            da.Dispose();

            con.Close();
 



            
        }
        
        public void headertext()
        {
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Maturity Date";
        
        }

        public void headsize()
        {
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].Width = 200;

        
        }

        private void from_picker_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            d = Convert.ToDateTime(from_picker.Value.ToShortDateString());
            d1 = Convert.ToDateTime(to_picker.Value.ToShortDateString());
            string sp = d.ToString("MM-dd-yyyy");
            string ps = d1.ToString("MM-dd-yyyy");
         
                con.Open();
                
              cmd = new SqlCommand("select cust_name,dom from customer where dom between '" + sp + "' and '" + ps + "' ", con);
            
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                headertext();
                headsize();
            da.Dispose();
                
                con.Close();


        }


    }
}
