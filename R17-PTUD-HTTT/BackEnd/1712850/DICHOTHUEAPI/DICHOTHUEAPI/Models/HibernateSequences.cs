using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.Models
{
    public partial class HibernateSequences
    {
        public string SequenceName { get; set; }
        public long? NextVal { get; set; }
    }
}
