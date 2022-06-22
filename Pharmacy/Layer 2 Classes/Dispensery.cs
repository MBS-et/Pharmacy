using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class Dispensery
    {
        public int DrugID;
        public int Quantity;
        public DataTable getDispenseryMed()
        {
            DispenseryDB dm = new DispenseryDB();
            return dm.getDispenseryMedDB();
        }
        public void moveToDispenser()
        {
            DispenseryDB DDB = new DispenseryDB();
            DDB.moveToDispensery(this);
        }
        public DataTable getAllPossibleMed()
        {
            DispenseryDB DDB = new DispenseryDB();
            return DDB.getAllPossibleMed(this);
        }


    }
}
