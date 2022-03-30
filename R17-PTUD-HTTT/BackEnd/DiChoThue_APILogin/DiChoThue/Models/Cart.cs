using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItems>();
        }

        [Key]
        public int CartId { get; set; }
        public int? CartQuantity { get; set; }
        public int? CartPrice { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Buyer.Cart))]
        public virtual Buyer User { get; set; }
        [InverseProperty("Cart")]
        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}
