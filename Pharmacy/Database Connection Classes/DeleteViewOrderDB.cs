using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Pharmacy
{
    class DeleteViewOrderDB
    {
        public string DeleteOrders(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UDeleteViewOrder",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int rowcount = cmd.ExecuteNonQuery();
                if (rowcount > 0)
                    return "Delted";
                else
                    return "Unable to Delete";
            }
        }
    }
}
