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
    public class ProductsController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public ProductsController()
        {
            _Context = new ApplicationDbContext();
        }



        public IHttpActionResult GetProducts(string query = null)
        {
            var Products = _Context.Products.Include(p => p.Category);

            if (string.IsNullOrEmpty(query))
            {

                var ProductList = Products.ToList();
                return Ok(ProductList);
            }
            
                if (!string.IsNullOrWhiteSpace(query))
                    Products = Products.Where(m => m.Name.Contains(query) && m.QuantityInStock > 0);
            
            var productsList = Products.ToList();
            return Ok(productsList);
        }


        public IHttpActionResult GetProducts(int id, string query = null)
        {
          

            return Ok();
        }

            public void DeleteProduct(int Id)
        {
            var Products = _Context.Products.Single(p => p.Id == Id);

            _Context.Products.Remove(Products);

            _Context.SaveChanges();

        }
    }
}
