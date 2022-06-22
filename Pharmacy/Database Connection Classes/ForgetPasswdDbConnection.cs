using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
//using System.Windows;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
namespace Pharmacy
{
    internal class ForgetPasswdDbConnection
    {
        int i = 0;
        public void ChangePassword(ForgetLayer2 fg2)
        {


            try
            {
                String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();

                using (SqlConnection conn = new SqlConnection(cn))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_checkRecoveryEmail";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", fg2.UserName);
                        cmd.Parameters.AddWithValue("@passwd", fg2.Password);

                        int rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Password changed Succesfully");

                            go();

                        }
                        else
                        {
                            MessageBox.Show("failed to change your password");

                        }



                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


           

        }




        public void go()
        {
            ForgetPassword ty = new ForgetPassword();
            ty.go();
        }




    }
}
