using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyCinema.Areas.Auth.Models;
using MyCinema.Areas.Auth.Services;
using Newtonsoft.Json.Serialization;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;
using System.Web.Security;

namespace MyCinema.Areas.Auth.Controllers
{
    public class LoginController : Controller
    {
        private AuthRepository _repo = null;

        public LoginController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [System.Web.Http.AllowAnonymous]
        public async Task<ActionResult> RegisterClient(ApplicationUserDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(499);
            }

            IdentityResult result = await _repo.RegisterUser(userModel, "Client");

            ActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Json("Client Registered");
        }

        [System.Web.Http.AllowAnonymous]
        public async Task<ActionResult> RegisterEmployee(ApplicationUserDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(499);
            }

            IdentityResult result = await _repo.RegisterUser(userModel, "Employee");

            ActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Json("Employee Registered");
        }

        public ActionResult Identity()
        {
            if (HttpContext.User.Identity.IsAuthenticated == false)
            {
              return Json(HttpContext.User.Identity.IsAuthenticated);
            }

            var userInfo = new
            {
                Login = HttpContext.User.Identity.Name,
                IsAuthenticated = HttpContext.User.Identity.IsAuthenticated,
                Roles = Roles.GetRolesForUser(HttpContext.User.Identity.Name),
                IsClient = Roles.IsUserInRole("Client"),
                IsEmployee = Roles.IsUserInRole("Employee")
          };

            return Json(userInfo);
        }

        public async Task<ActionResult> Login(string userName, string password)
        {
              var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
              var authManager = HttpContext.GetOwinContext().Authentication;

              IdentityUser user = userManager.Find(userName, password);

         
              if (user != null)
              {
                  var ident = userManager.CreateIdentity(user,
                      DefaultAuthenticationTypes.ApplicationCookie);
                  authManager.SignIn(
                      new AuthenticationProperties { IsPersistent = false }, ident);
                var userInfo = new
                {
                    Login = HttpContext.User.Identity.Name,
                    IsAuthenticated = HttpContext.User.Identity.IsAuthenticated,
                    Roles = Roles.GetRolesForUser(HttpContext.User.Identity.Name),
                    IsClient = Roles.IsUserInRole("Client"),
                    IsEmployee = Roles.IsUserInRole("Employee")
                };
                return Json(userInfo);
              }
            
            return Json("Invalid username or password");
            
        }

      public ActionResult Logout()
      {
        Request.GetOwinContext().Authentication.SignOut();

        return new HttpStatusCodeResult(200);
      }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private ActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return Json(result);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return null;
        }
    }
}