using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet("/vendors/{vendorId}/orders")]
        public ActionResult Index(int vendorId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            List<Order> foundOrders = foundVendor.GetOrderList();
            model.Add("orders", foundOrders);
            model.Add("vendor", foundVendor);
            return View(model);
        }

        [HttpGet("/vendors/{vendorId}/orders/new")]
        public ActionResult New(int vendorId)
        {
            Vendor foundVendor = Vendor.Find(vendorId);
            return View(foundVendor);
        }

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string orderTitle, string orderDescription, double orderPrice, DateTime orderDate, bool deleteOrders)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            List<Order> vendorOrders = null;
            if (deleteOrders)
            {
                foundVendor.DeleteAllOrders();
            }
            else if (orderTitle != null)
            {
                Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
                foundVendor.AddOrder(newOrder);
                vendorOrders = foundVendor.GetOrderList();
            }
            else 
            {
                vendorOrders = foundVendor.GetOrderList();
            }
            
            model.Add("orders", vendorOrders);
            model.Add("vendor", foundVendor);
            return View("Index", model);
        }

        [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
        public ActionResult Show(int vendorId, int orderId)
        {
            Dictionary<string, object> model = new Dictionary <string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Order foundOrder = foundVendor.FindOrder(orderId);
            model.Add("vendor", foundVendor);
            model.Add("order", foundOrder);
            return View(model);
        }

        [HttpGet("/vendors/{vendorId}/orders/{orderId}/delete")]
        public ActionResult Destroy(int vendorId, int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Order foundOrder = foundVendor.FindOrder(orderId);
            model.Add("vendor", foundVendor);
            model.Add("order", foundOrder);
            return View(model);
        }

        [HttpGet("/vendors/{vendorId}/orders/{orderId}/edit")]
        public ActionResult Edit(int vendorId, int orderId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Order foundOrder = foundVendor.FindOrder(orderId);
            model.Add("vendor", foundVendor);
            model.Add("order", foundOrder);
            return View(model);
        }

        [HttpPost("/vendors/{vendorId}/orders/{orderId}")]
        public ActionResult Update(int vendorId, int orderId, string updatedOrderTitle, string updatedOrderDescription, double updatedOrderPrice, DateTime updatedOrderDate, bool deleteOrder)
        {
            if (!deleteOrder)
            {
                Vendor foundVendor = Vendor.Find(vendorId);
                Order foundOrder = foundVendor.FindOrder(orderId);
                if (updatedOrderTitle != null)
                {
                    foundOrder.Title = updatedOrderTitle;
                }
                if (updatedOrderDescription != null)
                {
                    foundOrder.Description = updatedOrderDescription;
                }
                if (updatedOrderPrice != null)
                {
                    foundOrder.Price = updatedOrderPrice;
                }
                if (updatedOrderDate != null)
                {
                    foundOrder.Date = updatedOrderDate;
                }
                
            }
            else
            {
                Vendor foundVendor = Vendor.Find(vendorId);
                foundVendor.DeleteOrder(orderId);
                orderId =-1;
            }

            return RedirectToAction("Show", orderId);
        }

        [HttpGet("/vendors/{vendorId}/orders/delete")]
        public ActionResult Delete(int vendorId)
        {
            Vendor foundVendor = Vendor.Find(vendorId);
            return View(foundVendor);
        }
    }
}