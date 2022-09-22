using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; } = string.Empty;

        [Range ( 0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0" )]
        public int Quantity { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
        public double Price { get; set; }
    }
}

