using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1.99M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 2.99M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 13.99M },
            new Product { Id = 4, Name = "Shirt", Category = "Clothing", Price = 16.99M }
        };

        //Get: api/products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProducts(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        public IHttpActionResult GetProductByCategory(string cat)
        {
            var product = products.SingleOrDefault(p => p.Category.ToLower() == cat.ToLower());

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
