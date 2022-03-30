using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class CartItems
    {
        [Key]
        public int CartId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int? CartItemQuantity { get; set; }
        public int? CartItemPrice { get; set; }

        [ForeignKey(nameof(CartId))]
        [InverseProperty("CartItems")]
        public virtual Cart Cart { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("CartItems")]
        public virtual Product Product { get; set; }
    }
}
