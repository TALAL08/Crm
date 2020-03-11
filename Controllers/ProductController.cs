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
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public ProductController()
        {
            _Context = new ApplicationDbContext();
        }

        // GET: Product
        public ActionResult New()
        {

            var ViewModel = new NewProductViewModel
            {
                Categories = _Context.Categories.ToList()
            };

            return View("ProductForm",ViewModel);
        }

        public ActionResult Edit(int Id)
        {
            var Product = _Context.Products.Include(p => p.Category).Single(p => p.Id == Id);

            if (Product != null)
            {

                var ViewModel = new NewProductViewModel
                {
                    Product = Product,
                    Categories = _Context.Categories.ToList()
                };

                return View("ProductForm", ViewModel);
            }

            else
                return HttpNotFound();
        }

        public ActionResult Save(Product product)
        {
            var Product = _Context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == product.Id);

            if(Product != null)
            {
                Product.Name = product.Name;
                Product.Price = product.Price;
                Product.QuantityInStock = product.QuantityInStock;
                Product.CategoryId = product.CategoryId;
                Product.ExpiryDate = product.ExpiryDate;
            }
            
            else
            _Context.Products.Add(product);
            
            _Context.SaveChanges();


            return Redirect("/Home/Index");

        }
        public ActionResult ListOfProducts()
        {

            return View();
        }
    }


}