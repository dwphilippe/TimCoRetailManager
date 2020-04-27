using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public UserModel GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { id = id };

            UserModel output = sql.LoadData<UserModel, dynamic>("spUserLookup", p, "TRMDataConnection").First();

            return output;
        }
    }
}
