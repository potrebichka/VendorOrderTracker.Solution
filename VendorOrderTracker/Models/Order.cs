using System;

namespace VendorOrderTracker.Models
{
    public class Order
    {
        public string Title {get;set;}
        public string Description {get;set;}
        public double Price {get;set;}
        public DateTime Date {get;set;}
        public int Id {get;}
        private static int _currentId = 0;
        public Order(string title, string description, double price, DateTime date)
        {
            Title = title;
            Description = description;
            Price = price;
            Date = date;
            Id = _currentId;
            _currentId+=1;
        }
        public static void Clear()
        {
            _currentId = 0;
        }
    }
}