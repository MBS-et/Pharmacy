using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    internal class ForgetLayer2
    {

        public string Password;
        public string UserName;
        public string RecoveryEmail;

        public void ChangePassword()
        {
            ForgetPasswdDbConnection fp=new ForgetPasswdDbConnection();
            fp.ChangePassword(this);


        }










    }
}
