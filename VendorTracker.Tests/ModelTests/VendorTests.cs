using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
    Vendor newVendor = new Vendor("Test", "Test");
    Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    [TestMethod]
    public void GetVendorName_ReturnVendorName_String()
    {
      string name = "The Dude";
      Vendor newVendor = new Vendor (name, "Description");
      string result = newVendor.Name;
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void GetVendorDescription_ReturnVendorDescription_String()
    {
      string vendorDescription = "Bowling";
      Vendor newVendor = new Vendor ("name", vendorDescription);
      string result = newVendor.VendorDescription;
      Assert.AreEqual(vendorDescription, result);
    }
    [TestMethod]
    public void GetAll_ReturnAnEmptyVendorList_VendorList()
    {
      List<Vendor> newVendorList = new List<Vendor> {};
      List<Vendor> result = Vendor.GetAll();
      CollectionAssert.AreEqual(newVendorList, result);
    }
    [TestMethod]
    public void GetAll_ReturnVendorList_VendorList()
    {
      Vendor newVendor1 = new Vendor ("name1", "description1");
      Vendor newVendor2 = new Vendor ("name2", "description2");
      List<Vendor> list = new List<Vendor> {newVendor1, newVendor2};
      List<Vendor> result = Vendor.GetAll();
      CollectionAssert.AreEqual(list, result);
    }
    [TestMethod]
    public void GetAll_InstantiateVendorId_int()
    {
      Vendor newVendor = new Vendor("Test", "Test");
      int result = newVendor.Id;
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void Find_ReturnVendorById_Vendor()
    {
      Vendor newVendor1 = new Vendor ("name1", "description1");
      Vendor newVendor2 = new Vendor ("name2", "description2");
      Vendor result = Vendor.Find(2);
      Assert.AreEqual(newVendor2, result);
    }
    [TestMethod]
    public void AddOrder_AddsPurchaseToVendorOrderList_OrderList()
    {
      Order newOrder = new Order ("Title", "Description", "Price", "Date");
      List<Order> orderList = new List<Order> {newOrder};
      Vendor newVendor = new Vendor("Test", "Test");
      newVendor.AddOrder(newOrder);
      List<Order> result = newVendor.Purchases;
      CollectionAssert.AreEqual(orderList, result);
    }
  }
}