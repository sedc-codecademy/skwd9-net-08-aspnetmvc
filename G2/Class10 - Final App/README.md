# RECAP 🍉

## .NET/.NET Core vs ASP.NET/ASP.NET Core vs C# 🔹

- .NET is a framework that consists of different libraries as well as an environment to run our code called the Common Language Runtime. With this framework, we can build different projects like console apps, windows and web applications ( **only works on windows** machines ) as well as mobile apps
- .NET Core is also a framework that consists of libraries as well as an environment to run our code called Core Common Language Runtime. With this framework, we can build different projects like console apps, web applications and services on **Linux, Windows and Mac.**
- ASP.NET is a framework that also runs on the CLR and uses .NET libraries but is made specially to build and run web applications such as MVC ( web app with views ) as well as API ( web app with requests ) and Web Services. ( Windows Only )
- ASP.NET Core has almost the same properties as ASP.NET but it also works on linux, mac and windows
- C# is the language in which we can build all these applications that we mentioned.

## Design Patterns 🔹

Design patterns are just ideas and solutions to problems that have proven very good or efficient. Common problems such as making an application more organized, scalable and efficient can be solved with design patterns that are already used extensively in the industry.

## MVC 🔹

MVC is a design pattern. Its purpose is to make developing and building applications easier, more organized, more secure and scalable. It consists of dividing the logic into 3 parts:

- Model
- View
- Controller

We can build an ASP.NET web application and structure them using the MVC pattern. It has special project templates just for ASP.NET MVC applications which can be selected and started from Visual Studio

## Controller 🔹

Controllers are the systems that handle requests from the views and delegate them to the model. In ASP.NET controllers are classes. The methods that anticipate requests are called actions. These methods are called by the router ( a system that connects an address to an action ) when the user enters an address in their browser for example.

## View 🔹

Views are HTML web sites that are served to the user so the can see or interact with the data. Views in ASP.NET use an engine called RAZOR Engine that can be used to detect C# code in a view and generate HTML from it. To show things in a view we need to first send a model from the controller and then handle it from the view ( anticipate it by declaring what the view needs )

## Model 🔹

The model is a class that represents some data in some data structure, usually database. Models are used to transfer data from one place to another. There are different types of models for different uses. View models for example are models specially built to bring data to the views.

## Architecture 🔹

Software Architecture is a plan on how to organize and build an application. It is the foundation of a project. We need software architecture to better organize, structure and secure our application. Where we place our code, how we divide it and how it communicates is the main focus on software architecture.

## Multi-Layered Architecture 🔹

This type of architecture, also called N-Tier is dividing a project into multiple layers. Every layer is a group of code that serves some specific purpose. This means that the layers are divided by their responsibility. Three-tier architecture is the most common having 3 layers. They are:

- Data Access Layer - Layer where the models and methods for communication to the database stay. This layer can include:
  - Repositories
  - Context
  - Database configurations
  - Domain Models
- Business Layer - Layer where all the business logic and code goes. Everything that is logic and is connected to our application goes here. This layer can communicate with the Data Access Layer and request things from it. This layer can include:
  - Service Classes ( Services )
  - Helper Classes ( Helpers )
  - Mappers
  - Configurations
  - DTO ( data transfer objects )
  - DI Modules
- Presentation Layer - This layer is for the users of the application. Everything that they can see or interact with is in this layer. This layer can only communicate with the business layer, meaning that it requests things from it when it needs it. The service then asks the data access and waits for a response. The response is then returned to the presentation layer which shows it to the user. This layer can include:
  - Views
  - Controllers
  - View Models
  - Startup configurations
  - Router
  - DI configurations

## Repository Pattern 🔹

Repository pattern is a design pattern that organizes communication with a data structure ( usually database ) in a very nice and structured way. Repository is basically a class that contains methods for communicating with the database. Repositories are usually connected to a domain model and address the manipulating the database for that model or entity. Every time a service from the Business layer needs data, it can call a repository for the entity that it needs and the repository will make the call and return the data needed.

## Dependency Injection 🔹

Dependency injection is a technique that tends to decouple or resolve the problem with too many dependencies by abstracting the instances of classes so that they can be inserted or injected later by some system ( usually dependency injection container ) itself. ASP.NET Core has it's own dependency injection container that comes with web application templates. We register our classes and interfaces for this system and then it can create instances for us every time we request for some interface implementation.

## Entity Framework ( ORM ) 🔹

Object-relational mapping is the process of creating a link between two systems that can't otherwise communicate with each other. In ASP.NET applications case, SQL can't communicate easily with our application. There is a framework called ADO.NET that does this but it is too slow and hard developing in it. Entity framework is an ORM that bridges the gap between our application and the database. It does so by using a class called context, which is a representation of the database in the code and through which the application can do all operations on the database in a familiar way ( C# ). The context and the database should always be the same. If there are any changes in the context or the models, the database needs to be updated accordingly. This can be done through migrations, which are change request documents for the database tha map all the changes from the code.
