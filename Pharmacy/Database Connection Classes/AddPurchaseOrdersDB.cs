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
    class AddPurchaseOrdersDB
    {
        public string AddOrders(DataTable dt)
        {
            int RowCount = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            { 
            SqlCommand cmd = new SqlCommand("SP_UAddPurchaseOrders", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category", dt.Rows[0]["Category"].ToString());
                cmd.Parameters.AddWithValue("@ItemName", dt.Rows[0]["ItemName"].ToString());
                cmd.Parameters.AddWithValue("@BatchNumber", dt.Rows[0]["BatchNumber"].ToString());
                DateTime Date1 = Convert.ToDateTime(dt.Rows[0]["ProductionDate"].ToString());
                cmd.Parameters.AddWithValue("@ProductionDate", Date1);
                Date1 = Convert.ToDateTime(dt.Rows[0]["ExpiryDate"].ToString());
                cmd.Parameters.AddWithValue("@ExpiryDate", Date1);
                cmd.Parameters.AddWithValue("@TaxStatus", dt.Rows[0]["TaxStatus"].ToString());
                cmd.Parameters.AddWithValue("@StoreBranch", dt.Rows[0]["StoreBranch"].ToString());
                cmd.Parameters.AddWithValue("@TotalAmount", dt.Rows[0]["TotalAmount"].ToString());
                cmd.Parameters.AddWithValue("@Quantity", dt.Rows[0]["Quantity"].ToString());
                cmd.Parameters.AddWithValue("@UnitCost", dt.Rows[0]["UnitCost"].ToString());
                cmd.Parameters.AddWithValue("@UnitPrice", dt.Rows[0]["UnitPrice"].ToString());
                cmd.Parameters.AddWithValue("@MeasureUnit", dt.Rows[0]["MeasureUnit"].ToString());
                cmd.Parameters.AddWithValue("@ManfDetail", dt.Rows[0]["ManfDetail"].ToString());
                cmd.Parameters.AddWithValue("@Supplier", dt.Rows[0]["Supplier"].ToString());
                cmd.Parameters.AddWithValue("@Invoice", dt.Rows[0]["Invoice"].ToString());
                Date1 = Convert.ToDateTime(dt.Rows[0]["PurchaseDate"].ToString());
                cmd.Parameters.AddWithValue("@PurchaseDate", Date1);
                cmd.Parameters.AddWithValue("@PaymentMethod", dt.Rows[0]["PaymentMethod"].ToString());
                RowCount = cmd.ExecuteNonQuery();
            
            if (RowCount == 1)
                return "OrdersSaved";
            else
                return "Failed,Unable to Save";
            
        }        
        }
        public string getID()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("returnlastDrugID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                DataRow row = dt.Rows[0];

                return row["last id"].ToString();
                
            }
        }
        public DataTable getDrugByID(AddPurchasedOrders addp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getDrugDetailPur", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", addp.DrugId);
                SqlDataReader read = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                return dt;
            }
        }
    }
}
