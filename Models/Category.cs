using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crm.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


    }
}