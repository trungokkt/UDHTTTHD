using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class CategoriesModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductTypeModel> ProductType { get; set; }
    }
}
