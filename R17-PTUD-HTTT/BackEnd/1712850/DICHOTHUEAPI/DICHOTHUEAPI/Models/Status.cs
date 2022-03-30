using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class Status
    {
        public Status()
        {
            HistoryOrderStatus = new HashSet<HistoryOrderStatus>();
        }

        public int Code { get; set; }
        public string Lable { get; set; }

        public virtual ICollection<HistoryOrderStatus> HistoryOrderStatus { get; set; }
    }
}
