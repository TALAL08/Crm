using Crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.ViewModel
{
    public class StoreViewModel
    {
        public Store Store { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<Store> Stores { get; set; }

        public string Heading { get; set; }

        public Employee Manager { get; set; }

        public Inventory Inventory { get; set; }

        public IEnumerable< Inventory > Inventories { get; set; }
    }
}