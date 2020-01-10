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
* Create a Vendor class. This class should include properties for the vendor's name, a description of the vendor, a List of Orders belonging to the vendor, and any other properties you would like to include.
* Create an Order class. This class should include properties for the title, the description, the price, the date, and any other properties you would like to include.
* The homepage of the app at the root path (localhost:5000/) should be a splash page welcoming Pierre and providing him with a link to a Vendors page.
* The vendors page should contain a link to a page presenting Pierre with a form he can fill out to create a new Vendor. After the form is submitted, the new Vendor object should be saved into a static List and Pierre should be routed back to the homepage.
* Pierre should be able to click a Vendor's name and go to a new page that will display all of that Vendor's orders.
* Pierre should be provided with a link to a page presenting him with a form to create a new Order for a particular Vendor. Hint: The route for this page might look something like: "/vendors/1/orders/new".

## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, HTML_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*