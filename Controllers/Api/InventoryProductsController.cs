using Crm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crm.Controllers.Api
{
    public class InventoryProductsController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public InventoryProductsController()
        {
            _Context = new ApplicationDbContext();
        }

        public IHttpActionResult GetInventoryProducts(int Id)
        {
            var InventoryProducts = _Context.InventoryProducts.Include(p => p.Product).Include(p => p.Product.Category).Where(i => i.InventoryId == Id).ToList();



            return Ok(InventoryProducts);
        }
    }
}
