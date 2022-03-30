using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            OrderEvaluation = new HashSet<OrderEvaluation>();
        }

        public UserInfo(UserInfo u)
        {
            UserId = u.UserId;
            UserName = u.UserName;
            UserBirth = u.UserBirth;
            UserGender = u.UserGender;
            UserPhone = u.UserPhone;
            UserEmail = u.UserEmail;
            UserAddress = u.UserAddress;
            UserArea = u.UserArea;
            UserLoginName = u.UserLoginName;
            UserPassword = u.UserPassword;
            UserImg = u.UserImg;
        }

        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UserBirth { get; set; }
        public int? UserGender { get; set; }
        [StringLength(20)]
        public string UserPhone { get; set; }
        [StringLength(50)]
        public string UserEmail { get; set; }
        [StringLength(200)]
        public string UserAddress { get; set; }
        public int? UserArea { get; set; }
        [StringLength(50)]
        public string UserLoginName { get; set; }
        [StringLength(100)]
        public string UserPassword { get; set; }
        [StringLength(100)]
        public string UserImg { get; set; }
        public virtual Buyer Buyer { get; set; }
        [InverseProperty("User")]
        public virtual Seller Seller { get; set; }
        [InverseProperty("User")]
        public virtual Shipper Shipper { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<OrderEvaluation> OrderEvaluation { get; set; }
    }
}
