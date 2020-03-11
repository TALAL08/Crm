using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
       
        public Product Product { get; set; }

        public int ProductId { get; set; }

        

       



    }
}