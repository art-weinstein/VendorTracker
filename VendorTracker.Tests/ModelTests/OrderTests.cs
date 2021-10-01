using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order ("Title", "Description", "Price", "Date");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetOrderTitle_ReturnOrderTitle_String()
    {
      string title = "Bread";
      Order newOrder = new Order (title, "Description", "Price", "Date");
      string result = newOrder.Title;
      Assert.AreEqual(title, result);
    }
  }
}