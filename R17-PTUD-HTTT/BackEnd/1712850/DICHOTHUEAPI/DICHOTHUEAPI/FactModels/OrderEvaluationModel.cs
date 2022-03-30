using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class OrderEvaluationModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string Evaluation { get; set; }
        public DateTime? EvaluationDate { get; set; }

        public virtual OrdersModel Order { get; set; }
        public virtual UserInfoModel User { get; set; }
    }
}
