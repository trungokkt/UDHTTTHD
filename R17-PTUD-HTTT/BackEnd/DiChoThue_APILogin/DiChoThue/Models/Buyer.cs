using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Orders = new HashSet<Orders>();
        }

        public Buyer(int id)
        {
            UserId = id;
            BuyerDiscount = 0;
            Cart = new Cart();
        }

        [Key]
        public int UserId { get; set; }
        public int? BuyerDiscount { get; set; }

        public virtual UserInfo User { get; set; }
        [InverseProperty("User")]
        public virtual Cart Cart { get; set; }
        [InverseProperty("Buyer")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
