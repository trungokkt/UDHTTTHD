using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public int? ShipperRate { get; set; }

        public virtual UserInfo User { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
