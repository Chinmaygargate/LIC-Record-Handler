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
using System.Text.RegularExpressions;
namespace lic_RH
{
    public partial class regester : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        string name, contact, dates, dob, doc, dom, dlp, agname, due;
        string policyno, branch, agcode;
        string y1, y2, y3, y4;
        int p1, p2, p3, age, premi;
        double cgst, sgst,sa;
        string crnames, crcodes;
        DateTime d,d1,d2,d3,d4,d5;
        string sp1, sp2, sp3, sp4;
        public regester()
        {
            InitializeComponent();
        }
        private void login_cust_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                name = name_cust.Text;
                contact = contact_cust.Text;
                
                dates = date_sys.Value .ToShortDateString ();
                d2 = DateTime.Parse(dates);
                sp1 = d2.ToString("MM-dd-yyyy");
               
                dob = dob_picker.Value.ToShortDateString();
                d3 = DateTime.Parse(dob);
                sp2 = d3.ToString("MM-dd-yyyy");
                
                doc = doc_picker.Value.ToShortDateString ();
                d = DateTime.Parse(doc);
                string sp = d.ToString("MM-dd-yyyy");
                
                dom = dom_picker.Value.ToShortDateString();
                d4 = DateTime.Parse(dom);
                sp3 = d4.ToString("MM-dd-yyyy");
                
                dlp = dlp_picker.Value.ToShortDateString();
                d5 = DateTime.Parse(dlp);
                sp4 = d5.ToString("MM-dd-yyyy");
                
                due = due_picker.Value.ToShortDateString();
                d1 = DateTime.Parse(due);
                string spp = d1.ToString("MM-dd-yyyy");
                
                policyno = policy_cust.Text;
                branch = branch_cust.Text;
                sa=Convert.ToDouble(sa_cust.Text);
                premi = Convert.ToInt32 (premi_cust.Text); 
                cgst = Convert.ToDouble(cgst_cust.Text);
                sgst = Convert.ToDouble(sgst_cust.Text);
                age = Convert.ToInt32(age_cust.Text);

                p1 = Convert.ToInt32 (t1_cust.Text);
                p2 = Convert.ToInt32(t2_cust.Text);
                p3 = Convert.ToInt32(t3_cust.Text);

                if (yearly_mode.Checked == true)
                {
                    y1 = yearly_mode.Text;
                }
                else if (half_yearly_mode.Checked == true)
                {
                    y1 = half_yearly_mode.Text;
                }
                
                else if (quarterly_mode .Checked  == true)
                {
                    y1 = quarterly_mode.Text;
                }

