    using Crm.Models;
using Crm.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.Controllers
{
    public class StoreController : Controller
    {

        readonly ApplicationDbContext _Context;
        public StoreController()
        {
            _Context = new ApplicationDbContext();
        }


        // GET: Store
        public ActionResult New()
        {
            var Inventory = _Context.Inventories.ToList();
            var ViewModel = new StoreViewModel
            {
               Inventories = Inventory,
                Heading = "Add Store"
            };
            return View("StoreForm",ViewModel);
        }


        public ActionResult Save(Store store)
         {
            var Store = _Context.Stores.Include(s => s.Inventory).SingleOrDefault(s => s.Id == store.Id);

            if(Store != null)
            {
                Store.Name = store.Name;
                Store.InventoryId = store.Inventory.Id;
                Store.Address = store.Address;
                Store.ContactNo = store.ContactNo;

            }

            else
            _Context.Stores.Add(store);

            _Context.SaveChanges();

           return RedirectToAction("Index", "Home");
            
            
        }

        public ActionResult Edit(int Id)
        {
            var Store = _Context.Stores.Include(s => s.Inventory).Single(s => s.Id == Id);

            var ViewModel = new StoreViewModel
            {
                Store = Store,
                Heading = "Edit A Store",
                Inventories = _Context.Inventories.ToList()

            };



            return View("StoreForm", ViewModel);
        }

        public ActionResult ListOfStores()
        {

            return View();
        }


    }
}