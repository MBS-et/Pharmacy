using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class SaveOrders
    {
        public string SaveOrderstodatabase(int userId)
        {
            SaveOrdersDB sodb = new SaveOrdersDB();
            return sodb.SaveOrderstodatabase(userId);
        }
    }
}
