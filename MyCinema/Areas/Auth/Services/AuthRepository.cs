using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyCinema.Areas.Auth.Models;

namespace MyCinema.Areas.Auth.Services
{
    public class AuthRepository : IDisposable
    {
        MyCinemaDB _ctx;

        //        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new MyCinemaDB();
            //            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUserDTO userModel, string roleName)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber
            };
            var _roleManager = new RoleManager<IdentityRole>(
                        new RoleStore<IdentityRole>(new MyCinemaDB()));
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            try
            {

                bool x = await _roleManager.RoleExistsAsync(roleName);
                if (!x)
                {  
                    var role = new IdentityRole();
                    role.Name = roleName;
                    await _roleManager.CreateAsync(role);
                }
                IdentityResult chkUser = await userManager.CreateAsync(user, userModel.Password);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user.Id, roleName);
                }


                return chkUser;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                return null;
            }


        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();

            var authManager = HttpContext.Current.GetOwinContext().Authentication;
            IdentityUser user = await userManager.FindAsync(userName, password);
            if (user != null)
            {
                var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                //                userManager.AddToRole(userManager.FindByName("username").Id, "roleName");
                return user;
            }
            throw new ArgumentException("nie można zarejestrowac");
        }

        public void Dispose()
        {
            _ctx.Dispose();

        }
    }
}