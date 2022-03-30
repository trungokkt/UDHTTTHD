using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class OrderEvaluation
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string Evaluation { get; set; }
        public DateTime? EvaluationDate { get; set; }

        public virtual Orders Order { get; set; }
        public virtual UserInfo User { get; set; }
    }
}
