# Building Web Applications 🎂
## Building vs Coding 🔹
Web applications are built by writing code. But writing code is not the same as building the web application. The code is just a tool for building our application. The building part is much more than just coding. It's thinking about the product now and the future. It's organizing and structuring all the parts. It's dividing the user from the sensitive data. It's thinking about the ease of implementation of new features. Basically, when we build an application we make a whole plan to build a complex system of ideas and practices that will be easy to use, make changes fast, be secure and stand the test of time. For this reason, there are a lot of concepts, ideas and practices that exist and that we can implement and use to build a good application

## Architecture 🔹
The way we build, organize and structure a software application is called Architecture. We build software by using some sort of organization and with that some architecture. This means that the code needs to be divided into multiple projects, files and folders. These must be created with some logic in mind and be connected in a certain way to follow the rules of the architecture that we are trying to implement. There are already types of architectures that exist and that have proven successful in the industry. 
### Multi-Tier ( N-Tier ) Architecture 
Multi-tier architecture is a system of structuring an application into layers or logic groups. These layers keep code that is similar and does a similar job usually in a different project inside our solution. It is called multi-tier or N tier because N stands for a number of layers. This means that we can have 2-Tier, 3-Tier, 4-Tier applications, depending on how we divide our application. Some times a tier can have multiple projects that have the same logic inside them if that makes it easier for us to connect or to organize the code.
#### 3-Tier
3-Tier architecture is one of the most common. It  divides our code on to 3 fundamental parts: 
* Data Access Layer - A layer that has everything to communicate and connect to the database. This layer is the only layer that communicates to the database. It houses the models, the systems for communication as well as the methods for reading or writing to the database. ( Class Library )
* Business Logic Layer - A layer that has all the business logic that we need for our application. In this layer, we write all the code that is connected to our application business logic and this is the only layer that can access and request stuff from the Data Access Layer. After it processes the information from the Data Access Layer it sends them to the presentation layer. ( Class Library )
* Presentation Layer - The presentation layer is the layer that the users interact with. This layer is basically the application that we are building, the views, styles and scripts. This layer does not host any business logic or database access methods. It just worries about how the user interacts with the application. If the presentation layer needs anything, it asks from the Business Layer which can make a call if it needs to the Data Access Layer that can get something from the database.  ( Web Application, ASP.NET )

#### Diagram
![Architecture Diagram](https://github.com/sedc-codecademy/sedc7-08-aspnetmvc/blob/master/g5/Class%206/img/Architecture.png?raw=true)

#### ASP.NET Web Application Example
![Architecture Example](https://github.com/sedc-codecademy/sedc7-08-aspnetmvc/blob/master/g5/Class%206/img/ntier.PNG?raw=true)
## Patterns 🔹
Design patterns were ideas or solutions to some problems that we can reuse to solve some kind of problem. These patterns are present in software development as well as the design phase. We can use patterns like these to build better and scalable applications. 
### Repository Pattern 
The repository pattern is a solution to the problems with organization to the methods that connect to the database. The pattern is simple, we create a class or multiple classes that we call *Entity*Repository or just Repository depending in the data access layer usually ( if we are using 3-tier architecture ) and in that class or classes we put the CRUD ( Create, Read, Update, Delete ) operation that we need in order to manipulate with the database. This gives us multiple advantages. By having the methods in one class it is easier to find and access a method. It is also easier to use some external class, address or library since all the methods are in one place and can use the same fields in the class. This also makes all the methods divided from the other methods that are not accessing directly to the database. It is just an abstraction for our database manipulation methods.
```csharp
// Generic repository with the basic CRUD methods
public interface IRepository<T>
{
	T GetById(int id);
	List<T> GetAll();
	void Insert(T entity);
	void Update(T entity);
	void DeleteById(int id);
}

// Repository
public class OrderRepository : IRepository<Order>
{
	public void DeleteById(int id)
	{
	    Order order = Db.Orders.FirstOrDefault(x => x.Id == id);
	    if (order != null) Db.Orders.Remove(order);
	}

	public List<Order> GetAll()
	{
	    return Db.Orders;
	}

	public Order GetById(int id)
	{
	    return Db.Orders.FirstOrDefault(x => x.Id == id);
	}

	public void Insert(Order entity)
	{
	    Db.OrderId++;
	    entity.Id = Db.OrderId;
	    Db.Orders.Add(entity);
	}

	public void Update(Order entity)
	{
	    Order order = Db.Orders.FirstOrDefault(x => x.Id == entity.Id);
	    if (order != null)
	    {
		int index = Db.Orders.IndexOf(order);
		Db.Orders[index] = entity;
	    }
	}
}
```
## Interfaces 🔹
Interfaces are a key part of creating a good and scalable application. We use them to set some rule-set over our classes, but most importantly we use them as an abstraction to using service classes. Service classes unlike entity classes need only one instance and that instance is usually always the same. That is why we can make an abstraction and just wait for an instance to be built instead of creating it on our own. We can do this with Dependency Injection technique.

### Dependency Injection 
Dependency injection is a technique where we delegate our dependencies ( classes that we need, usually service classes ) to come from the outside instead of resolving them ( create instances ). This can be done through interfaces and containers. Containers are systems that create instances of classes for us. To do this we register the class that we want to be created with an interface. The next time we request for an interface in a class constructor, the container detects this and creates an instance of that dependency for us. Think of it as requesting something that matches an interface and getting it from outside, without making any instances or writing code. 

#### Service class
```csharp
// Class must inherit from an interface
public interface IUserService
{
	List<User> GetAllUsers();
	User GetUserById(int id);
}

public class UserService : IUserService
{
	public List<User> GetAllUsers()
	{
		return Db.Users;
	}
	public User GetUserById(int id)
	{
		return Db.Users.FirstOrDefault(x => x.Id == id);
	}
}
```
### With container 
#### In Startup.cs ( Configuring the container )
```csharp
// Here we register what class will be created when asked for an interface implementation
public void ConfigureServices(IServiceCollection services)
{
	//... some code
	
    services.AddTransient<IUserService, UserService>();
	
	//... some code
}
```
#### In controller  ( Using the service )
```csharp
public class HomeController : Controller
{
	private IUserService _userService;
	public HomeController(IUserService userService)
	{
		_userService = userService;
	}

	public IActionResult Users()
	{
		List<User> users = _userService.GetAll();
		return View(users);
	}
}
```
### Without Container 
#### In controller  ( Using the service )
```csharp
public class HomeController : Controller
{
	private IUserService _userService;
	public HomeController()
	{
		_userService = new UserService();
	}

	public IActionResult Users()
	{
		List<User> users = _userService.GetAll();
		return View(users);
	}
}
```

## Extra Materials 📘
* [N-Tier architecture explanation](https://www.guru99.com/n-tier-architecture-system-concepts-tips.html)
* [Dependency Injection explained simple ( With drawing )](https://www.youtube.com/watch?v=IKD2-MAkXyQ)
* [Repository Design Pattern in C#](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/)
