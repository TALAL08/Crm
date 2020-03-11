using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Crm.Models
{
    public class InventoryProducts
    {
        public string InventoryName { get; set; }
        public Inventory Inventory { get; set; }

        public Product Product { get; set; }

        [Key]
        [Column(Order =1)]
        public int InventoryId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
    }
}