using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public string ContactNo { get; set; }

        public bool ManagerAssign { get; set; }
        public Inventory Inventory { get;  set; }

        public int InventoryId { get; set; }
       
    }
}