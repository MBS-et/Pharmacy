using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


using Pharmacy.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Pharmacy
{
    class PatientDBLayer
    {
        public string savePatients(int PatientId,String PatientFname, String PatientsMname, String PatientsLname, DateTime PatientsAge, String Add, string email, string pp, string sp)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_UAddPatients", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", PatientId);
            cmd.Parameters.AddWithValue("@PatientFname", PatientFname);
            cmd.Parameters.AddWithValue("@PatientsMname", PatientsMname);
            cmd.Parameters.AddWithValue("@PatientsLname", PatientsLname);
            cmd.Parameters.AddWithValue("@PatientsAge", PatientsAge);
            cmd.Parameters.AddWithValue("@Email",email);
            cmd.Parameters.AddWithValue("@Address",Add);
            cmd.Parameters.AddWithValue("@PrimaryPhoneNumber",pp);
            cmd.Parameters.AddWithValue("@SecondaryPhoneNumber", sp);
            int RowCount = cmd.ExecuteNonQuery();
            if (RowCount > 0)
                return "Saved";
            else 
                return "Not Saved";
          
            
        }
        public DataTable FetchPatients()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SP_UGetPatients", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public string DeletePatient(int PatientId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_URemovePatients", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@PatientId", PatientId);
            con.Open();
            int RowCount = cmd.ExecuteNonQuery();
            if (RowCount > 0)
                return "Deleted";
            else
                return "Not Deleted";
        }

        public string FetchNextPatientsID()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SP_UGetNextPatientsId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            string ID = ds.Tables[0].Rows[0][0].ToString();
            ID = (int.Parse(ID) + 1).ToString(); 
            return ID;
        }
    }
}
