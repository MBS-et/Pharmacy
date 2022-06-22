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
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;

namespace Pharmacy
{
    public partial class Sign_Up : Form
    {
        public Point mouseLocation;
        string regex1 = "^(?=.*[a-z])";
        string regex2 = "^(?=.*[A-Z])";
        string regex3 = "^(?=.*[-+_!@#$%^&*., ?]).+$";
        string regex4 = "^(?=.*\\d)";
        string Code;
        public UnicodeEncoding ByteConverter = new UnicodeEncoding();
        public RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public byte[] plaintext;
        public byte[] encryptedtext;
        public Sign_Up()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCodeRq_Click(object sender, EventArgs e)
        {
            SendEmail se = new SendEmail();
            se.SendVerificationCode(txtEmail.Text, txtFname.Text);
            btnVerifyCode.Visible = true;
            btnCodeRq.Visible = false;
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            SendEmail code = new SendEmail();
            if (txtVerCode.Text.Equals(code.Code))
            {
                MessageBox.Show("Email Verified Please Continue with registeration");
                btnRegister.Enabled = true;
                btnVerifyCode.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid Code");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Regex p1 = new Regex(regex1);//lower
            Regex p2 = new Regex(regex2);//upper
            Regex p3 = new Regex(regex3);//special
            Regex p4 = new Regex(regex4);//digit
            Match m1 = p1.Match(txtPassword.Text);
            Match m2 = p2.Match(txtPassword.Text);
            Match m3 = p3.Match(txtPassword.Text);
            Match m4 = p4.Match(txtPassword.Text);
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
            if (txtPassword.Text.Length > 8)
            {
                label13.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label13.ForeColor = System.Drawing.Color.LightCoral;
            }
        }

        private void btnRedSignin_Click(object sender, EventArgs e)
        {
            new SignIn().Visible = true;
            this.Hide();
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            signupLayer2 sg = new signupLayer2();
            sg.Email = txtEmail.Text;
            sg.UserName = txtUsername.Text;
            sg.RecoveryEmail = txtRecEmail.Text;
            sg.EmployeeID=int.Parse(cbEmployeeID.SelectedValue.ToString());
            sg.PasswordEncypt = txtPassword.Text;
            plaintext = ByteConverter.GetBytes(sg.PasswordEncypt);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            sg.Password = ByteConverter.GetString(encryptedtext);
            sg.register();
            ClearTextBoxes();
            new SignIn().Visible=true;
            this.Hide();

        }

        private void Sign_Up_Load(object sender, EventArgs e)
        {
            try
            {
                String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
                SqlConnection conn = new SqlConnection(cn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("GetEmpoyeeID", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                cbEmployeeID.DataSource = dt;
                cbEmployeeID.DisplayMember =dt.Columns[0].ToString();
                cbEmployeeID.ValueMember = dt.Columns[1].ToString();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Password doesn't match");
                txtConfirmPass.Clear();
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(label16.ForeColor==Color.LightCoral|| label14.ForeColor == Color.LightCoral || label15.ForeColor == Color.LightCoral || label13.ForeColor == Color.LightCoral)
            {
                MessageBox.Show("Incorrect Password format please enter again");
                txtPassword.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPass.UseSystemPasswordChar = false;
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*  private byte[] Encryption(byte[] plaintext, RSAParameters rSAParameters, bool v)
          {
              throw new NotImplementedException();
          }*/
    }
}
