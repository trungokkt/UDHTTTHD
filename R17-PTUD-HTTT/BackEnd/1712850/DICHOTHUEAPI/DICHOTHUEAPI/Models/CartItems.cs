using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class CartItems
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int? CartItemQuantity { get; set; }
        public int? CartItemPrice { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
