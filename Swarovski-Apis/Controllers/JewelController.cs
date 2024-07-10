using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swarovski_Apis.Data;
using Swarovski_Apis.Models;
using Swarovski_Apis.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Swarovski_Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public JewelController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("getAllJewels")]
        public IActionResult AllJewels()
        {
            var jewels = dbContext.Jewels.ToList();
            return Ok(jewels);
        }

        [HttpGet("getById/{id:int}")]

        public IActionResult GetJewel(int id)
        {
            var jewel = dbContext.Jewels.Find(id);
            if (jewel == null)
            {
                return NotFound();
            }
            return Ok(jewel);
        }

        [HttpPost("addJewel")]
        public IActionResult AddJewel(AddJewelDto addJewelDto)
        {
            var jewelEntity = new Jewel()
            {
                name = addJewelDto.name,
                description = addJewelDto.description,
                image = addJewelDto.image,
                material = addJewelDto.material,
                price = addJewelDto.price,
            };
            dbContext.Jewels.Add(jewelEntity);
            dbContext.SaveChanges();
            return Ok(jewelEntity);

        }

        [HttpPut]
        [Route("updateJewel/{id:int}")]

        public IActionResult UpdateJewel(int id,UpdateJewelDto updateJewelDto)
        {
            var jewel = dbContext.Jewels.Find(id);
            if (jewel == null)
            {
                return NotFound();
            }
            jewel.name = updateJewelDto.name;
            jewel.description = updateJewelDto.description;
            jewel.image = updateJewelDto.image;
            jewel.material = updateJewelDto.material;
            jewel.price = updateJewelDto.price;
            dbContext.SaveChanges();
            return Ok(jewel);

        }

        [HttpPatch("{id}")]
        public ActionResult<UpdateJewelDto> PatchJewel(int id, [FromBody] UpdateJewelDto patchedDto)
        {
            if (id != 0 && id < 0)
            {
                var identifiedJewel = dbContext.Jewels.Find(id);
                if (identifiedJewel == null) { return NotFound(); }

                identifiedJewel.name = patchedDto.name;
                return Ok(identifiedJewel);
            }

            return BadRequest();

        }


        // DELETE: api/Jewel/{id}
        [HttpDelete("deleteJewel/{id:int}")]
        public IActionResult DeleteJewel(int id)
        {
            var jewel = dbContext.Jewels.Find(id);
            if (jewel == null)
            {
                return NotFound();
            }

            dbContext.Jewels.Remove(jewel);
            dbContext.SaveChanges();

            return Ok(jewel);
        }



    }
}
