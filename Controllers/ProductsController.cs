using Microsoft.AspNetCore.Mvc;
using System;
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
            new Product { Id = 1, Name = "Lighting-Bug Receiver Module", Image = "/images/image1.png", Description = "Receiver module for lighting bug.", Price = 29.99m, Inventory = 10 },
            new Product { Id = 2, Name = "Lightning Transmitter", Image = "/images/image2.png", Description = "Transmitter for lightning.", Price = 49.99m, Inventory = 5 },
            new Product { Id = 3, Name = "Lightning Bulb", Image = "/images/image3.png", Description = "Energy-efficient lightning bulb.", Price = 9.99m, Inventory = 20 },
            new Product { Id = 4, Name = "Lighting-Bug Power Supply", Image = "/images/image4.png", Description = "Power supply for Lighting-Bug.", Price = 19.99m, Inventory = 15 }
        };

        private static readonly List<Order> orders = new List<Order>();

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

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

        [HttpPost("order")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            var product = products.FirstOrDefault(p => p.Id == order.ProductId);

            if (product == null || product.Inventory <= 0)
            {
                return BadRequest("Product out of stock");
            }

            product.Inventory--;
            order.OrderNumber = "ORD" + DateTime.UtcNow.Ticks;
            order.Date = DateTime.UtcNow;
            orders.Add(order);

            return Ok(new { order.OrderNumber });
        }
    }
}