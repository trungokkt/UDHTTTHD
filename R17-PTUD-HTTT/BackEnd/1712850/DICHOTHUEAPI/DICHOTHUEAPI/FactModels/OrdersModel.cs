using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class OrdersModel
    {

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
        public virtual BuyerModel Buyer { get; set; }
        public virtual ShipperModel Shipper { get; set; }

        public virtual ICollection<HistoryOrderStatusModel> HistoryOrderStatus { get; set; }
        //[JsonIgnore]
        public virtual ICollection<OrderEvaluationModel> OrderEvaluation { get; set; }
        //[JsonIgnore]
        public virtual ICollection<OrderItemsModel> OrderItems { get; set; }

    }
}
