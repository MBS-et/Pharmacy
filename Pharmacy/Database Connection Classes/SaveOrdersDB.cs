using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Pharmacy
{
    class SaveOrdersDB
    {
        public string SaveOrderstodatabase(int userId)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_USaveOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                int rowcount = cmd.ExecuteNonQuery();
                if (rowcount > 0)
                    return "Moved";
                else
                    return "Not Moved";
                

            }
         
        }
    }
}
