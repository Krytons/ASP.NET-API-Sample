using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        //Auto increment primary key
        [Key]
        public long ProductId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
