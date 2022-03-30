using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Store
    {
        public Store()
        {
            ProductType = new HashSet<ProductType>();
        }

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

        public virtual Seller User { get; set; }
        public virtual ICollection<ProductType> ProductType { get; set; }
    }
}
