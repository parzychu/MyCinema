using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyCinema.Areas.Auth.Services
{
    public class AppRole: IdentityRole
    {
        public AppRole()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}