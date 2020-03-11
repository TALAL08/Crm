using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crm.Models
{
    public class Order
    {
        public int Id { get; set; }


        public Store Store { get; set; }

        public int StoreId { get; set; }





    }
}