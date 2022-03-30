using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class OrderItems
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? OrderItemQuantity { get; set; }
        public int? OrderItemDiscount { get; set; }
        public int? OrderItemPrice { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
