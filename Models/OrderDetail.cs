using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Crm.Models
{
    public class OrderDetail
    {
        public Order Order { get; set; }

        public OrderItem OrderItem { get; set; }

        [Key]
        [Column(Order =1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int OrderItemId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CustomerName { get; set; }

        public DateTime DateTime { get; set; }
        public int Quantity { get; set; }

        public float TotalPrice { get; set; }


    }
}