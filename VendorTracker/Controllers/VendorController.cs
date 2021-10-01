using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class VendorController : Controller
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
    public ActionResult Create (string name, string vendorDescription)
    {
      Vendor newVendor = new Vendor(name, vendorDescription);
      return RedirectToAction("Index");
    }
    [HttpGet("/vendors/{Id}")]
    public ActionResult Show(int Id)
    {
      Vendor vendor = Vendor.Find(Id);
      return View(vendor);
    }
  }
}