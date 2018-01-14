using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class VaultKeepReturnModel
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int VaultsAddedTo { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public DateTime DateCreated { get; set; } = new DateTime();

    }
}