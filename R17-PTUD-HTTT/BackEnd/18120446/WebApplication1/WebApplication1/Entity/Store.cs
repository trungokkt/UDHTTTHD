using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entity
{
    public partial class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        public int StoreId { get; set; }        public string StoreName { get; set; }        public string StorePhone { get; set; }
        public int StoreRate { get; set; }
        public int StoreArea { get; set; }
        public int UserId { get; set; }
        

    }
}
