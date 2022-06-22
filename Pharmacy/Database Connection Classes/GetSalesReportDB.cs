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
    class GetSalesReportDB
    {
     public DataTable getSalesReport(DateTime ReportFrom,DateTime ReportTO)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_UGetSalesReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ReportFrom", ReportFrom);
                da.SelectCommand.Parameters.AddWithValue("@ReportTO", ReportTO);
                DataSet ds = new DataSet();
                 da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                return dt;

            }
        }
        public DataTable getPurchaseReport(DateTime ReportFrom, DateTime ReportTO)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_PurchaseReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ReportFrom", ReportFrom);
                da.SelectCommand.Parameters.AddWithValue("@ReportTO", ReportTO);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                return dt;

            }
        }
        public DataSet GetSupplier()
        {
          
                  using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("Testing_Crystal_Report_supplier", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }
    }
}
