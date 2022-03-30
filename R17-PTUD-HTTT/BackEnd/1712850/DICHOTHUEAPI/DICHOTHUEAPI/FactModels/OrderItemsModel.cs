using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class OrderItemsModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? OrderItemQuantity { get; set; }
        public int? OrderItemDiscount { get; set; }
        public int? OrderItemPrice { get; set; }

        public virtual OrdersModel Order { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}
