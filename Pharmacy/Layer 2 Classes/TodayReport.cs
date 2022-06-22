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
    class TodayReport
    {
        public DataTable getReport()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand da = new SqlCommand("SP_UTodayReport",con);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = da.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                return dt;
            }
        }
    }
}
