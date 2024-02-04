using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;
namespace lic_RH
{
    public partial class Searching_report_form : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        india ds = new india();
        ReportDocument drs = new ReportDocument();
        public Searching_report_form()
        {
            InitializeComponent();
        }

        private void Searching_report_form_Load(object sender, EventArgs e)
        {
            try
            {
                indiaTableAdapters.customerTableAdapter da = new indiaTableAdapters.customerTableAdapter();
                india.customerDataTable dt = (india.customerDataTable)ds.Tables["customer"];
                drs.Load(@"‪E:\lic_RH\lic_RH\searchreport.rpt");
                da.Fill(dt);
                drs.SetDataSource(ds);
                crystalReportViewer1.ReportSource = drs;
                comboBox1.SelectedItem = comboBox1.SelectedIndex = 0;

            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                indiaTableAdapters.customerTableAdapter da = new indiaTableAdapters.customerTableAdapter();
                india.customerDataTable dt = (india.customerDataTable)ds.Tables["customer"];
                drs.Load(@"‪E:\lic_RH\lic_RH\searchreport.rpt");
                da.Fill(dt);
                drs.SetDataSource(ds);
                crystalReportViewer1.ReportSource = drs;
            }
            catch (Exception ex)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                textBox1.Text = "";
                label2.Visible = true;
                label2.Text = "Enter No";

                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select policy_no from customer", con);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    AutoCompleteStringCollection MyCollection1 = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection1.Add(reader.GetString(0));
                    }
                    reader.Close();
                    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox1.AutoCompleteCustomSource = MyCollection1;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);

                }
         
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "";
                label2.Visible = true;
                label2.Text = "Enter Name";
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
                    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox1.AutoCompleteCustomSource = MyCollection1;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);

                }
         
            }
        }
        int n1;
        string n2;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.SelectedIndex == 0)
                {
                    n1 = Convert.ToInt32(textBox1.Text);

                    con.Open();
                    SqlDataAdapter ss;
                    DataSet ps;
                    ss = new SqlDataAdapter("select cust_name,policy_no,doc,sa,dom,dlp,due from customer where policy_no=" + n1 + "", con);
                    ps = new DataSet();
                    ss.Fill(ps, "customer");
                    drs.Load(@"‪E:\lic_RH\lic_RH\searchreport.rpt");
                    drs.SetDataSource(ps);
                    crystalReportViewer1.ReportSource = drs;

                }
                if (comboBox1.SelectedIndex == 1)
                {
                    n2 = textBox1.Text;
                    SqlDataAdapter ss;
                    DataSet ps;
                    ss = new SqlDataAdapter("select cust_name,policy_no,doc,sa,dom,dlp,due from customer where cust_name='" + n2 + "'", con);
                    ps = new DataSet();
                    ss.Fill(ps, "customer");
                    drs.Load(@"‪E:\lic_RH\lic_RH\searchreport.rpt");
                    drs.SetDataSource(ps);
                    crystalReportViewer1.ReportSource = drs;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select correct option and enter valid details");
            }
            con.Close();
 
        }
    }
}
