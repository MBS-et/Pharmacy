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
    class DeleteSotreMedicineDB
    {
        public string DeleteDrugs (int DrugId)
        {
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UDeleteStoreDrug", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DrugId",DrugId);
                con.Open();
                int rowcount = cmd.ExecuteNonQuery();
                if (rowcount > 0)
                    return "Drug Deleted";
                else
                    return "Failed To Delte";
            }
        }
    }
}
