using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data .SqlClient ;
using System.Configuration;

namespace lic_RH
{
       
    public partial class login : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        string username, password;
        SqlDataReader dr;
        string s, q;
        int temp;
        int attempt = 1;

        
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {i
            try
            {
                con.Open();
                username = login_usr.Text;
                password = login_pass.Text;
                if (username == "")
                {
                    MessageBox.Show("Please enter username...", "Information");
                    login_usr.Focus();
                }

                else if (password == "")
                {
                    MessageBox.Show("Please enter password...", "Information");
                    login_pass.Focus();
                }
                else
                {
                    cmd = new SqlCommand("select * from login where username='"+username+"' ", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        s = (string)dr["username"];
                        q = (string)dr["password"];
                    }

                    dr.Close();
                    if (s.Equals(username) && q != password)
                    {
                        if (attempt < 3)
                        {
                            MessageBox.Show("Please enter correct password..", "Information");
                            login_pass.Clear();
                            login_pass.Focus();
                            attempt = attempt + 1;
                        }
                        else
                        {
                            MessageBox.Show("Please change your password..", "Information");
                            frgt_btn.Visible = true;
                            login_btn.Enabled = false;

                        }

                    }

                    else if (s.Equals(username) && q.Equals(password))
                    {

                        MessageBox.Show("Login Successful..", "Information");
                        temp = 1;
                        mainpage mn = new mainpage();
                        mn.Show();
                        login_usr.Text = "";
                        login_pass.Text = "";

                    }


                    else if (s.Equals(username) && q != password)
                    {
                        if (attempt < 3)
                        {
                            MessageBox.Show("Please enter correct password..", "Information");
                            login_pass.Text = "";
                            attempt = attempt + 1;
                        }
                        else
                        {
                            MessageBox.Show("Sorry Login fails...", "Information");
                            MessageBox.Show("Please verify your password...", "Information");
                            login_btn.Enabled = false;
                            frgt_btn.Visible = true;


                        }
                    }

                    else if (q.Equals(password) && s != (username))
                    {
                        if (attempt < 3)
                        {
                            MessageBox.Show("Please enter correct username..", "Information");
                            login_usr.Text = "";
                            attempt = attempt + 1;
                        }
                        else
                        {
                            MessageBox.Show("Sorry Login fails...", "Information");
                            MessageBox.Show("Please verify your username from admin...", "Information");
                            this.Close();

                        }
                    }

                    else
                    {

                        MessageBox.Show("Sorry..You have not registered member..", "Information");
                        login_usr.Clear();
                        login_pass.Clear();
                        create_ac ac = new create_ac();
                        ac.Show();
                    }   
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Sorry..You have not registered member..", "Information");
                create_ac ac = new create_ac();
             ac.Show();
            }
            con.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            frgt_btn.Visible = false;
        }

        private void clr_btn_Click(object sender, EventArgs e)
        {
            login_usr.Text = "";
            login_pass.Text = "";

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frgt_btn_Click(object sender, EventArgs e)
        {
            Forget_pass ps = new Forget_pass();
            ps.Show();
       
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void login_usr_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
