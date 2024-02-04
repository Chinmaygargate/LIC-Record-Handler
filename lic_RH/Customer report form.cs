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
    public partial class Customer_report_form : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        india  ds = new india ();
        ReportDocument drs = new ReportDocument();
        
        public Customer_report_form()
        {
            InitializeComponent();
        }

        private void Customer_report_form_Load(object sender, EventArgs e)
        {
            try
            {
                indiaTableAdapters.customerTableAdapter da = new indiaTableAdapters.customerTableAdapter();
                india.customerDataTable  dt = (india.customerDataTable )ds.Tables["customer"];
                drs.Load(@"‪E:\lic_RH\lic_RH\customer.rpt");
                da.Fill(dt);
                drs.SetDataSource(ds);
                crystalReportViewer1.ReportSource = drs;
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
            }
    }
}
