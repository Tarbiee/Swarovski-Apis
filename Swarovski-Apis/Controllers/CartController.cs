using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swarovski_Apis.Data;
using Swarovski_Apis.Models;
using Swarovski_Apis.Models.Entities;
using System.Linq;

namespace Swarovski_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult PostToCart(int jewelId)
        {
            var jewel = _context.Jewels.Find(jewelId);

            if (jewel == null)
            {
                return NotFound("Jewel not found");
            }

            var cartItem = _context.Carts.FirstOrDefault(c => c.JewelId == jewelId);

            if (cartItem != null)
            {
                cartItem.Quantity += 1;
                cartItem.Price = cartItem.Quantity * jewel.price; // Recalculate price based on quantity and jewel price
                _context.SaveChanges();

                return Ok(cartItem); // Return the updated cart item
            }
            else
            {
                // Create a new cart item and add the jewel details
                var newCartItem = new Cart
                {
                    Quantity = 1,
                    Price = jewel.price,
                    JewelName = jewel.name,
                    JewelImage = jewel.image,
                    JewelId = jewelId
                };

                _context.Carts.Add(newCartItem);
                _context.SaveChanges();

                return Ok(newCartItem); // Return the newly created cart item
            }

            // Add a default return statement (although theoretically, this should never be reached)
            return BadRequest("Failed to add jewel to cart");
        }



        [HttpGet("getCartJewels")]
        public IActionResult AllItems()
        {
            var items = _context.Carts.ToList();
            return Ok(items);
        }

        [HttpGet("getCartJewelById/{id:int}")]
        public IActionResult GetItemsById(int id)
        {
            var item = _context.Carts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("updateItem/{id:int}")]
        public IActionResult UpdateItem(int id, UpdateCartDto updateCartDto)
        {
            var item = _context.Carts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Quantity = updateCartDto.Quantity;
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("deleteItem/{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Carts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Carts.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}
