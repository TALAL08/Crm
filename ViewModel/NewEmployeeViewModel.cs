using Crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.ViewModel
{
    public class NewEmployeeViewModel
    {
        public Employee Employee { get; set; }

        public EmployeeAccountDetails AccountDetails { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; }

        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<Designation> Designations { get; set; }



      



    }
}