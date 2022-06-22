using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    internal class EMPLOYEELAYER2
    {
        public int EmployeeId;
        public string EmployeeFirstName;
        public string EmployeeMiddleName;
        public string EmployeeLastName;
        public DateTime EmployeeDateBirth;
        public string EmployeeAddress;
        public string EmployeePhoneNumber;
        public int    EmployeeRoleID;
        public string EmployeeEmergencyContactName;
        public string EmployeeEmergencyContactNumber;

        public void SaveEmployee()
        {
            EmployeeDBConnection ed=new EmployeeDBConnection();
            ed.SaveEmployee(this);

        }
        public void deleteEmployee()
        {
            EmployeeDBConnection ed = new EmployeeDBConnection();
            ed.deleteEmployee(this);

        }
        public System.Data.DataTable fetchemployeeinfo()
        {
            EmployeeDBConnection ed = new EmployeeDBConnection();
           return ed.fetchemployeeinfo(this);

        }

        public string getEmployeeeId()
        {
            EmployeeDBConnection ed = new EmployeeDBConnection();
            return (ed.getEmployeeeId()).ToString();


        }






    }
}
