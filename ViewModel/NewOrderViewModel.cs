using Crm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crm.ViewModel
{
    public class NewOrderViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<Store> Stores { get; set; }

        public IList<int> ProductIds { get; set; }

        public IList<int> ProductId { get; set; }

        public IList<int> InventoryIds { get; set; }

        public IList<int> Quantity { get; set; }

        public Store Store { get; set; }

        public DateTime DateTime { get; set; }

    }
}