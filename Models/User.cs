using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(1)]
        public DateTime DateCreated { get; set; } = new DateTime();
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }
        [Required]
        public string AvatarURL { get; set; }
        public int OwnKeepsViewed { get; set; }
        public int OwnKeepsVaulted { get; set; }

        internal UserReturnModel GetUserReturnModel()
        {
            return new UserReturnModel()
            {
                Id = Id,
                Username = Username,
                Email = Email
            };
        }
    }
}