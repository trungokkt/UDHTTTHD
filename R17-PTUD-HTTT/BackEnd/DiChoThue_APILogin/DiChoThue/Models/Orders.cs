using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Orders
    {
        public Orders()
        {
            HistoryOrderStatus = new HashSet<HistoryOrderStatus>();
            OrderEvaluation = new HashSet<OrderEvaluation>();
            OrderItems = new HashSet<OrderItems>();
        }

        [Key]
        public int OrderId { get; set; }
        public int? OrderQuantity { get; set; }
        public int? OrderPrice { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [StringLength(50)]
        public string OrderAddress { get; set; }
        [StringLength(50)]
        public string OrderPhone { get; set; }
        public int? BuyerId { get; set; }
        public int? ShipperId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        [InverseProperty("Orders")]
        public virtual Buyer Buyer { get; set; }
        [ForeignKey(nameof(ShipperId))]
        [InverseProperty("Orders")]
        public virtual Shipper Shipper { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<HistoryOrderStatus> HistoryOrderStatus { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderEvaluation> OrderEvaluation { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
