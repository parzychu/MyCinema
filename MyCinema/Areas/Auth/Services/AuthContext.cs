using Microsoft.AspNet.Identity.EntityFramework;
using MyCinema.Areas.Auth.Models;

namespace MyCinema.Areas.Auth.Services
{
    public class AuthContext: IdentityDbContext<UserModel>
    {
        public AuthContext() : base("AuthContext")
        {
     
        }
    }
}