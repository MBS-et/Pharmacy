using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Pharmacy
{
    class GetViewOrder
    {
        GetViewOrderDB getvorders = new GetViewOrderDB();
        public DataTable getViewOrders()
        {

            return getvorders.getViewOrders();
        }
    }
}
