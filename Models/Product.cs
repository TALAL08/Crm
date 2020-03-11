using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QuantityInStock { get; set; }
        public float Price { get; set; }


        public string ExpiryDate { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }


        
    }


}