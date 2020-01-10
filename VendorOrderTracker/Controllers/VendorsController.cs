using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;
using System.Windows;

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
    public ActionResult Create(string vendorName, string vendorDescription, bool deleteVendors)
    {
        if (deleteVendors)
        {
            Vendor.ClearAll();
        }
        else if (vendorName != null)
        {
            Vendor newVendor = new Vendor(vendorName, vendorDescription);
        }
        
        return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor selectedVendor = null;
        List<Order> VendorOrders = null;
        if (id != -1)
        {
            selectedVendor = Vendor.Find(id);
            if (selectedVendor != null)
            {
                VendorOrders = selectedVendor.Orders;
            }
            
        }

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
    public ActionResult Update(int id, string updatedVendorName, string updatedVendorDescription, bool deleteVendor)
    {
        if (!deleteVendor)
        {
            Vendor foundVendor = Vendor.Find(id);
            if (updatedVendorName != null)
            {
                foundVendor.Name = updatedVendorName;
            }
            if (updatedVendorDescription != null)
            {
                foundVendor.Description = updatedVendorDescription;
            }
            
        }
        else
        {
            Vendor.Delete(id);
            id =-1;
        }

        
        return RedirectToAction("Show", id);
    }

    
    [HttpGet("/vendors/{id}/delete")]
    public ActionResult Destroy(int id)
    {
        Vendor foundVendor = Vendor.Find(id);
        return View(foundVendor);
    }

    [HttpGet("/vendors/delete")]
    public ActionResult Delete()
    {
        return View();
    }
  }
}