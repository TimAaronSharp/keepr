using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace keepr.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserRepository _db;

        public AccountsController(UserRepository repo)
        {
            _db = repo;
        }

        [HttpPost("register")]
        public async Task<UserReturnModel> Register([FromBody]UserRegisterModel creds)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = _db.Register(creds);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
            }
            return null;
        }
        [HttpPost("login")]
        public async Task<UserReturnModel> Login([FromBody]UserLoginModel creds)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = _db.Login(creds);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
            }
            return null;
        }

        [HttpDelete("logout")]
        public async void Logout()
        {
            await HttpContext.SignOutAsync();
        }
        // [HttpGet("vaultkeeps/{id}")]
        // public IEnumerable<VaultKeep> GetUsersVaultKeeps(int id)
        // {
        //     return _db.GetUsersVaultKeeps(id);
        // }

        [HttpGet("authenticate")]
        public UserReturnModel Authenticate()
        {
            var user = HttpContext.User;
            var id = user.Identity.Name;
            // var email = user.Claims.Where(c => c.Type == ClaimTypes.Email)
            //        .Select(c => c.Value).SingleOrDefault();
            return _db.GetUserById(id);
        }

        [Authorize]
        [HttpPut]
        public UserReturnModel UpdateAccount([FromBody]UserReturnModel user)
        {
            var id = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();
            var sessionUser = _db.GetUserById(id);

            if (sessionUser.Id == user.Id)
            {
                return _db.UpdateUser(user);
            }
            return null;
        }

        [Authorize]
        [HttpPut("change-password")]
        public string ChangePassword([FromBody]UserChangePasswordModel user)
        {
            if (ModelState.IsValid)
            {
                var id = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name)
                       .Select(c => c.Value).SingleOrDefault();
                var sessionUser = _db.GetUserById(id);

                if (sessionUser.Id == user.Id)
                {
                    return _db.ChangeUserPassword(user);
                }
            }
            return "How did you even get here?";
        }
    }
}