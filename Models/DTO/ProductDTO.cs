using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models.DTO
{
    public class ProductDTO
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
