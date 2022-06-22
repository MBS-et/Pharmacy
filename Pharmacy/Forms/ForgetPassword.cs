using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class ForgetPassword : Form
    {
        public Point mouseLocation;
        public ForgetPassword()
        {
            InitializeComponent();
        }
        string regex1 = "^(?=.*[a-z])";
        string regex2 = "^(?=.*[A-Z])";
        string regex3 = "^(?=.*[-+_!@#$%^&*., ?]).+$";
        string regex4 = "^(?=.*\\d)";
        string Code;
        

       
        public void go()
        {
            new SignIn().Visible = true;
            this.Hide();
        }

        private void btnCodeRq_Click_1(object sender, EventArgs e)
        {
            SendEmail se = new SendEmail();
            se.SendVerificationCode(txtRecoveryEmail.Text, txtUserName.Text);
        }

        private void btnVerifyCode_Click_1(object sender, EventArgs e)
        {
            SendEmail code = new SendEmail();
            if (txtVerificationCode.Text.Equals(code.Code))
            {
                MessageBox.Show("Email Verified Please Continue with Changing Your Password");
                btnVerifyCode.Enabled = false;
                label2.Visible = true;
                label16.Visible = true;
                label15.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                txtNewPassword.Visible = true;
                btnChangePassword.Visible = true;
                checkBox1.Visible=true;

            }
            else
            {
                MessageBox.Show("Invalid Code");
            }
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            ForgetLayer2 fg2 = new ForgetLayer2();
            fg2.UserName = txtUserName.Text;
            fg2.Password = txtNewPassword.Text;
            fg2.ChangePassword();
        }

        private void txtNewPassword_TextChanged_1(object sender, EventArgs e)
        {

            Regex p1 = new Regex(regex1);//lower
            Regex p2 = new Regex(regex2);//upper
            Regex p3 = new Regex(regex3);//special
            Regex p4 = new Regex(regex4);//digit
            Match m1 = p1.Match(txtNewPassword.Text);
            Match m2 = p2.Match(txtNewPassword.Text);
            Match m3 = p3.Match(txtNewPassword.Text);
            Match m4 = p4.Match(txtNewPassword.Text);
            if (m1.Success && m2.Success)
            {
                label16.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label16.ForeColor = System.Drawing.Color.LightCoral;
            }
            if (m3.Success)
            {
                label14.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label14.ForeColor = System.Drawing.Color.LightCoral;
            }
            if (m4.Success)
            {
                label15.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label15.ForeColor = System.Drawing.Color.LightCoral;
            }
            if (txtNewPassword.Text.Length > 8)
            {
                label13.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label13.ForeColor = System.Drawing.Color.LightCoral;
            }
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new SignIn().Visible = true;
            this.Hide();
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            if (label16.ForeColor == Color.LightCoral || label14.ForeColor == Color.LightCoral || label15.ForeColor == Color.LightCoral || label13.ForeColor == Color.LightCoral)
            {
                MessageBox.Show("Incorrect Password format please enter again");
                txtNewPassword.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtNewPassword.UseSystemPasswordChar = true;
                
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = false;
               
            }
        }
    }
}
