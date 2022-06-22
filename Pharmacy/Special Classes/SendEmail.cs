using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    internal class SendEmail
    {
        static string code;


        SmtpClient client = new SmtpClient()
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new System.Net.NetworkCredential()
            {
                UserName = "penealfeleke17@gmail.com",
                Password = "lvppkyomnqewgvjc"
            }
        };

        public void SendVerificationCode(string Email, string Name)
        {
            VerificationCode VC = new VerificationCode();
            code = VC.GeneratedCode;
            MailAddress FromEmail = new MailAddress("penealfeleke17@gmail.com", "MBS Pharmacy");
            MailAddress ToEmail = new MailAddress(Email, Name);
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Verification Code",
                Body = "Your Verfication Code is:" + code
            };
            Message.To.Add(ToEmail);
            client.SendCompleted += Client_SendCompleted; ;
            client.SendMailAsync(Message);
            // MessageBox.Show(CG.RandomCode());

        }
        public string Code
        {
            get { return code; }
        }

        private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
           
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            MessageBox.Show("Your Vervication code has been sent please check your email");

        }
    }
}
