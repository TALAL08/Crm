using Crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crm.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public CategoriesController()
        {
            _Context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCategories()
        {
            var categories = _Context.Categories.ToList();

            return Ok(categories);
        }

        public void DeleteCategory(int Id)
        {
            var Category = _Context.Categories.Single(c => c.Id == Id);

            _Context.Categories.Remove(Category);

            _Context.SaveChanges();
        }
    }
}
