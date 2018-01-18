using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCinema.Areas.User.Controllers
{
  public class UserController : Controller
  {
    // GET: User/User

    public ActionResult GetUserProfileData()
    {
      var personalData = new
      {
        Login = HttpContext.User.Identity.Name,
        Roles = Roles.GetRolesForUser(),
        IsAuthenticated = HttpContext.User.Identity.IsAuthenticated
      };

      return Json(personalData);
    }
  }
}