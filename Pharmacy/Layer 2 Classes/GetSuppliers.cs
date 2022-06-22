using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Pharmacy
{
    class GetSuppliers
    {
        public DataTable getSuppliers()
        {
            GetSuppliersDB getsupdb = new GetSuppliersDB();
            return getsupdb.getSuppliers();
        }
    }
}
