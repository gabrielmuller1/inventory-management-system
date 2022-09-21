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

        public string? ProductName { get; set; } = string.Empty;


        public int Quantity { get; set; }


        public double Price { get; set; }
    }
}

