using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class SignIn : Form
    {
        public Point mouseLocation;
        public SignIn()
        {
            InitializeComponent();

        }

        public static int id;
        GetUserId getid = new GetUserId();
        private void btnSignin_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication();
            if (authentication.LoginAuthentication(txtUsername.Text, txtPassword.Text) == "Found")
            {
                new Form1(int.Parse(getid.GetUserIdMethod(txtUsername.Text, txtPassword.Text))).Visible = true;
                this.Hide();
                ;
            }
            else
            {
                MessageBox.Show("Inccorrect username or password");
            }

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            new Sign_Up().Visible = true;
                this.Hide();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            new ForgetPassword().Visible = true;
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_Move(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

       
    }
}
