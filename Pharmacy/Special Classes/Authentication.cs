using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Pharmacy
{
    internal class Authentication
    {
        public UnicodeEncoding ByteConverter = new UnicodeEncoding();
        public RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public byte[] plaintext;
        public byte[] encryptedtext;

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        public string LoginAuthentication(string username, string password)
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            DataSet ds = new DataSet();

       

            SqlDataAdapter da = new SqlDataAdapter("SP_CheckAuthentication", Connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@username", username);
            da.SelectCommand.Parameters.AddWithValue("@password", password);
            da.Fill(ds);
            string encryptedtext = ds.Tables[0].Rows[0][0].ToString();
            string decryptedtext;

            string flag = "Not Found";
            if (encryptedtext != "Not Found")
            {
                //MessageBox.Show(encryptedtext);
                //byte[] encrypted=ByteConverter.GetBytes(encryptedtext);
                //MessageBox.Show(encrypted.ToString());
                //byte[] decryptedtex= Decryption(encrypted, RSA.ExportParameters(true), false);

                //decryptedtext= ByteConverter.GetString(decryptedtex);

                if (password.Equals(encryptedtext))
                {
                    flag = "Found";
                }


            }

            return flag;

        }
      
        
    }
}
