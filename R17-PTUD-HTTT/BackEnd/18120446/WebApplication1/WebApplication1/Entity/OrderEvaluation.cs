using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entity
{
    public partial class OrderEvaluation
    {
        [Key]
        public int OrderId { get; set; }        public int UserId { get; set; }        public string Evaluation { get; set; }
        public DateTime EvaluationDate { get; set; }
       

    }
}
