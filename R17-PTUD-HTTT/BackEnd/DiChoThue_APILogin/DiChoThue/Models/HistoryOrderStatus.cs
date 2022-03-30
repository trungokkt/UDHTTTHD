using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class HistoryOrderStatus
    {
        [Key]
        public int HistoryId { get; set; }
        public int? OrderStatus { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderStatusDate { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.HistoryOrderStatus))]
        public virtual Orders Order { get; set; }
    }
}
