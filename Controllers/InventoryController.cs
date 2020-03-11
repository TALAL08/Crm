using Crm.Models;
using Crm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.Controllers
{
    public class InventoryController : Controller
    {
        readonly ApplicationDbContext _Context;
        public InventoryController()
        {
            _Context = new ApplicationDbContext();
        }
        // GET: Inventry
        public ActionResult New()
        {
            var products = _Context.Products.ToList();
            var Categories = _Context.Categories.ToList();

            var ViewModel = new NewInventoryViewModel
            {
              
                Categories = Categories

            };

            return View("InventoryForm",ViewModel);
        }

        public ActionResult ListOfInventories()
        {
            return View();
        }

      
    }
}