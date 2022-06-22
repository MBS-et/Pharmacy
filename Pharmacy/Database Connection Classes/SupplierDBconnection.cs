using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace Pharmacy.DatabaseConnection
{
    class SupplierDBconnection
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
        public void addSupplier(Supplier sup)
        {
            Connection.Open();
            SqlCommand da = new SqlCommand("sp_AddSupplier", Connection);
            da.CommandType = CommandType.StoredProcedure;
            da.Parameters.AddWithValue("@supplierID", sup.supplierId);
            da.Parameters.AddWithValue("@supplier_Name", sup.supplierName);
            da.Parameters.AddWithValue("@supplier_Country", sup.supplierCountry);
            da.Parameters.AddWithValue("@supplier_City", sup.supplierCity);
            da.Parameters.AddWithValue("@supplier_ContactAddress", sup.supplierContactAddress);
            int rowsAffected = da.ExecuteNonQuery();
            if(rowsAffected != 0)
            {
                MessageBox.Show("Supplier Added Successfully");
            }
            else
            {

            }
            Connection.Close();

        }
        public DataTable getAllSupplier()
        {
            SqlDataAdapter dr = new SqlDataAdapter("sp_GetAllSupplier", Connection);
            dr.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            dr.Fill(ds);
            return ds.Tables[0];
        }
        public int getSupplierId(Supplier sup)
        {
      
            try
            {
               
                   
                    Connection.Open();
                    if (Connection.State == ConnectionState.Open)
                    {
                        SqlDataAdapter cmd = new SqlDataAdapter("sp_GetLastSupplierId", Connection);
                        cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                          DataSet ds = new DataSet();
                          cmd.Fill(ds);
                        return int.Parse(ds.Tables[0].Rows[0][0].ToString());

                    }
                    

                
               
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
        public void removeSupplier(Supplier sup)
        {
            Connection.Open();
            SqlCommand da = new SqlCommand("sp_DeleteSupplier", Connection);
            da.CommandType = CommandType.StoredProcedure;
            da.Parameters.AddWithValue("@supplierID", sup.supplierId);
            int rowsAffected = da.ExecuteNonQuery();
            if (rowsAffected != 0)
            {
                MessageBox.Show("Supplier Deleted Successfully");
            }
            else
            {

            }
            Connection.Close();

        }
    }
}
