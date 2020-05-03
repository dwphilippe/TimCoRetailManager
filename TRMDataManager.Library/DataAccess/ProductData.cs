using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetAll()
        {
            SqlDataAccess sql = new SqlDataAccess();

            List<ProductModel> allProducts = sql.LoadData<ProductModel, dynamic>("spProduct_GetAll", new { }, "TRMDataConnection");

            return allProducts;
        }
    }
}
