using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    class DispenseryDB
    {
        
        string cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
        public DataTable getDispenseryMedDB()
        {
            try
            {
                SqlConnection con = new SqlConnection(cn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("sp_getDispenesaryMed", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
                throw;
            }

           
            
        }
        public void moveToDispensery(Dispensery dm)
        {
            try
            {

                SqlConnection con = new SqlConnection(cn);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_moveToDispenesary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DrugID", dm.DrugID);
                cmd.Parameters.AddWithValue("@quantity", dm.Quantity);
                int success = cmd.ExecuteNonQuery();
                if (success == 1)
                {
                    MessageBox.Show("Successfully Moved");
                }
                else
                {
                    MessageBox.Show("Successfully Moved");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                throw;
                
            }   

            

        }
        public DataTable getAllPossibleMed(Dispensery dm)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GetAllPossibleStoreMed", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DrugID", dm.DrugID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(rd);
                    return dt;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                throw;
                
            }
            
           
        }
            
    }
}
