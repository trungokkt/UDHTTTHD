using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DICHOTHUEAPI.Models;
using DICHOTHUEAPI.FactModels;

namespace DICHOTHUEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly QuanLyDiChoThueContext db = new QuanLyDiChoThueContext();
        private readonly ModelFactory _modelFactory = new ModelFactory();

        // GET: api/Carts/5
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetCart([FromRoute] int UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await db.Cart.FirstOrDefaultAsync(s=>s.UserId == UserId);

            if (cart == null)
            {
                Cart insertCart = new Cart()
                {
                    CartPrice = 0,
                    CartQuantity = 0,
                    UserId = UserId
                };
                db.Cart.Add(insertCart);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = insertCart.CartId }, insertCart);
            }

            return Ok(_modelFactory.Create(cart));
        }
        private bool CartExists(int id)
        {
            return db.Cart.Any(e => e.CartId == id);
        }
    }
}