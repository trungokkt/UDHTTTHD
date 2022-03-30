using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItems>();
        }

        public int CartId { get; set; }
        public int? CartQuantity { get; set; }
        public int? CartPrice { get; set; }
        public int? UserId { get; set; }

        public virtual Buyer User { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}
