using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public class ChangeUserInfo
    {
        


        public DataTable getEmpInfo(int i)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getUserData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id1",i);
                SqlDataReader read = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                return dt;
            }

        }
        public void updateUserInfo(int id,string newPass)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdatePass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Pass", newPass);
                int i=cmd.ExecuteNonQuery();
                if(i>0)
                {
                    MessageBox.Show("Password Updated Succesfully");
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
                
                
            }
        }


    }
}
