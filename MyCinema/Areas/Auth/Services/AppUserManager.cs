using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MyCinema.Areas.Auth.Models;

namespace MyCinema.Areas.Auth.Services
{
    public class AppUserManager : UserManager<IdentityUser>
    {
        public AppUserManager(IUserStore<IdentityUser> store) : base(store)
        {
        }

        public static AppUserManager Create(
                IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<IdentityUser>(context.Get<MyCinemaDB>()));

            return manager;
        }

    }
}