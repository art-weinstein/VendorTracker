using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public string VendorDescription { get; set; }
    public int Id { get; }
    public List<Order> Purchases { get; set; }
    private static List<Vendor> _instances = new List<Vendor> {};

    public Vendor (string name, string vendorDescription)
    {
      Name = name;
      VendorDescription = vendorDescription;
      _instances.Add(this);
      Id = _instances.Count;
      Purchases = new List<Order>{};
    }
    public static List<Vendor> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Vendor Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    public void AddOrder(Order order)
    {
      Purchases.Add(order);
    }
  }
}