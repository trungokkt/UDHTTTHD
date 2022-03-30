using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int ProductTypeId { get; set; }
        [StringLength(50)]
        public string ProductTypeName { get; set; }
        public int? StoreId { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("ProductType")]
        public virtual Store Store { get; set; }
        [InverseProperty("ProductType")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
