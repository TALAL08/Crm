using Crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.ViewModel
{
    public class NewProductViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Category> Categories { get; set; }


    }
}