                else if (monthly_mode.Checked == true)
                {
                    y1 = monthly_mode.Text;
                }
                if (Validates ())
                {
                    cmd = new SqlCommand("insert into customer values('" + name + "','" + policyno + "'," + branch + ",'" + sp1 + "','" + contact + "','" + sp2 + "','" + sp + "'," + p1 + "," + p2 + "," + p3 + ",'" + sa + "','" + sp3 + "'," + premi + ",'" + y1 + "','" + cgst + "','" + sgst + "'," + age + ",'" + sp4 + "','" + agent_cust.Text + "','" + agname_cust.Text + "','" + spp + "') ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data successfully inserted","Information");
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter all details", "Information");
            }
            con.Close();
            
        }
        private void dob_picker_ValueChanged(object sender, EventArgs e)
        {
            DateTime  ss =dob_picker.Value .Date ;
            DateTime d = DateTime.Today;
             TimeSpan spn = d - ss;
             int x = spn.Days;
            age_cust.Text  = x / 365+"";
        }

        private void exit_cust_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void regester_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select crname,crcode from account", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                { 
                agname_cust .Text  =(string)dr["crname"];
                agent_cust.Text= (string)dr["crcode"];
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(""+ex);
            
            }
        }

        int pterm;
        private void yearly_mode_CheckedChanged(object sender, EventArgs e)
        {          
            pterm = Convert.ToInt32(t2_cust.Text);
            if (yearly_mode.Checked == true)
            {
                due_picker.Value  = doc_picker.Value.AddYears(1);
                dlp_picker.Value = doc_picker.Value.AddYears(pterm - 1);
            }

        }

        private void half_yearly_mode_CheckedChanged(object sender, EventArgs e)
        {
            pterm = Convert.ToInt32(t2_cust.Text);
            int mon = pterm * 12;
            if (half_yearly_mode.Checked == true)
            {
                due_picker.Value = doc_picker.Value.AddMonths (6);
                dlp_picker.Value = doc_picker.Value.AddMonths (mon - 6);
            }

        }

        private void quarterly_mode_CheckedChanged(object sender, EventArgs e)
        {
            pterm = Convert.ToInt32(t2_cust.Text);
            int mon = pterm * 12;
            if (quarterly_mode .Checked  == true)
            {
                due_picker.Value = doc_picker.Value.AddMonths (3);
                dlp_picker.Value = doc_picker.Value.AddMonths(mon - 9);
            }

        }

        private void monthly_mode_CheckedChanged(object sender, EventArgs e)
        {
            pterm = Convert.ToInt32(t2_cust.Text);
            int mon = pterm * 12;
            if (monthly_mode.Checked == true)
            {
                due_picker.Value = doc_picker.Value.AddMonths (1);
                dlp_picker.Value = doc_picker.Value.AddMonths(mon - 11);

            }

        }

        private void t2_cust_Leave(object sender, EventArgs e)
        {
            try
            {
                dom_picker.ResetText();
                int pterm = Convert.ToInt32(t2_cust.Text);
                dom_picker.Value = dom_picker.Value.AddYears(pterm);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Policy term contain only numbers","Information");
                t2_cust.Clear();
                t2_cust.Focus();
            }
            }

       protected bool Validates()
        {

            string msg = "";
            int f = 0;
            if (name_cust.Text == "" || policy_cust.Text == "" || branch_cust.Text == "" || contact_cust.Text == "" || sa_cust.Text == "" || premi_cust.Text == "" || t1_cust.Text == "" || t2_cust.Text == "" || t3_cust.Text == "" || cgst_cust.Text == "" || sgst_cust.Text == "" || agent_cust.Text == "" || agname_cust.Text == "")
            {
                f++;
            }
            if (f == 0)
                return true;
            else
            {
                MessageBox.Show("Plese enter all details","Information");
                return false;
            }
        }

        private void name_cust_Leave(object sender, EventArgs e)
        {
            Regex patName = new Regex(@"[a-zA-z]+");
            if (!patName.IsMatch(name_cust.Text))
            {
                MessageBox.Show("Customer name must contain only alphabates","Information");
            name_cust.Focus();
            }
         }

        private void policy_cust_Leave(object sender, EventArgs e)
        {
            Regex patrollno = new Regex(@"[0-9]+");
            if (!patrollno.IsMatch(policy_cust.Text))
            {
                MessageBox.Show("Policy number contain only numbers","Information");
                policy_cust.Focus();
            }
            }

        private void branch_cust_Leave(object sender, EventArgs e)
        {
            Regex patrollno = new Regex(@"[0-9]+");
            if (!patrollno.IsMatch(branch_cust .Text))
            {
                MessageBox.Show("Branch number contain only numbers","Information");
               branch_cust .Focus();
            }
        }

        private void contact_cust_Leave(object sender, EventArgs e)
        {
            Regex patcontactno = new Regex(@"[0-9]{10,}");
            if(!patcontactno.IsMatch (contact_cust .Text ))
            {
                MessageBox.Show("Contact contain only 10 digit numbers","Information");
                contact_cust.Focus();
            }
            }

        private void t1_cust_Leave(object sender, EventArgs e)
        {
            Regex patrollno = new Regex(@"[0-9]+");
            if (!patrollno.IsMatch(t1_cust.Text))
            {
                MessageBox.Show("Plan number contain only numbers","Information");
                t1_cust.Focus();
            }
            
        }

        private void t3_cust_Leave(object sender, EventArgs e)
        {
            Regex patrollno = new Regex(@"[0-9]+");
            if (!patrollno.IsMatch(t3_cust.Text))
            {
                MessageBox.Show("PPT number contain only numbers","Information");
                t3_cust.Focus();
            }
            
        }
        
        private void age_cust_Leave(object sender, EventArgs e)
        {
            try
            {
                age = Convert.ToInt32(age_cust .Text );
                if (age<=0 || age_cust .Text =="")
                {
                    MessageBox.Show("Age must be greater than 0", "Information");
                    dob_picker.Focus();
                }
             
            }
            catch (Exception ex)
            {
             dob_picker.Focus();
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_policy v = new View_policy();
            v.Show();
        }
    }
}
