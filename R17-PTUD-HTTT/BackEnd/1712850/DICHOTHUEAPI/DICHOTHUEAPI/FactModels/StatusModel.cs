using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICHOTHUEAPI.FactModels
{
    public class StatusModel
    {
        public int Code { get; set; }
        public string Lable { get; set; }

        public virtual ICollection<HistoryOrderStatusModel> HistoryOrderStatus { get; set; }
    }
}
