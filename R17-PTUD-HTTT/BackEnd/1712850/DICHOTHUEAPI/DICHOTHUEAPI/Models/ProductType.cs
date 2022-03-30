using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int? StoreId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
