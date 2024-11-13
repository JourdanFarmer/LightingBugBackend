using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using LightingBugBackend.Models;

namespace LightingBugBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Lighting-Bug Receiver Module", Image = "/images/image1.png", Description = "Receiver module for lighting bug.", Price = 29.99 },
            new Product { Id = 2, Name = "Lightning Transmitter", Image = "/images/image2.jpg", Description = "Transmitter for lightning.", Price = 49.99 },
            new Product { Id = 3, Name = "Lightning Bulb", Image = "/images/image3.jpg", Description = "Energy-efficient lightning bulb.", Price = 9.99 },
            new Product { Id = 4, Name = "Lighting-Bug Power Supply", Image = "/images/image4.jpg", Description = "Power supply for Lighting-Bug.", Price = 19.99 }
        };

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}