using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTest : IDisposable
  {

    public void Dispose()
    {
      Order.Clear();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("title", "description", 10.00, new DateTime(2020,01,20));
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);

        //Act
        Order order = new Order(title, orderDescription, price, date);
        string result = order.Title;

        //Assert
        Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);

        //Act
        Order order = new Order(title, orderDescription, price, date);
        string result = order.Description;

        //Assert
        Assert.AreEqual(orderDescription, result);
    }

    [TestMethod]
    public void GetPrice_ReturnsPrice_String()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);

        //Act
        Order order = new Order(title, orderDescription, price, date);
        double result = order.Price;

        //Assert
        Assert.AreEqual(price, result);
    }

    [TestMethod]
    public void GetDate_ReturnsDate_String()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);

        //Act
        Order order = new Order(title, orderDescription, price, date);
        DateTime result = order.Date;

        //Assert
        Assert.AreEqual(date, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);
        Order order = new Order(title, orderDescription, price, date);

        //Act
        string updatedTitle = "Order 2";
        order.Title = updatedTitle;
        string result = order.Title;

        //Assert
        Assert.AreEqual(updatedTitle, result);
    }

        [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);
        Order order = new Order(title, orderDescription, price, date);

        //Act
        string updatedDescription = "Another description";
        order.Description = updatedDescription;
        string result = order.Description;

        //Assert
        Assert.AreEqual(updatedDescription, result);
    }

        [TestMethod]
    public void SetPrice_SetPrice_Double()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);
        Order order = new Order(title, orderDescription, price, date);

        //Act
        double updatedPrice = 21.50;
        order.Price = updatedPrice;
        double result = order.Price;

        //Assert
        Assert.AreEqual(updatedPrice, result);
    }

        [TestMethod]
    public void SetDate_SetDate_DateTime()
    {
      //Arrange
        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);
        Order order = new Order(title, orderDescription, price, date);

        //Act
        DateTime updatedDate = new DateTime(2020,01,15);
        order.Date = updatedDate;
        DateTime result = order.Date;

        //Assert
        Assert.AreEqual(updatedDate, result);
    }
  }
}