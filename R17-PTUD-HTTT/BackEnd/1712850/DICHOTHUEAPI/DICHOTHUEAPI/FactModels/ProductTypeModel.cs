using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class ProductTypeModel
    {

        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int? StoreId { get; set; }
        public int? CategoryId { get; set; }

        public virtual CategoriesModel Category { get; set; }
        public virtual StoreModel Store { get; set; }

        //[JsonIgnore]
        public virtual ICollection<ProductModel> Product { get; set; }
    }
}
