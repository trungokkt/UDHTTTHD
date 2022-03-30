using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public int? BuyerDiscount { get; set; }

        public virtual UserInfo User { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
