using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace keepr.Models
{
    public class UserReturnModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AvatarURL { get; set; }
        public int OwnKeepsViewed { get; set; } = new int();
        public int OwnKeepsVaulted { get; set; } = new int();
        public DateTime DateCreated { get; set; }

        internal ClaimsPrincipal SetClaims()
        {
            var claims = new List<Claim> {
                        //Shouldn't lookup by email?
                        // new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, Id.ToString())
                    };
            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            return principal;
        }
    }
}