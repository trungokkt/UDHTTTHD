using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Store = new HashSet<Store>();
        }

        public int UserId { get; set; }

        public virtual UserInfo User { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
