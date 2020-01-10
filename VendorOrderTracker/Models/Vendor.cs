using System;
using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
    public class Vendor
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public int Id {get;}
        public List<Order> Orders = new List<Order> {};
        private static List<Vendor> _Vendors = new List<Vendor> {};
        private static int _currentId = 0;
        public Vendor (string name, string description)
        {
            Name = name;
            Description = description;
            Id = _currentId;
            _currentId++;
        }        
        public static void ClearAll()
        {
            _Vendors.Clear();
        }
        
    }
}