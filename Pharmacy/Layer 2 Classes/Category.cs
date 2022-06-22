using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.DatabaseConnection;
using System.Data;

namespace Pharmacy
{
    class Category
    {
        public int categoryId;
        public string categoryName,categoryCommodityType;
        public void addCategory()
        {
           CategoryDBconnection dbservice = new CategoryDBconnection();
          dbservice.addCategory(this);
        }
        public int getCategoryId()
        {
            CategoryDBconnection dbservice = new CategoryDBconnection();
            return dbservice.getCategoryId(this);

        }
        public DataTable getAllCategory()
        {
            CategoryDBconnection dbservice = new CategoryDBconnection();
            return dbservice.getAllCategory();
        }
        public void deleteCategory()
        {
            CategoryDBconnection dbservice = new CategoryDBconnection();
            dbservice.removeCategory(this);
        }
        public DataTable searchCategory()
        {
            CategoryDBconnection dbservice = new CategoryDBconnection();
            return dbservice.getCategory(this);
        }


    }
}

