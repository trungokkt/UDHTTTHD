using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Orders>();
        }
        public Shipper(int id)
        {
            Orders = new HashSet<Orders>();
            UserId = id;
            ShipperRate = -1;
        }

        [Key]
        public int UserId { get; set; }
        public int? ShipperRate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserInfo.Shipper))]
        public virtual UserInfo User { get; set; }
        [InverseProperty("Shipper")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
