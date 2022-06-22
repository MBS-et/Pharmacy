using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    internal class DashboardDB
    {
        public DataTable getExpierDateDetail()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("getExpieryDetail", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                return dt;

            }
        }
       
        public List<string> getCounts()
        {
            List<string> Counts = new List<string>();
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("getDashboardCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { Counts.Add(reader["med"].ToString()); }

                            reader.NextResult();

                        while (reader.Read())
                        { Counts.Add(reader["sup"].ToString()); }

                            reader.NextResult();

                        while (reader.Read())
                        { Counts.Add(reader["pat"].ToString());  }
                        return Counts;
                    }
                }
            }
        }
    }
}
