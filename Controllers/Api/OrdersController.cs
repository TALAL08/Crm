using Crm.Models;
using Crm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crm.Controllers.Api
{

    public class OrdersController : ApiController
    {
        private readonly ApplicationDbContext _Context;
        public OrdersController()
        {
            _Context = new ApplicationDbContext();
        }

        public  IHttpActionResult GetProducts(int Id, string query)
        {

           
            var prodoucts = _Context.InventoryProducts.Where(ip => ip.InventoryId == Id).Select(p => p.Product).ToList();

            return Ok(prodoucts);
        }

       

        [HttpPost]
        public IHttpActionResult CreateOrder(NewOrderViewModel newOrder)
        {
            if(newOrder.ProductId[0] != 0)
            {
                var Product = newOrder.ProductIds.Contains(newOrder.ProductId[0]);

                if (Product)
                {
                    var quantity = newOrder.Quantity.First() + 1;

                    newOrder.Quantity[0] = quantity;

                    return Ok(newOrder);
                }

                else
                    return NotFound();

               
            }




            var inventoryId = newOrder.InventoryIds.First();

            var prodoucts = _Context.InventoryProducts.Where(ip => ip.InventoryId == inventoryId ).Select(p => p.Product).ToList();

            var store = _Context.Stores.Single(s => s.InventoryId == inventoryId);

            var Order = new Order
            {
                Store = store
            };

            var orderproducts = prodoucts.Where(p => newOrder.ProductIds.Contains(p.Id)).ToList();
            int i = 0;

            foreach (var Product in orderproducts)
            {
                var quantity = newOrder.Quantity[i];
                Product.QuantityInStock -= quantity;
                
                if (Product.QuantityInStock < 0)
                    return BadRequest();

               var TotalPrice = Product.Price * quantity;
                
                var  Orderitem = new OrderItem
                {
                    Product = Product
                };
                
                _Context.OrderItems.Add(Orderitem);


                
              

                var OrderDetail = new OrderDetail
                {
                    CustomerName = newOrder.Name,
                    Order = Order,
                    OrderItem = Orderitem,
                    DateTime = DateTime.Now,
                    Quantity = quantity,
                    TotalPrice = TotalPrice
                };

                _Context.OrderDetails.Add(OrderDetail);
                
                i += 1;
               
            }

            _Context.Orders.Add(Order);

            _Context.SaveChanges();

            
            return  Ok();
        }

        
    }
}
