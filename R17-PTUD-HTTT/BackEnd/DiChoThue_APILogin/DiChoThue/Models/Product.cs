using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductInventory { get; set; }
        public int? ProductTypeId { get; set; }

        [ForeignKey(nameof(ProductTypeId))]
        [InverseProperty("Product")]
        public virtual ProductType ProductType { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<CartItems> CartItems { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
