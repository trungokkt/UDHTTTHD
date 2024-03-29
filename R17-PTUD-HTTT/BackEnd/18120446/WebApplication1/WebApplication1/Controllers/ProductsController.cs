﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        
        public IEnumerable<Product> GetProduct()
        {
            return _context.Product.Where(s => s.ProductIsDelete == 0).ToList();
        }
        [HttpGet("del")]

        public IEnumerable<Product> DelProduct()
        {
            return _context.Product.Where(s => s.ProductIsDelete == 1).ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
       
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
     
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
        [HttpPost("del/{id}")]
      
        public async Task<IActionResult> DelProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
                
            }
            else product.ProductIsDelete = 1;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return Ok(product); 
        }
        [HttpPost("restore/{id}")]

        public async Task<IActionResult> RestoreProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            else product.ProductIsDelete = 0;

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
        [HttpPost("edit/{id}")]
        [EnableCors("AllowAll")]

        public async Task<IActionResult> EditProduct([FromRoute] int id, [FromBody] Product product)
        {

           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

  
            if (product == null)
            {
                return NotFound();

            }
            else _context.Product.Update(product);


            await _context.SaveChangesAsync();

            return Ok(product);
        }
        [EnableCors("AllowAll")]
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (product == null)
            {
                return NotFound();

            }
            else _context.Product.Add(product);


            await _context.SaveChangesAsync();

            return Ok(product);
        }


        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }




}