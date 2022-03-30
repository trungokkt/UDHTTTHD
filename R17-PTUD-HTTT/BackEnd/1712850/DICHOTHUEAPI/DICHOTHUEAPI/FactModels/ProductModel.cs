using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class ProductModel
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductInventory { get; set; }
        public int? ProductTypeId { get; set; }
        public string ProductUnit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ProductImage { get; set; }

        public virtual ProductTypeModel ProductType { get; set; }
        //[JsonIgnore]
        public virtual ICollection<CartItemsModel> CartItems { get; set; }
        //[JsonIgnore]
        public virtual ICollection<OrderItemsModel> OrderItems { get; set; }
    }
}
