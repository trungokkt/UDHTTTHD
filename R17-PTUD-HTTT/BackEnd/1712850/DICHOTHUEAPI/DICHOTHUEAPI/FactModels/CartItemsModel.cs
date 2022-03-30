using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class CartItemsModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int? CartItemQuantity { get; set; }
        public int? CartItemPrice { get; set; }

        public virtual CartModel Cart { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
