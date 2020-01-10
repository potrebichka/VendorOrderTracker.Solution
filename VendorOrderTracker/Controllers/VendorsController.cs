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

    [HttpGet("/vendors/{id}/edit")]
    public ActionResult Edit(int id)
    {
        Vendor foundVendor = Vendor.Find(id);
        return View(foundVendor);
    }

    [HttpPost("/vendors/{id}")]
    public ActionResult Update(int id, string updatedVendorName, string updatedVendorDescription)
    {
        Vendor foundVendor = Vendor.Find(id);
        foundVendor.Name = updatedVendorName;
        foundVendor.Description = updatedVendorDescription;
        return RedirectToAction("Show", id);
    }
  }
}