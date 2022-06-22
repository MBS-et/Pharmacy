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
    class CategoryDBconnection
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
        public void addCategory(Category cat)
        {
            Connection.Open();
            SqlCommand da = new SqlCommand("sp_AddCategory", Connection);
            da.CommandType = CommandType.StoredProcedure;
            da.Parameters.AddWithValue("@category_ID", cat.categoryId);
            da.Parameters.AddWithValue("@category_Name", cat.categoryName);
            da.Parameters.AddWithValue("@category_commodityType", cat.categoryCommodityType);
          
            int rowsAffected = da.ExecuteNonQuery();
            if (rowsAffected != 0)
            {
                MessageBox.Show("Category Added Successfully");
            }
            else
            {

            }
            Connection.Close();

        }
        public DataTable getAllCategory()
        {
            SqlDataAdapter dr = new SqlDataAdapter("sp_GetAllCategory", Connection);
            dr.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            dr.Fill(ds);
            return ds.Tables[0];
        }
        public int getCategoryId(Category cat)
        {

            try
            {


                Connection.Open();
                if (Connection.State == ConnectionState.Open)
                {
                    SqlDataAdapter cmd = new SqlDataAdapter("sp_GetLastCategoryId", Connection);
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
        public void removeCategory(Category cat)
        {
            Connection.Open();
            SqlCommand da = new SqlCommand("sp_DeleteCategory", Connection);
            da.CommandType = CommandType.StoredProcedure;
            da.Parameters.AddWithValue("@category_ID", cat.categoryId);
            int rowsAffected = da.ExecuteNonQuery();
            if (rowsAffected != 0)
            {
                MessageBox.Show("Category Deleted Successfully");
            }
            else
            {

            }
            Connection.Close();

        }
        public DataTable getCategory(Category cat)
        {
            Connection.Open();
            SqlCommand dr = new SqlCommand("tbl_Categories_ReadById", Connection);
            dr.CommandType = CommandType.StoredProcedure;
            dr.Parameters.AddWithValue("@CategoryId", cat.categoryId);
            SqlDataReader read = dr.ExecuteReader();
            DataTable dt = new DataTable();
            DataTable returnDT = new DataTable();
            dt.Load(read);
            if(dt.Rows.Count>0)
            {
                returnDT= dt;
            }
            else
            {
                MessageBox.Show("Not Found");
            }
            return returnDT;
        }
    }
}

