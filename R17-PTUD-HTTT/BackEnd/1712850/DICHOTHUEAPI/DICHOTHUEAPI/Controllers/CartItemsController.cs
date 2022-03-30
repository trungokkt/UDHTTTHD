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
    public class CartItemsController : ControllerBase
    {
        private readonly QuanLyDiChoThueContext db;
        private readonly ModelFactory _modelFactory = new ModelFactory();

        public CartItemsController(QuanLyDiChoThueContext context)
        {
            db = context;
        }

        // PUT: api/CartItems/5
        [HttpPut]
        public IActionResult PutCartItems([FromQuery] int userId, [FromBody] CartItems cartItems)
        {
            Cart cart = db.Cart.Where(s => s.UserId == userId).FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (cart.CartId != cartItems.CartId)
            {
                return BadRequest();
            }
            CartItems ci = db.CartItems.Where(s => s.CartId == cartItems.CartId && s.ProductId == cartItems.ProductId).FirstOrDefault();
            if (cartItems.CartItemQuantity <= 0)
            {
                db.CartItems.Remove(ci);
            }
            else
            {
                ci.CartItemQuantity = cartItems.CartItemQuantity;

                if (ci.Product.ProductInventory < ci.CartItemQuantity)
                {
                    ci.CartItemQuantity -= cartItems.CartItemQuantity;
                }
            }
            try
            {
                db.SaveChanges();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemsExists(cart.CartId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            CartItems result = new CartItems()
            {
                CartId = ci.CartId,
                CartItemPrice=ci.CartItemPrice,
                CartItemQuantity=ci.CartItemQuantity,
                ProductId=ci.ProductId
            };
            return Ok(result);
        }

        // POST: api/CartItems
        [HttpPost]
        public IActionResult PostCartItems([FromQuery] int userId, [FromBody] CartItems cartItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Cart cart = db.Cart.Where(s => s.UserId == userId).FirstOrDefault();
            CartItems item = db.CartItems.Where(s => s.CartId == cart.CartId && s.ProductId == cartItems.ProductId).ToList().FirstOrDefault();
            if (item == null)
            {
                db.CartItems.Add(cartItems);
                item = cartItems;
            }
            else
            {
                //CartItems ci = db.CartItems.Where(s => s.CartId == item.CartId && s.ProductId == item.ProductId).First();
                item.CartItemQuantity += cartItems.CartItemQuantity;
                if (item.Product.ProductInventory < item.CartItemQuantity)
                {
                    item.CartItemQuantity -= cartItems.CartItemQuantity;
                }

            }
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CartItemsExists(cartItems.CartId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            CartItemsModel ca = new CartItemsModel()
            {
                CartId = item.CartId,
                CartItemPrice = item.CartItemPrice,
                CartItemQuantity = item.CartItemQuantity,
                ProductId = item.ProductId
            };
            return Ok(ca);
        }

        // DELETE: api/CartItems/5
        [HttpDelete]
        public IActionResult DeleteCartItems([FromQuery] int userId, [FromQuery] int cartId, [FromQuery] int productId)
        {
            Cart cart = db.Cart.Where(s => s.UserId == userId).First();
            if (cart == null)
            {
                return NotFound();
            }
            if (cart.UserId != userId)
            {
                return BadRequest();
            }
            CartItems cartItems = db.CartItems.Where(s => s.CartId == cartId && s.ProductId == productId).FirstOrDefault();
            if (cartItems == null)
            {
                return NotFound();
            }

            db.CartItems.Remove(cartItems);
            db.SaveChanges();

            CartItems Result = new CartItems()
            {
                CartId = cartItems.CartId,
                CartItemPrice = cartItems.CartItemPrice,
                CartItemQuantity = cartItems.CartItemQuantity,
                ProductId = cartItems.ProductId
            };

            return Ok(Result);
        }

        private bool CartItemsExists(int id)
        {
            return db.CartItems.Any(e => e.CartId == id);
        }
    }
}