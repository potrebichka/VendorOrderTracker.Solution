using System;
using System.Collections.Generic;

namespace VendorOrderTracker
{
    public class Vendor
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public int Id {get;}
        public List<Order> Orders = new List<Order> {};
        
    }
}