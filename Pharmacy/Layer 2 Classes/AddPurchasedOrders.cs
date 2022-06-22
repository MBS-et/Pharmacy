using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Pharmacy
{
    class AddPurchasedOrders
    {

        public int DrugId; 
        public string AddOrders(DataTable dt)
        {
            AddPurchaseOrdersDB ADB = new AddPurchaseOrdersDB();
            return ADB.AddOrders(dt);
        }

        public string getID()
        {
            AddPurchaseOrdersDB addPurchaseOrdersDB = new AddPurchaseOrdersDB();
            return addPurchaseOrdersDB.getID();
        }

        public DataTable getDrug()
        {
            AddPurchaseOrdersDB ADB = new AddPurchaseOrdersDB();
            return ADB.getDrugByID(this);
        }
    }

}
