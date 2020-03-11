using Crm.Models;
using Crm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public OrderController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult New()
        {
            
            var ViewModel = new NewOrderViewModel
            {
                Store = _Context.Stores.First()
                
            };

           
            
            return View("OrderForm", ViewModel);
        }
    }
}