using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required, MinLength(1)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public DateTime DateCreated { get; set; } = new DateTime();
    }
}