using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTest : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("name", "description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Suzie's Cafe";
      string description = "Some description";

      //Act
      Vendor newVendor = new Vendor(name, description);
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string name = "Suzie's Cafe";
      string description = "Some description";

      //Act
      Vendor newVendor = new Vendor(name, description);
      string result = newVendor.Description;

      //Assert
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetName_SetName_String()
    {
      //Arrange
      string name = "Suzie's Cafe";
      string description = "Some description";
      Vendor newVendor = new Vendor(name, description);

      //Act
      string updatedName = "Suzie's Restaraunt";
      newVendor.Name = updatedName;
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string name = "Suzie's Cafe";
      string description = "Some description";
      Vendor newVendor = new Vendor(name, description);

      //Act
      string updatedDescription = "Add another description";
      newVendor.Description = updatedDescription;
      string result = newVendor.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_VendorList()
    {
      // Arrange
      List<Vendor> newList = new List<Vendor> { };

      // Act
      List<Vendor> result = Vendor.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsVendors_VendorList()
    {
      //Arrange
      string name01 = "Susie's Cafe";
      string description01 = "Description";
      string name02 = "Pete's bakery";
      string description02 = "Another description";
      Vendor newVendor1 = new Vendor(name01, description01);
      Vendor newVendor2 = new Vendor(name02, description02);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_VendorsInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      
      string name = "Suzie's Cafe";
      string description = "Some description";
      Vendor newVendor = new Vendor(name, description);
      Vendor.ClearAll();

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      Vendor.ClearAll();
      string name01 = "Susie's Cafe";
      string description01 = "Description";
      string name02 = "Pete's bakery";
      string description02 = "Another description";
      Vendor newVendor1 = new Vendor(name01, description01);
      Vendor newVendor2 = new Vendor(name02, description02);

      //Act
      Vendor result = Vendor.Find(1);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void GetOrderList_ReturnsEmptyListOfOrders_EmptyList()
    {
        string name = "Suzie's cafe";
        string description = "Description";
        Vendor newVendor = new Vendor(name, description);
        
        List<Order> result = newVendor.GetOrderList();
        List<Order> orders = new List<Order> {};

        CollectionAssert.AreEqual(orders, result);
    }

    [TestMethod]
    public void AddOrder_AddsOrderToListOfOrders_CorrectListOfOrders()
    {
        string name = "Suzie's cafe";
        string description = "Description";
        Vendor newVendor = new Vendor(name, description);

        string title = "Order 1";
        string orderDescription = "Description of order 1";
        double price = 23.50;
        DateTime date = new DateTime(2020,01,10);
        Order order = new Order(title, orderDescription, price, date);
        
        newVendor.AddOrder(order);
        List<Order> result = newVendor.GetOrderList();
        List<Order> orders = new List<Order> {order};

        CollectionAssert.AreEqual(orders, result);
    }

    [TestMethod]
    public void Delete_DeletesVendorById_CorrectListOfVendors()
    {
        Vendor.ClearAll();
        string name01 = "Susie's Cafe";
        string description01 = "Description";
        string name02 = "Pete's bakery";
        string description02 = "Another description";
        Vendor newVendor1 = new Vendor(name01, description01);
        Vendor newVendor2 = new Vendor(name02, description02);

        Vendor.Delete(1);
        List<Vendor> vendors = Vendor.GetAll();

        Assert.AreEqual(1, vendors.Count);
    }

    [TestMethod]
    public void Delete_DeletesOrderById_CorrectListOfOrders()
    {
        Vendor.ClearAll();
        Order.Clear();
        string name = "Suzie's cafe";
        string description = "Description";
        Vendor newVendor = new Vendor(name, description);

        string title01 = "Order 1";
        string orderDescription01 = "Description of order 1";
        double price01 = 23.50;
        DateTime date01 = new DateTime(2020,01,10);
        Order order01 = new Order(title01, orderDescription01, price01, date01);
        newVendor.AddOrder(order01);
        string title02 = "Order 2";
        string orderDescription02 = "Description of order 2";
        double price02 = 13.50;
        DateTime date02 = new DateTime(2020,02,20);
        Order order02 = new Order(title02, orderDescription02, price02, date02);
        newVendor.AddOrder(order02);

        newVendor.DeleteOrder(1);
        List<Order> result = newVendor.GetOrderList();
        List<Order> orders = new List<Order> {order01};

        CollectionAssert.AreEqual(orders, result);
    }
    [TestMethod]
    public void Find_FindsOrderById_Order()
    {
        Vendor.ClearAll();
        Order.Clear();
        string name = "Suzie's cafe";
        string description = "Description";
        Vendor newVendor = new Vendor(name, description);

        string title01 = "Order 1";
        string orderDescription01 = "Description of order 1";
        double price01 = 23.50;
        DateTime date01 = new DateTime(2020,01,10);
        Order order01 = new Order(title01, orderDescription01, price01, date01);
        newVendor.AddOrder(order01);
        string title02 = "Order 2";
        string orderDescription02 = "Description of order 2";
        double price02 = 13.50;
        DateTime date02 = new DateTime(2020,02,20);
        Order order02 = new Order(title02, orderDescription02, price02, date02);
        newVendor.AddOrder(order02);

        Order result = newVendor.FindOrder(1);
        Order selectedOrder = order02;

        Assert.AreEqual(selectedOrder, result);
    }
  }
}