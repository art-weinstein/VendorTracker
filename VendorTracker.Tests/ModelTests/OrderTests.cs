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
    [TestMethod]
    public void GetOrderDescription_ReturnOrderDescription_String()
    {
      string description = "Baked Fresh";
      Order newOrder = new Order ("bread", description, "Price", "Date");
      string result = newOrder.Description;
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void GetOrderPrice_ReturnOrderPrice_String()
    {
      string price = "12";
      Order newOrder = new Order ("Bread", "Description", price, "Date");
      string result = newOrder.Price;
      Assert.AreEqual(price, result);
    }
      [TestMethod]
    public void GetOrderDate_ReturnOrderDate_String()
    {
      string date = "June 12th 2021";
      Order newOrder = new Order ("Bread", "Description", "Price", date);
      string result = newOrder.Date;
      Assert.AreEqual(date, result);
    }
    [TestMethod]
    public void GetAll_ReturnAnEmptyOrderList_OrderList()
    {
      List<Order> newOrderList = new List<Order> {};
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newOrderList, result);
    }
    [TestMethod]
    public void GetAll_InstantiateOrderId_Int()
    {
      Order newOrder = new Order ("Title", "Description", "Price", "Date");
      int result = newOrder.Id;
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void Find_ReturnOrderById_Order()
    {
      Order newOrder1 = new Order ("Title", "Description", "Price", "Date");
      Order newOrder2 = new Order ("Title2", "Description2", "Price2", "Date2");
      Order result = Order.Find(1);
      Assert.AreEqual(newOrder1, result);
    }
    [TestMethod]
    public void GetAll_ReturnOrderList_Order()
    {
      Order newOrder1 = new Order ("Title", "Description", "Price", "Date");
      Order newOrder2 = new Order ("Title2", "Description2", "Price2", "Date2");
      List<Order> list = new List<Order> {newOrder1, newOrder2};
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(list, result);
    }
  }
}