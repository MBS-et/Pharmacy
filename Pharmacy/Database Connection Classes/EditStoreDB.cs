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
    class EditStoreDB
    {
        public string saveToSotre(string DrugId, string DrugName, string CategoryName, string BatchNumber,
                       string ExpirationDate, string MeasurementUnit, string ManufacturerDetail, string Quantity)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UUpdateStoreData",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DrugId", int.Parse(DrugId));
                cmd.Parameters.AddWithValue("@DrugName", DrugName);
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("@BatchNumber", BatchNumber);
                cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                cmd.Parameters.AddWithValue("@MeasurementUnit", MeasurementUnit);
                cmd.Parameters.AddWithValue("@ManufacturerDetail", ManufacturerDetail);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                con.Open();
                int rowcount =cmd.ExecuteNonQuery();
                if (rowcount > 0)
                    return "Edited Store Drug";
                else
                    return "Edit Failed";
            }
        }

    }
}
