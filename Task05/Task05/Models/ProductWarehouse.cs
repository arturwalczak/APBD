using System.ComponentModel.DataAnnotations;
using System;

namespace Task05.Models
{
    public class ProductWarehouse
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int IdWarehouse { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount should must be > 0")]
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt
        {
            get; set;
        }

    }
}
