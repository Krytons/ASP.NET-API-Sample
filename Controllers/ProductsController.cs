using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductsAPI.Models;
using ProductsAPI.Errors;
using ProductsAPI.Models.DTO;

namespace ProductsAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            //DI: Context injection
            _context = context;
        }


        // GET: api/products/init
        [Route("init")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> InitProducts()
        {
            Console.WriteLine("Executing InitProducts");

            //Add some products
            _context.Products.Add(new Product("Xiaomi MI 11 lite 128Gb", 320.99));
            _context.Products.Add(new Product("Iphone 12 RED 128Gb", 799.99));
            _context.Products.Add(new Product("Samsung S20 note 256Gb", 999.99));
            //Save changes
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }


        // GET: api/products/filter/query
        [HttpGet("filter/{query}")]
        public IEnumerable<Product> SearchProduct(string query)
        {
            //Contains is already case insensitive: no actions needed.
            IEnumerable<Product> products = _context.Products.Where(product => product.Name.Contains(query));

            if (products.Count() < 1)
            {
                Response.StatusCode = 400;
            }
            else Response.StatusCode = 200;

            return products.ToList();
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            Console.WriteLine("Executing GetProducts");
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                Response.StatusCode = 400;
                return new JsonResult(new Error("Product not found"));
            }

            return product;
        }

        // PUT: api/products/2
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(long id, Product product)
        {
            if (id != product.ProductId)
            {
                Response.StatusCode = 400;
                return new JsonResult(new Error("Body value must be the same as URL id parameter"));
                //return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    //return NotFound();
                    Response.StatusCode = 404;
                    return new JsonResult(new Error($"No products found which id is {id}"));
                }
                else
                {
                    return new JsonResult(new Error("Something went wrong"));
                }
            }
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO product) //DTO is not necessary for this simple exercise: a body containing a Product will work the same.
        {
            Product createdProduct = new Product(product.Name, product.Price);
            _context.Products.Add(createdProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { id = createdProduct.ProductId }, product);
        }

        // DELETE: api/products/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return new JsonResult(new Error($"No products found which id is {id}"));
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
