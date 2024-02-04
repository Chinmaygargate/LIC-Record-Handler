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
    public partial class Forget_pass : Form
    {
        static string s1 = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        SqlConnection con = new SqlConnection(s1);
        SqlCommand cmd;
        string username, password;
        SqlDataReader dr;
        string name, pass, conf,s,q;
        public Forget_pass()
        {
            InitializeComponent();
        }

        private void Forget_pass_Load(object sender, EventArgs e)
        {
            frgt_user.Focus();
        }

        private void frgt_save_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                name = frgt_user.Text;
                pass = frgt_pass.Text;
                conf = frgt_conf.Text;
                if (name == "")
                {
                    MessageBox.Show("Please enter username...", "Information");
                    frgt_user.Focus();
                }

                else if (pass == "")
                {
                    MessageBox.Show("Please enter password...", "Information");
                    frgt_pass.Focus();
                }
                else if (conf == "")
                {
                    MessageBox.Show("Please re-enter password...", "Information");
                    frgt_conf.Focus();
                }
                else
                {
                    cmd = new SqlCommand("select crname from account where crname='" + frgt_user.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        s = (string)dr["crname"];

                    }
                    dr.Close();

                    if (s != frgt_user.Text)
                    {
                        MessageBox.Show("Such user does not exist..", "Information");
                        frgt_user.Text = "";
                        frgt_pass.Text = "";
                        frgt_conf.Text = "";
                    }
                    else
                    {
                        cmd = new SqlCommand("update account set crpass='" + frgt_pass.Text + "' where crname='" + frgt_user.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("update login set password='" + frgt_pass.Text + "' where username='" + frgt_user.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password successfully updated", "Information");
                        MessageBox.Show("Re-login..", "Information");
                        this.Close();
                        Application.Restart();
                    }
                 
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            
            }
            con.Close();

        }

        private void frgt_conf_Leave(object sender, EventArgs e)
        {
            pass = frgt_pass.Text;
            conf = frgt_conf.Text;
            if (pass != conf)
            {
                MessageBox.Show("Password does not match..Re-enter it","Information");
                frgt_conf.Text = "";
                frgt_conf.Focus();

            }
        }

        private void frgt_clr_Click(object sender, EventArgs e)
        {
            frgt_user.Text = "";
            frgt_pass.Text = "";
            frgt_conf.Text = "";
        }

        private void frgt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void create_ac_btn_Click(object sender, EventArgs e)
        {
            create_ac cac = new create_ac();
            cac.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
