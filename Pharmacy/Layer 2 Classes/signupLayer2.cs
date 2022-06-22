using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Pharmacy
{
    internal class signupLayer2
    {

        public String PasswordEncypt;
       

        public string Email;
        public string Password;
        public string UserName;
        public string RecoveryEmail;
        public int EmployeeID;

        public void register()
        {
            SignUpDBConnection sdb= new SignUpDBConnection();
            sdb.RegisterUser(this);

    }

       public String encrypt()
        {
            SignUpDBConnection sdb = new SignUpDBConnection();
            return sdb.encrypt(this);

        }

    }
}
