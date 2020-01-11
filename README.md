# _Pierre's Vendor and Order Tracker_

#### _Version 01/10/2020_

#### By _**Nina Potrebich**_

## Description

_An MVC application to help Pierre track the vendors that purchase baked goods from Pierre's bakery and the orders belonging to those vendors._

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET

### Installing

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Using console of your choice build and run program in Project directory:
```
dotnet run
```
3. For Unit testing run tests in Project.Tests repository:
```
dotnet test
``` 

## Specifications:
* Project has a Vendor class. This class include properties for the vendor's name, a description of the vendor, a List of Orders belonging to the vendor.
* Project has an Order class. This class include properties for the title, the description, the price, the date.
* The homepage of the app at the root path (localhost:5000/) is a splash page welcoming user and providing him with a link to a Vendors page.
* The vendors page(localhost:5000/vendors) contain a link to a page presenting user with a form user can fill out to create a new Vendor(localhost:5000/vendors/new). After the form is submitted, the new Vendor object is saved into a static List and user is routed back to the vendors page (localhost:5000/vendors).
* User is be able to click a Vendor's name and go to a new page (localhost:5000/vendors/{vendorId}) that will display all information about that Vendor. This page also include link to orders of this Vendor(localhost:5000/vendor/{vendorId}/orders).
* User is provided with a link to a page (localhost:5000/vendors/{vendorId}/orders/new) presenting them with a form to create a new Order for a particular Vendor.
* User is able to click on Order's name and go to a new page (localhost:5000/vendors/{vendorId}/orders/{orderId}) that will display all information about that Order. 
* User is able to delete a specific Vendor from vendor page(localhost:5000/vendors/{vendorId}). They will be redirected to confirmation of deletion page (localhost:5000/vendor/{vendorId}/delete).
* User is able to delete all vendors from vendors page(localhost:5000/vendors). They will be redirected to confirmation of deletion page (localhost:5000/vendors/delete).
* User is able to delete a specific Order from Order page(localhost:5000/vendors/{vendorId}/orders/{orderId}). They will be redirected to confirmation of deletion page (localhost:5000/vendor/{vendorId}/orders/{ordersId}/delete).
* User is able to delete all orders from orders page(localhost:5000/vendors/{vendorId}/orders/). They will be redirected to confirmation of deletion page (localhost:5000/vendors/{vendorId}/orders/delete).
* User is able to update information about Vendor.
* User is able to update information about Order.

## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, HTML, Bootstrap_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*