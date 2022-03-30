using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Store = new HashSet<Store>();
        }
        public Seller(int id)
        {
            Store = new HashSet<Store>();
            UserId = id;
        }

        [Key]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserInfo.Seller))]
        public virtual UserInfo User { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Store> Store { get; set; }
    }
}
