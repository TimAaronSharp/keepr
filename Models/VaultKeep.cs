using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class VaultKeep
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; } = new DateTime();

        [Required, MinLength(1)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
    }
}