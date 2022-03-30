using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ptud_httt_doan_api.Model
{
    public class OrderItems
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int OrderItemQuantity { get; set; }
        public int OrderItemDiscount { get; set; }
        public int OrderItemPrice { get; set; }
    }
}
