using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Model;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        // GET api/User
        public UserModel GetUserLogedIn()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData ud = new UserData();
            UserModel output = ud.GetUserById(userId);

            return output;
        }
    }
}