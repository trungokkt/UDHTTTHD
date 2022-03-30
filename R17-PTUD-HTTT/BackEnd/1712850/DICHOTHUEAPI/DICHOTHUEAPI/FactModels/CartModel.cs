using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class CartModel
    {
        public int CartId { get; set; }
        public int? CartQuantity { get; set; }
        public int? CartPrice { get; set; }
        public int? UserId { get; set; }

        public virtual BuyerModel User { get; set; }

        
        public virtual ICollection<CartItemsModel> CartItems { get; set; }
    }
}
