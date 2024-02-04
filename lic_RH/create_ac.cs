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
    public partial class create_ac : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        SqlDataReader dr;
        string s, q;
        string name, contact, email, pass, conf, code,gender;
        string a, b, c, d,f,g;
        public create_ac()
        {
            InitializeComponent();
        }
        private void save_create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                con.Open();
                name = name_create_txt.Text;
                code = code_create_text.Text;
                email = email_create_txt.Text;
                pass = pass_create_txt.Text;
                conf = confirm_create_txt.Text;
                contact = contact_create_txt.Text;

                if (male_create_rd.Checked == true)
                {
                   gender="";
                   gender = male_create_rd.Text;


                }
                else if (fem_create_rd.Checked == true)
                {
                    gender="";
                    gender = fem_create_rd.Text;
                }
                
                cmd = new SqlCommand("select * from account where crname='"+name_create_txt .Text +"'", con);
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    
                    a = (string)dr["crname"];
                    b = (string)dr["crgender"];
                    c = (string)dr["crcode"];
                    d = (string)dr["crcontact"];
                    f = (string)dr["crpass"];
                    g = (string)dr["cremail"];
                    
                }
                dr.Close();
               
                if (a!=name_create_txt .Text)
                {
                    if (name == "" || code == "" || email == "" || gender == "" || pass == "" || conf == "" || contact == "")
                    {
                        MessageBox.Show("Please enter all information...", "Information");
                    }
                
                    if (Validates())
                    {
                        cmd = new SqlCommand("insert into account values('" + name + "','" + gender + "','" + code + "','" + contact + "','" + pass + "','" + email + "')", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into login values('" + name + "','" + pass + "')", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account created successfully", "Information");
                        clr();
                    }
                }
                else
                {

                    MessageBox.Show("Such user already exists..", "Information");
                    clr();
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(""+ex);
            }
        }

        protected bool Validates()
        {
            string msg = "";
            int f = 0;
            Regex patName = new Regex(@"[a-zA-z]+");
            Regex patemail = new Regex(@"[a-zA-z.0-9]+@[a-z]+.[a-z]+");
            Regex patcontactno = new Regex(@"[0-9]{10,}");
            Regex patrollno = new Regex(@"[0-9]+");

            if (!patName.IsMatch(name_create_txt .Text))
            {
                msg += "Name must contain only alphabates\n";
                f++;
            }

            if (!patemail.IsMatch(email_create_txt.Text))
            {
                msg += "Please enter valide email-id\n";
                f++;
            }

            if (!patrollno.IsMatch(code_create_text.Text))
            {
                msg += "Code contain only numbers\n";
                f++;
            }
            if (!patcontactno.IsMatch(contact_create_txt.Text))
            {
                msg += "Contact contain only 10 digit numbers\n";
                f++;
            }
            
            if (f == 0)
                return true;
            else
            {
                MessageBox.Show(msg + "");
                return false;
            }
        }
        private void clr_create_btn_Click(object sender, EventArgs e)
        {
            clr();
        }

        void clr()
        {
            name_create_txt.Text = "";
            email_create_txt.Text = "";
            pass_create_txt.Text = "";
            code_create_text.Text = "";
            contact_create_txt.Text = "";
            confirm_create_txt.Text = "";
            male_create_rd.Checked = false;
            fem_create_rd.Checked = false;
        
        }

        private void exit_create_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirm_create_txt_Leave(object sender, EventArgs e)
        {
            pass = pass_create_txt.Text;
            conf = confirm_create_txt.Text;
            if (pass != conf)
            {
                MessageBox.Show("Password does not match..Re-enter it", "Information");
                confirm_create_txt.Text = "";
                confirm_create_txt.Focus();

            }
        }

        private void create_ac_Load(object sender, EventArgs e)
        {

        }

       
    }
}
