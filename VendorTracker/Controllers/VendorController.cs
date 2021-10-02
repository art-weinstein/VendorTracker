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
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      Vendor currentVendor = Vendor.Find(Id);
      List<Order> purchases = currentVendor.Purchases;
      dictionary.Add("vendor", currentVendor);
      dictionary.Add("orders", purchases);
      return View(dictionary);
    }
    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string title, string description, string price, string date)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(title, description, price, date);
      selectedVendor.AddOrder(newOrder);
      List<Order> purchases = selectedVendor.Purchases;
      dictionary.Add("orders", purchases);
      dictionary.Add("vendor", selectedVendor);
      return View("Show", dictionary);
    }
  }
}