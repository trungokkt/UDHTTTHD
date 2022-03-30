using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class SellerModel
    {

        public int UserId { get; set; }

        public virtual UserInfoModel User { get; set; }
        public virtual ICollection<StoreModel> Store { get; set; }
    }
}
