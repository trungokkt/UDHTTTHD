using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class HistoryOrderStatus
    {
        public int HistoryId { get; set; }
        public int? OrderStatus { get; set; }
        public DateTime? OrderStatusDate { get; set; }
        public int? OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Status OrderStatusNavigation { get; set; }
    }
}
