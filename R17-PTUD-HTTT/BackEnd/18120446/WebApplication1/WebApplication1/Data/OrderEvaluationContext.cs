using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entity;


namespace WebApplication1.Data
{
    public class OrderEvaluationContext : DbContext
    {
        public OrderEvaluationContext(DbContextOptions<OrderEvaluationContext> options) : base(options)
        {
        }
        public DbSet<OrderEvaluation> OrderEvaluation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder1)
        {
            modelBuilder1.Entity<OrderEvaluation>().ToTable("OrderEvaluation");



        }
    }
}
