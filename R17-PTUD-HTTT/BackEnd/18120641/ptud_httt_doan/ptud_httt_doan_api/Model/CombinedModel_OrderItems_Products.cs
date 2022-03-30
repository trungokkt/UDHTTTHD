using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ptud_httt_doan_api.Model
{
    public class CombinedModel_OrderItems_Products
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int OrderItemQuantity { get; set; }
        public int OrderItemDiscount { get; set; }
        public int OrderItemPrice { get; set; }
    }
}
