using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swarovski_Apis.Data;
using Swarovski_Apis.Models;

namespace Swarovski_Apis.Controllers
{
    //this attribute specifies the route template [contoller] which is replaced with the name of the controller class
    [Route("api/[controller]")]
    //This attribute indicates that the controller should follow cartain convections 
    //to simplify the implementation of Restful APIs.
    //It enaables automatic model validation, binding source parameter inference and response formatting
    [ApiController]
    //this is a class declaration .this declares the cartcontroller class which inherits from ControllerBase
    //This base class in ASP.Net core that provides essential methods and properties for handling HTTP requests
    public class CartController : ControllerBase
    {

        private ApplicationDbContext dbContext;

        public CartController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("getCartJewels")]
        public IActionResult AllItems()
        {
            var items = dbContext.Carts.ToList();
            return Ok(items);
        }

        [HttpGet("getCartJewelById /{id:int}")]
        public IActionResult GetItemsById(int id)
        {
            var item = dbContext.Carts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);

        }

        [HttpPut("updateItem/{id:int}")]

        public IActionResult UpdateItem(int id, UpdateCartDto updateCartDto)
        {
            var item = dbContext.Carts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Quantity = updateCartDto.Quantity;
            dbContext.SaveChanges();
            return Ok(item);

        }

        [HttpDelete("deleteItem/{id:int}")]

        public IActionResult DeleteItem(int id)
        {
            var item = dbContext.Carts.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            dbContext.Carts.Remove(item);
            dbContext.SaveChanges();
            return Ok(item);
        }
    }
}
