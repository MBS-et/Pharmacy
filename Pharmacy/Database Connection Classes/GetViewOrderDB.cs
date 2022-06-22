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
    class GetViewOrderDB
    {
        public DataTable getViewOrders()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_UGetViewOrders",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
