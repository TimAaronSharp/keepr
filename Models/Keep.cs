using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; } = new DateTime();

        [Required, MinLength(1)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int VaultsAddedTo { get; set; }
        [Required]
        public string ImageURL { get; set; }

    }
}