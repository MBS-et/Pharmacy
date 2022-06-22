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
    internal class SignUpDBConnection
    {


        public void RegisterUser(signupLayer2 rg)
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
                        cmd.CommandText = "sp_registeration";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", rg.Email);
                        cmd.Parameters.AddWithValue("@uname", rg.UserName);
                        cmd.Parameters.AddWithValue("@passwsd", rg.Password);
                        cmd.Parameters.AddWithValue("@recoveryemail", rg.RecoveryEmail);
                        cmd.Parameters.AddWithValue("@EmployeeId", rg.EmployeeID);

                     int rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Registration Succesful");

                        }
                        else
                        {
                            MessageBox.Show("Unable To Register");

                        }



                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

    public String encrypt(signupLayer2 rg)
        {
            String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
            SqlConnection con = new SqlConnection(cn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("fetchpassword", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);

            String password = ds.Tables[0].ToString();

            return password;



        }

       





    }
}
