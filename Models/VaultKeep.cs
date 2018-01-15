using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class VaultKeep
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; } = new DateTime();
    }
}