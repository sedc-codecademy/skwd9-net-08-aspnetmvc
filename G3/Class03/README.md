# Models 🍦

In order for one application to be dynamic it needs to show and change data constantly depending on the users needs. This brings a need for data management and manipulation. That is why the concept of the model is created and why it's really important for the MVC pattern. The **Model** is basically an _entity that keeps data that is ready for use and change if necessary_. Another key point about the Model is that it must be within the business logic and domain of the application. This means that the business logic dictates how the model will be structured as well as how many models do we need to create. In ASP.NET Core MVC applications where we use C# as our language of choice, models are represented by a class. So if we create a class with properties, that is actually the model, and the properties are the data storage units. If this model was mapped to a data structure such as a database the class would be a table and the properties columns. The main models that contain our logic, often called Domain or Core models stay in a separate place, usually in a separated project or in a separate folder.

```csharp
public class Order
{
	public int Id { get; set; }
	public User User { get; set; }
	public string Pizza { get; set; }
	public double Price { get; set; }
}
```

```csharp
public class User
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Address { get; set; }
	public long Phone { get; set; }
}
```

## Sending a model to view 🔹

Models are basically classes and objects created from those classes hold our data in them as properties. We can send these models to our views and with that send data to the view. We can only send one model to any one particular view at a time.

### Sending ( Controller )

In order to send a model to a view we create an object from the class representing our model or get an object from somewhere else. Then we add it to the View result as a parameter. The view result can only pass one model. To get around this and pass multiple models we can either create a list of models or create a view model.

```csharp
public IActionResult Index()
{
	User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
	Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };
	return View(order);
}
```

### Intercepting ( View )

In order to intercept the model in our view we need to first add a line of code that indicates that the view is expecting some kind of model and add the type of the model that we are expecting. After the model is sent from a controller and added to a view we can use it by typing @Model and using it as the object that we are expecting.

```csharp.cshtml
// We write the whole namespace to our model ( class )
@model Sedc.App.Models.DomainModels.Order
...
<h1> Order </h1>
<ul>
	<li>Name: @Model.User.FirstName</li>
	<li>Name: @Model.Pizza</li>
	<li>Name: @Model.Price</li>
</ul>
```

## Sending data to view without model 🔹

Usually when we work with the MVC pattern we tend to send model from a controller to the view with all the information that we need. But there are a few entities that can send data to the view as well separately from the model. These are ViewBag and ViewData. Both of them are their own entity and can be used separately from the model and them selves. ViewBag and ViewData are not to be used as a replacement or in place of the models. They are only another way to pass a value besides the model it self which is the main source of logic to our view.

### ViewData

**ViewData** is a _special Dictionary that can be accessed in the controller as well as the view_. There is no need for prior configuration, it just exists in both places. ViewData works the same as a dictionary and we can add items as a key value pair and use methods and properties that a normal dictionary uses such as Count, Keys, Values etc. One important thing to mention is that the key part of the ViewData dictionary must always be a string. The value can be whatever we choose since it is of type object.

```csharp
// Controller
public IActionResult Index()
{
	User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
	Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };
	ViewData.Add("Title", "Home Page");
	ViewData.Add("Order", order);
	return View();
}
```

```csharp.cshtml
// View
<h1>@ViewData["Title"]</h1> // Will show up in our view
<ul>
	// Will break on build time
	<li>Name: @ViewData["Order"].User.FirstName</li>
	<li>Pizza: @ViewData["Order"].Pizza</li>
	<li>Price: @ViewData["Order"].Price</li>
<ul>
```

### ViewBag

**ViewBag** is a _new and dynamic version of the ViewData object_. ViewBag lets you dynamically add values and those values as properties and access them in the view. Unlike the ViewData object, if we add an object from a class as a value, we can access it's properties in the view ( We don't have intellisense in the view ). If we do not access the correct name of a property we will get a runtime error.

```csharp
// Controller
public IActionResult Index()
{
	User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
	Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };
	ViewBag.Title = "Home Page";
	ViewBag.Order = order;
	return View();
}
```

```csharp.cshtml
// View
<h1>@ViewBag.Title</h1> // Will show up in our view
<ul>
	// Will show up in our view
	<li>Name: @ViewBag.Order.User.FirstName</li>
	<li>Pizza: @ViewBag.Order.Pizza</li>
	<li>Price: @ViewBag.Order.Price</li>
	<li>Delivery: @ViewBag.Order.Delivery</li> // Will break at runtime
<ul>
```

## Other types of models 🔹

In an MVC application we can find different types of models depending on the architecture and patterns that we use to organize the code. These models all exist for a particular purpose, either to abstract some data, transfer or bundle some data together. When multiple types of models exist in an application, the data is mapped from one type to the other so that it can flow through the application. The mapping can be done manually, just making a new model and initializing it to the values of some other model, or a library for mapping called a mapper can be used.

### View Model

When creating models, we design them to fit the business logic of the application that we are building. This is great, but a view can only accept one model and some times we need data from two different models to show up in one view, or we just want a few properties from a particular model. This is why **View Models** exist. View models are _classes that contain all the information that one view needs_. This means that this class can have properties from multiple models or part of one model, tailored to the view needs. This View Model is only used for the view and nothing else. The data first comes in the multiple domain models ( core, main models ) and then we map it to the view model to create a specific set of data needed for a view. After we are done with the view, the data is sent back as a view model and that view model is mapped back in to the domain models so they can go back to our application. We must always mark down our view models by writing ViewModel at the end of the model name.

```csharp
// A view model
public class OrderDetailsViewModel
{
	public int Id { get; set; }
	public string FullName { get; set; }
	public string Address { get; set; }
	public long Contact { get; set; }
	public string Pizza { get; set; }
	public double Price { get; set; }
}
```

```csharp
// The domain models
User person = new User() { FirstName = "Bob", LastName = "Bobsky", Address = "Bob Street", Phone = 0800234234 };
Order order = new Order(){ Id = 12, User = person, Pizza = "Kapri", Price = 10.5 };

// Creating and mapping the view model manually
OrderDetailsViewModel orderDetails = new OrderDetailsViewModel()
{
	Id = order.Id,
	FullName = $"{person.FirstName} {person.LastNAme}",
	Address = person.Address,
	Contact = person.Phone,
	Pizza = order.Pizza,
	Price = order.Price
}
```

## Extra Materials 📘

- [When to use ViewBag and ViewData](https://rachelappel.com/2014/01/02/when-to-use-viewbag-viewdata-or-tempdata-in-asp-net-mvc-3-applications/)
- [Model and ViewModel](https://www.tektutorialshub.com/asp-net-core/asp-net-core-model-and-viewmodel/)
- [Passing data from controller to view](https://www.tektutorialshub.com/asp-net-core/asp-net-core-passing-data-from-controller-to-view/)
