using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class UserInfoModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? UserBirth { get; set; }
        public int? UserGender { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public int? UserArea { get; set; }
        public string UserLoginName { get; set; }
        public string UserPassword { get; set; }
        public string UserImg { get; set; }

        //[JsonIgnore]
        public virtual BuyerModel Buyer { get; set; }

        //[JsonIgnore]
        public virtual SellerModel Seller { get; set; }

        //[JsonIgnore]
        public virtual ShipperModel Shipper { get; set; }

        public virtual ICollection<OrderEvaluationModel> OrderEvaluation { get; set; }
    }
}
