using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ptud_httt_doan_api.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public int BuyerId { get; set; }
        public int ShipperId { get; set; }
    }
}
