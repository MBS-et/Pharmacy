using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
//using System.Windows;
using System.Windows.Forms;
using System.Data;

namespace Pharmacy
{
    internal class EmployeeDBConnection
    {

        public void SaveEmployee(EMPLOYEELAYER2 emp)
        {
            try
            {
                String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
                using (SqlConnection conn = new SqlConnection(cn))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_Employee_inserting";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", emp.EmployeeId);
                        cmd.Parameters.AddWithValue("@empfirstname", emp.EmployeeFirstName);
                        cmd.Parameters.AddWithValue("@empmiddlename", emp.EmployeeMiddleName);
                        cmd.Parameters.AddWithValue("@emplastname", emp.EmployeeLastName);
                        cmd.Parameters.AddWithValue("@empdob", emp.EmployeeDateBirth);
                        cmd.Parameters.AddWithValue("@empaddress", emp.EmployeeAddress);
                        cmd.Parameters.AddWithValue("@empphoneno", emp.EmployeePhoneNumber);
                        cmd.Parameters.AddWithValue("@empemercgencycontactname", emp.EmployeeEmergencyContactName);
                        cmd.Parameters.AddWithValue("@empemercgencyNo", emp.EmployeeEmergencyContactNumber);
                        cmd.Parameters.AddWithValue("@empRoleID", emp.EmployeeRoleID);

                        int rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Saved Succesfully");

                        }
                        else
                        {
                            MessageBox.Show("failed");

                        }



                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

       

        public DataTable fetchemployeeinfo(EMPLOYEELAYER2 emp)
        {
            String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
            SqlConnection con = new SqlConnection(cn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("fetchemployees",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds=new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;  



      }
        public String getEmployeeeId()
        {

            String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
            SqlConnection con = new SqlConnection(cn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("spGetEmployeeID",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
          
            String id=ds.Tables[0].Rows[0][0].ToString();
            
            return id;

        }
        public void deleteEmployee(EMPLOYEELAYER2 emp)
        {
            try
            {
                String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
                using (SqlConnection conn = new SqlConnection(cn))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_RemoveEmployee";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Emp_ID", emp.EmployeeId);
                        int rowAffected = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Employee Deleted Succesfully");

                        }
                        else
                        {
                            MessageBox.Show("failed");

                        }



                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }





    }
  
}
