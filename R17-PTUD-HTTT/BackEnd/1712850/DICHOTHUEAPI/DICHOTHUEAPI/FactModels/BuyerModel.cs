using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class BuyerModel
    {

        public int UserId { get; set; }
        public int? BuyerDiscount { get; set; }

        public virtual UserInfoModel User { get; set; }

        //[JsonIgnore]
        public virtual ICollection<CartModel> Cart { get; set; }

        //[JsonIgnore]
        public virtual ICollection<OrdersModel> Orders { get; set; }
    }
}
