using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class ShipperModel
    {

        public int UserId { get; set; }
        public int? ShipperRate { get; set; }

        public virtual UserInfoModel User { get; set; }
        public virtual ICollection<OrdersModel> Orders { get; set; }
    }
}
