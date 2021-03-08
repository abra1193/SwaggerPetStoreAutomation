
# Swagger PetStore automation tests

# Test Approach

The tests were created with a functional testing approach,on every test run some checks and validation are done with certain inputs to verify that data is inserted,displayed,updated and deleted correctly.

# Project Solution

This project is divided in one class library(SwaggerPetStoreAutomationAPI) where are located Actions(Endpoint raw call and responses),Controller(Rest client and Rest Request),Entities(Json converted to Objects),
Handlers(Json Serialize and Parse),JsonModels(Json Models for each api entity) and Resources(miscellaneous files to test file uplad on endpoints) folders and in one test class(SwaggerPetStoreAutomationTests) where are located BaseTests(Base Class and log helper),Test(Test to be executed in this project) and TestSharedSteps(Object initialization and endpoint calls abstracted on methods) folders,each of this folders 
represent an abstraction layer.

This type of solution was used for better code reusability,maintainability of the testing framework.


# Framework / Libraries / Tech Stack 

* C#
* .NET Core
* RestSharp
* XUnit

This project is developed using C# with .NET Core,XUnit as the testing framework and RestSharp as my .NET client for the APIs.

I decided to utilize C# along with Restsharp because this library it's one of the best and easy to use libraries to handle REST api in .NET,it allows you to serialize/deserialize Json as Objects easily and also RestSharp support all the HTTP methods(GET, PUT, HEAD, POST, DELETE and OPTIONS).

I also utilize .NET Core so this project can have the Ability to run on Windows, macOS, and Linux and Xunit since this is one of the .NET Frameworks that is far more flexible and extensible than others .Net Unit test frameworks.

# Scenarios covered on the solution

**The following scenarios are cover by the automation test suite:**

*  **Verify Order Status are updated on the Pet Inventory endpoint(OrderTests.cs).**

*  **Verify Order can be created/Updated/Deleted(OrderTests.cs).**
  
* **Verify pets can be created/Updated/Deleted(PetsTests.cs).**

* **Verify pets can be search by status(available,pending and sold)(PetsTests.cs).**
  
* **Verify pets can be search by different tags(PetsTests.cs).**

* **Verify images can be uploaded to pet entities(PetsTests.cs).**

* **Verify users can logIn/logOut(UserTests.cs).**

* **Verify users can be created(UserTests.cs).**

* **Verify users can be created/Updated/Deleted(UserTests.cs).**

# How to execute the tests

### Windows/Mac/Linux CLI test execution ###

Step 1:

Install .NET Core SDK on your machine

Follow instructions [here](https://dotnet.microsoft.com/download)

## How to execute the tests cases via CLI


1. Clone/Download the project from this github repository to a path in your machine

2. Navigate to the project folder **abraham-mejia** using your OS CLI

3. For execute the test suite,run the following command on the terminal:

    `dotnet test`


### Windows/Mac Visual Studio test execution ###

Step 1:

Install Visual Studio Comunnity on your machine

Follow instructions [here](https://visualstudio.microsoft.com/downloads/)

## How to execute the tests cases via Visual Studio


1. Clone/Download the project from this github repository to a path in your machine

2. Open Visual Studio and Click on Open A project or Solution/Clone or checkout Code 

3. Wait for the solution to download all dependencies and the test explorer to discover all test

4. Navigate to Test Explorer and hit left click inside the test solution and hit run.