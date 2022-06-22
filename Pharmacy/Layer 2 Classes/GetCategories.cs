using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Pharmacy
{
    class GetCategories
    {
        public DataTable getCategories()
        {
            GetCategoriesDB getcatdb = new GetCategoriesDB();
            return getcatdb.getCategories();
        }
    }
}
