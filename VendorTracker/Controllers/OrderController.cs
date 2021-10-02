using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet("/vendors/{Id}/orders/new")]
    public ActionResult New (int Id)
    {
      Vendor vendor = Vendor.Find(Id);
      return View(vendor);
    }
  }
}