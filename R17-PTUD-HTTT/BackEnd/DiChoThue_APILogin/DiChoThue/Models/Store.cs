using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Store
    {
        public Store()
        {
            ProductType = new HashSet<ProductType>();
        }

        [Key]
        public int StoreId { get; set; }
        [StringLength(50)]
        public string StoreName { get; set; }
        [StringLength(50)]
        public string StoreAddress { get; set; }
        [StringLength(20)]
        public string StorePhone { get; set; }
        public int? StoreRate { get; set; }
        public int? StoreArea { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Seller.Store))]
        public virtual Seller User { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<ProductType> ProductType { get; set; }
    }
}
