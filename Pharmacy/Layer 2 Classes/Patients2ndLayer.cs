using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Pharmacy
{
    public class Patients2ndLayer
    {
        public string savePatients(int PatientId,String PatientFname, String PatientsMname, String PatientsLname, DateTime PatientsAge,String Add,string email, string pp, string sp)
        {
            PatientDBLayer PDBL = new PatientDBLayer();
            String SaveStatus = PDBL.savePatients(PatientId, PatientFname, PatientsMname, PatientsLname, PatientsAge,Add,email,pp,sp);
            return SaveStatus;
        }
        public DataTable FetchPatients()
        {
            PatientDBLayer PDBL = new PatientDBLayer();
            DataTable dt = new DataTable();
            dt = PDBL.FetchPatients();
            return dt;
        }

        public string FetchNextPatientsID()
        {
            PatientDBLayer PDBL = new PatientDBLayer();
            
            String Id = PDBL.FetchNextPatientsID();
            return Id;
        }
        public string DeletePatient(int PatientId)
        {
            PatientDBLayer PDBL = new PatientDBLayer();
            String DeleteStatus= PDBL.DeletePatient(PatientId);
            return DeleteStatus;
        }
        
     


    }
}
