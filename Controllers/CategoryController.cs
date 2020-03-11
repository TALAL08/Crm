using Crm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public CategoryController()
        {
            _Context = new ApplicationDbContext();
        }
        // GET: Category
        public ActionResult New()
        {

            return View();
        }

        public ActionResult Edit(int Id)
        {
            var category = _Context.Categories.Single(c => c.Id == Id);


            return View("New", category);
        }

        public ActionResult Save(Category category)
        {
            

            var Category = _Context.Categories.SingleOrDefault(c => c.Name == category.Name);

            if (Category == null)
            {
                _Context.Categories.Add(category);
                _Context.SaveChanges();

                return Redirect("/Home/Index");
            }

            else
            {
                return View("New");
            }
        }

        public ActionResult ListOfCategories()
        {

            return View();
        }
    }
}