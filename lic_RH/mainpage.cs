using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lic_RH
{
    public partial class mainpage : Form
    {
        public mainpage()
        {
            InitializeComponent();
        }

        private void mainpage_Load(object sender, EventArgs e)
        {
           
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
             }

            private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");

        }

           

            private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Customer_report_form fm = new Customer_report_form();
                fm.Show();

            }

            private void advancedSearchingToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Searching_report_form fm1 = new Searching_report_form();
                fm1.Show();
                
             }

            private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                About abt = new About();
                abt.Show();
            }

            private void maturityClientsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                search_facility sc = new search_facility();
                sc.Show();
            }

            private void premiumClientsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Maturity_clients ms = new Maturity_clients();
                ms.Show();
            }

            private void premiumClientsToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                premium_clients pm = new premium_clients();
                pm.Show();
            }

            private void forgetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Forget_pass pass = new Forget_pass();
                pass.Show();
            }

            private void premiumManagementToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Premium_Management mn = new Premium_Management();
                mn.Show();
            }

              private void customerRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                regester reg = new regester();
                reg.Show();
            }

            private void policyRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Premium_calci c = new Premium_calci();
                c.Show();
            }

            private void viewPoliciesToolStripMenuItem_Click(object sender, EventArgs e)
            {
                View_policy v = new View_policy();
                v.Show();
            }

            
    }
}
