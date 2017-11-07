using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyCinema.Areas.Auth.Models;

namespace MyCinema.Areas.Auth.Services
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<UserModel> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<UserModel>(new UserStore<UserModel>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            UserModel user = new UserModel()
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}