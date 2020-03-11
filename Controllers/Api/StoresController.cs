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
    public class StoresController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public StoresController()
        {
            _Context = new ApplicationDbContext();
        }

        public IHttpActionResult GetStores()
        {

            var stores = _Context.Stores.Include(s => s.Inventory).ToList();

            return Ok(stores);
        }
    }
}
