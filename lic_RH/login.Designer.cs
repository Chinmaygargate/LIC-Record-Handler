namespace lic_RH
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_usr = new System.Windows.Forms.TextBox();
            this.login_pass = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.clr_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.frgt_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(93, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // login_usr
            // 
            this.login_usr.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_usr.Location = new System.Drawing.Point(334, 143);
            this.login_usr.Name = "login_usr";
            this.login_usr.Size = new System.Drawing.Size(183, 32);
            this.login_usr.TabIndex = 2;
            this.login_usr.Text = "a";
            this.login_usr.TextChanged += new System.EventHandler(this.login_usr_TextChanged);
            // 
            // login_pass
            // 
            this.login_pass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_pass.Location = new System.Drawing.Point(334, 218);
            this.login_pass.Name = "login_pass";
            this.login_pass.PasswordChar = '*';
            this.login_pass.Size = new System.Drawing.Size(183, 32);
            this.login_pass.TabIndex = 3;
            this.login_pass.TextChanged += new System.EventHandler(this.login_pass_TextChanged);
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.White;
            this.login_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.login_btn.Location = new System.Drawing.Point(131, 305);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(134, 54);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // clr_btn
            // 
            this.clr_btn.BackColor = System.Drawing.Color.White;
            this.clr_btn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clr_btn.ForeColor = System.Drawing.Color.Black;
            this.clr_btn.Location = new System.Drawing.Point(291, 305);
            this.clr_btn.Name = "clr_btn";
            this.clr_btn.Size = new System.Drawing.Size(136, 54);
            this.clr_btn.TabIndex = 5;
            this.clr_btn.Text = "Clear";
            this.clr_btn.UseVisualStyleBackColor = false;
            this.clr_btn.Click += new System.EventHandler(this.clr_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.White;
            this.exit_btn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.Location = new System.Drawing.Point(449, 305);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(136, 54);
            this.exit_btn.TabIndex = 6;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // frgt_btn
            // 
            this.frgt_btn.BackColor = System.Drawing.Color.White;
            this.frgt_btn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frgt_btn.ForeColor = System.Drawing.Color.Red;
            this.frgt_btn.Location = new System.Drawing.Point(291, 385);
            this.frgt_btn.Name = "frgt_btn";
            this.frgt_btn.Size = new System.Drawing.Size(109, 59);
            this.frgt_btn.TabIndex = 7;
            this.frgt_btn.Text = "Forget Password";
            this.frgt_btn.UseVisualStyleBackColor = false;
            this.frgt_btn.Click += new System.EventHandler(this.frgt_btn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lic_RH.Properties.Resources.HD_Web_Solutios_Portfolio;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(148, 0);
            this.Controls.Add(this.frgt_btn);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.clr_btn);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.login_pass);
            this.Controls.Add(this.login_usr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox login_usr;
        private System.Windows.Forms.TextBox login_pass;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button clr_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button frgt_btn;
    }
}