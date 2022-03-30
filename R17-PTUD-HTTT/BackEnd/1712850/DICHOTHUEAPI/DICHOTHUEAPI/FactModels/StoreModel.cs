using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class StoreModel
    {


        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public int? StoreRate { get; set; }
        public int? StoreArea { get; set; }
        public int? UserId { get; set; }
        public string StoreLat { get; set; }
        public string StoreLng { get; set; }
        public string StoreImg { get; set; }

        public virtual SellerModel User { get; set; }
        public virtual ICollection<ProductTypeModel> ProductType { get; set; }
    }
}
