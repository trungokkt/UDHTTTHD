using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiChoThue.Models
{
    public partial class OrderEvaluation
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string Evaluation { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EvaluationDate { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.OrderEvaluation))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserInfo.OrderEvaluation))]
        public virtual UserInfo User { get; set; }
    }
}
