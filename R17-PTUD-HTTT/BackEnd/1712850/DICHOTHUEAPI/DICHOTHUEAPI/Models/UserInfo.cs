using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            OrderEvaluation = new HashSet<OrderEvaluation>();
        }

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

        public virtual Buyer Buyer { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<OrderEvaluation> OrderEvaluation { get; set; }
    }
}
