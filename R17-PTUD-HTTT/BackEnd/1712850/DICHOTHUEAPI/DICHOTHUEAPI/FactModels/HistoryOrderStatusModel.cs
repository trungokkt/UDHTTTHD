using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class HistoryOrderStatusModel
    {
        public int HistoryId { get; set; }
        public int? OrderStatus { get; set; }
        public DateTime? OrderStatusDate { get; set; }
        public int? OrderId { get; set; }

        //[JsonIgnore]
        public virtual OrdersModel Order { get; set; }
        public virtual StatusModel OrderStatusNavigation { get; set; }
    }
}
