using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
namespace Pharmacy
{
    class Sale
    {

        public void SaveSales (int DrugId ,int TotalAmount ,string CustomerName,int quantity ,string InvoiceNumber)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open ();
                SqlCommand cmd = new SqlCommand("saveSales", con);
              
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DrugId", DrugId);
                cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNumber);
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable getsolditems()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("saveSales", con);

                SqlDataAdapter da = new SqlDataAdapter("getsolditems", con);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                return dt = ds.Tables[0];
            }
        }

        public DataTable getCustomers()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_getRegularClientName", con);

                SqlDataAdapter da = new SqlDataAdapter("Sp_getRegularClientName", con);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                return dt = ds.Tables[0];
            }
        }

        public DataTable getcustomersID(string ClientName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                 MessageBox.Show(ClientName);
                if (ClientName=="")
                {
                   
                }
                SqlCommand cmd = new SqlCommand("SP_getRegularClientId", con);

                SqlDataAdapter da = new SqlDataAdapter("SP_getRegularClientId", con);
                da.SelectCommand.Parameters.AddWithValue("@ClientName", ClientName);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                return dt = ds.Tables[0];
            }
        }
        public DataTable getItemToBeSold(int i)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getDrudDetailSale", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", i);
                SqlDataReader read = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(read);
                return dt;
            }
        }
    }
}
