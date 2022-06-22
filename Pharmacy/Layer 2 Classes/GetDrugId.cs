using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Pharmacy
{
    class GetDrugId
    {
        public int getDrugsId(string durgname)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_UGetDrugId", con);
                DataSet ds = new DataSet();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DrugName", durgname);
                da.Fill(ds);
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
        }

    }
}
