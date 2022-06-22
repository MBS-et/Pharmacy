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
    class GetUserId
    {
        public string GetUserIdMethod(string username, string password)
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter("SP_UGetId", Connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@username", username);
            da.Fill(ds);
            string userId = ds.Tables[0].Rows[0][0].ToString();
            return userId;
        }
    }
}
