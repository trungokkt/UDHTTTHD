using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductInventory { get; set; }
        public int? ProductTypeId { get; set; }
        public string ProductUnit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ProductImage { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
