using Crm.Models;
using Crm.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crm.Controllers.Api
{
   
    public class InventoriesController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public InventoriesController()
        {
            _Context = new ApplicationDbContext();
        }


       public IHttpActionResult GetInventories()
        {
            var Inventories = _Context.Inventories.ToList();

            return Ok(Inventories);
        }


        


     
        [HttpPost]
       
        public IHttpActionResult CreateInventory(NewInventoryViewModel NewInventory)
        {
            var InventoryName = _Context.Inventories.Where(a => NewInventory.Name.Contains(a.Name));

            if (InventoryName == null)
                return BadRequest();
                
         
            var Inventory = new Inventory
            {
                Name = NewInventory.Name
            };

            _Context.Inventories.Add(Inventory);

            var Products = _Context.Products.Where(p => NewInventory.ProductIds.Contains(p.Id)).ToList();
            int i = 0;
            foreach (var Product in Products)
            {
                var quantity = NewInventory.Quantity[i];

                Product.QuantityInStock -= quantity;

                if (Product.QuantityInStock < 0)
                    return BadRequest();

                var InventoryProducts = new InventoryProducts
                {
                    Inventory = Inventory,
                    InventoryName = NewInventory.Name,
                    Product = Product
                };

                _Context.InventoryProducts.Add(InventoryProducts);
        
                i += 1;
            }

            _Context.SaveChanges();
            
            return Ok();

        }
    }
}
