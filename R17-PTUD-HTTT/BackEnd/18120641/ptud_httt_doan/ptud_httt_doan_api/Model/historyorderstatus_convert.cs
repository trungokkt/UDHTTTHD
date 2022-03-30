using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ptud_httt_doan_api.Model
{
    public class historyorderstatus_convert
    {
        public int orderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderStatusDate { get; set; }     
    }
}
