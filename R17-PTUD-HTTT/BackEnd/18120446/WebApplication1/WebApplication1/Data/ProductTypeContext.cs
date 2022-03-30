using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entity;

namespace WebApplication1.Data
{
    public class ProductTypeContext : DbContext
    {
        public ProductTypeContext(DbContextOptions<ProductTypeContext> options) : base(options)
        {
        }
        public DbSet<ProductType> ProductType { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>().ToTable("ProductType");



        }
    }
}
