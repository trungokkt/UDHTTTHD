using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Orders
    {
        public Orders()
        {
            HistoryOrderStatus = new HashSet<HistoryOrderStatus>();
            OrderEvaluation = new HashSet<OrderEvaluation>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public int? OrderQuantity { get; set; }
        public int? OrderPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public int? BuyerId { get; set; }
        public int? ShipperId { get; set; }
        public string PaymentType { get; set; }
        public int? PaymentStatus { get; set; }
        public string OrderCode { get; set; }
        public int? DeliveryMoney { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<HistoryOrderStatus> HistoryOrderStatus { get; set; }
        public virtual ICollection<OrderEvaluation> OrderEvaluation { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
