using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Database_Connection_Classes
{
    public class getAccess
    {
        public string GetUserAccess(int id)
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("getAccesse", Connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            da.Fill(ds);
            string userId = ds.Tables[0].Rows[0][0].ToString();
            return userId;
        }
    }
}
