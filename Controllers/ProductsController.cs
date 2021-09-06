using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            //DI: Context injection
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return null;
        }
    }
}
