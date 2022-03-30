using System;
using System.Collections.Generic;

namespace DICHOTHUEAPI.FactModels
{
    public partial class HibernateSequencesModel
    {
        public string SequenceName { get; set; }
        public long? NextVal { get; set; }
    }
}
