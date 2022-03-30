using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entity
{
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        public int ProductId { get; set; }        public string ProductName { get; set; }        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductInventory { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductIsDelete { get; set; }








    }
}
