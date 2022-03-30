using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Categories
    {
        public Categories()
        {
            ProductType = new HashSet<ProductType>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductType> ProductType { get; set; }
    }
}
