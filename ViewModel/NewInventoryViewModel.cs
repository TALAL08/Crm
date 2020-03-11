using Crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.ViewModel
{
    public class NewInventoryViewModel
    {
        public string    Name { get; set; }

        public IList<Product> Product { get; set; }

        public IList<Category> Categories { get; set; }

        public IList<int> ProductIds { get; set; }

        public IList<int> Quantity { get; set; }

        public IList<int> StoreId { get; set; }
    }
}