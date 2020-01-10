using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> VendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", VendorOrders);
      return View(model);
    }

    // // This one creates new Items within a given Category, not new Categories:
    // [HttpPost("/categories/{categoryId}/items")]
    // public ActionResult Create(int categoryId, string itemDescription)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category foundCategory = Category.Find(categoryId);
    //   Item newItem = new Item(itemDescription);
    //   foundCategory.AddItem(newItem);
    //   List<Item> categoryItems = foundCategory.Items;
    //   model.Add("items", categoryItems);
    //   model.Add("category", foundCategory);
    //   return View("Show", model);
    // }
  }
}