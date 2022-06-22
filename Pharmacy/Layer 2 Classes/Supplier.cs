using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using Pharmacy.DatabaseConnection;

namespace Pharmacy
{
    class Supplier
    {
        public int supplierId;
       public string supplierName,supplierCountry, supplierCity, supplierContactAddress;
        public void addSupplier()
        {
            SupplierDBconnection dbservice = new SupplierDBconnection();
            dbservice.addSupplier(this);
        }
        public int getSupplierId()
        {
            SupplierDBconnection dbservice = new SupplierDBconnection();
           return dbservice.getSupplierId(this);
            
        }
        public DataTable getAllSuppliers()
        {
            SupplierDBconnection dbservice = new SupplierDBconnection();
            return dbservice.getAllSupplier();
        }
        public void deleteSupplier()
        {
            SupplierDBconnection dbservice = new SupplierDBconnection();
            dbservice.removeSupplier(this);

        }


    }
}