using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ptud_httt_doan_api.Model
{
    public class HistoryOrderStatus
    {
        [Key]
        public int HistoryId {get; set;}
        public int OrderStatus { get; set; }
        public DateTime OrderStatusDate { get; set; }
        [ForeignKey("Orders")]
        public int orderId { get; set; }
        public virtual Orders order { get; set; }
    }
}
