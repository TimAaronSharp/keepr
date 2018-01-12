using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class UserRegisterModel
    {
        
        public DateTime DateCreated { get; set; } = new DateTime();
        [Required, MinLength(1)]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }
        [Required]
        public string AvatarURL { get; set; }
        public int OwnKeepsViewed { get; set; } = new int();
        public int OwnKeepsVaulted { get; set; } = new int();

        public UserRegisterModel(){
            OwnKeepsViewed = 0;
            OwnKeepsVaulted = 0;
        }
    }
}