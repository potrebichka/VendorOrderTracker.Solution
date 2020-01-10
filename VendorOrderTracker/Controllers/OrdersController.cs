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
        public ActionResult Create(int vendorId, string orderTitle, string orderDescription, double orderPrice, DateTime orderDate)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Vendor foundVendor = Vendor.Find(vendorId);
            Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
            foundVendor.AddOrder(newOrder);
            List<Order> vendorOrders = foundVendor.GetOrderList();
            model.Add("orders", vendorOrders);
            model.Add("vendor", foundVendor);
            return View("Index", model);
        }
    }
}