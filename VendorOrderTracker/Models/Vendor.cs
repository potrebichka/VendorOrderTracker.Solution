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
            Orders =  new List<Order> {};
            _currentId++;
            _Vendors.Add(this);
        }        
        public static void ClearAll()
        {
            _Vendors.Clear();
            _currentId = 0;
        }
        public static List<Vendor> GetAll()
        {
            return _Vendors;
        }
        public static Vendor Find(int id)
        {
            for (int i =0; i < _Vendors.Count; i++)
            {
                if (_Vendors[i].Id == id)
                {
                    return _Vendors[i];
                }
            }
            return null;
        }
        public static void Delete(int id)
        {
            for (int i =_Vendors.Count-1; i >= 0; i--)
            {
                if (_Vendors[i].Id == id)
                {
                    _Vendors.RemoveAt(i);
                    break;
                }
            }
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public List<Order> GetOrderList()
        {
            return Orders;
        }

        public Order FindOrder(int id)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Id == id)
                {
                    return Orders[i];
                }
            }
            return null;
        }

        public void DeleteOrder(int id)
        {
            for (int i = Orders.Count-1; i >= 0; i--)
            {
                if (Orders[i].Id == id)
                {
                    Orders.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteAllOrders()
        {
            Orders.Clear();
        }
    }
}