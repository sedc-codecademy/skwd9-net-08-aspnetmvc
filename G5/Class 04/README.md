# Views part 1 🍰

The views in ASP.NET MVC are the main and only interface from which a user can interact with the application. Views in ASP.NET are basically HTML pages with an integrated engine that helps manipulate, integrate and bind the view and it's contents with the back-end part of the application using C# code. This is why the extension to the views is cshtml. Views are always added in the Views folder of the ASP.NET application, views for certain controllers are added in a folder with the controller name ( without controller ) and views that are shared between multiple controllers and actions are added in a folder named Shared. The application can easily find it's way to the views if they are properly named and in the correctly positioned and named folder.

## Razor Engine 🔹

The Razor View Engine is the engine that allows us to write C# in our HTML page directly and help us build and connect pages to the back-end of our application quickly and easily. The Razor View Engine has a lot of features. To access the Razor syntax we use the @ sign. We can access that way

### Using C# in an HTML View

To use C# in a view all we have to do is place an @ sign. After the @ sign we can write c# code. The code can be written in one line, multiple lines ( block of code ) and can be mixed back and forward between HTML and C# depending on the logic.

- @code - for executing C# values and methods
- @(code) - for adding expressions result directly to html
- @{code} - for executing multiple lines of c# code ( block )
- @using - for referencing some import

With this, we can write if statements, for statements and almost all features C# covers in the view with the HTML interchangeably. This feature allows us to build dynamic and complex views with C# logic.

> Note that Razor generates an HTML view from the CSHTML file. C# does not render on the client machine it self

#### One line value

```csharp cshtml
@using SEDC.PizzApp.Models
@model Order

<h2>Order:</h2>
<ul>
    <li>@Model.Id</li>
    <li>@Model.Name</li>
    <li>@Model.Pizza</li>
    <li>@Model.Price</li>
</ul>
<h4>Time:</h4>
<p>@DateTime.Now</p>
```

#### One line expression

```csharp cshtml
@using SEDC.PizzApp.Models
@model Order

<h2>Order:</h2>
<ul>
    <li>Id: @Model.Id</li>
    <li>Name: @("Mr./Ms. " + Model.Name)</li>
    <li>Pizza: @Model.Pizza</li>
    <li>Price + Delivery: @(Model.Price + 40)</li>
</ul>

<h4>Time:</h4>
<p>@DateTime.Now</p>
```

#### Block of code

```csharp cshtml
@using SEDC.PizzApp.Models
@model Order
@{
    string status = "Not yet delivered";
    if(Model.Delivered)
    {
        status = "Delivered!";
    }
}
<h2>Order:</h2>
<ul>
    <li>Id: @Model.Id</li>
    <li>Name: @("Mr./Ms. " + Model.Name)</li>
    <li>Pizza: @Model.Pizza</li>
    <li>Price + Delivery: @(Model.Price + 40)</li>
    <li>Status: @status</li>
</ul>

<h4>Time:</h4>
<p>@DateTime.Now</p>
```

#### If statement in a View

```csharp cshtml
@if (!Model.Delivered)
{
    <p>Your delivery is on the way! For long delays contact: 070123456</p>
}
```

#### For loop in a View

```csharp cshtml
@using SEDC.PizzApp.Models
@model List<Order>
<h2>Orders:</h2>
@for (int i = 0; i < Model.Count; i++)
{
    <h4>Order no @i</h4>
    <ul>
        <li>Id: @Model[i].Id</li>
        <li>Name: @("Mr./Ms. " + Model[i].Name)</li>
        <li>Pizza: @Model[i].Pizza</li>
        <li>Price + Delivery: @(Model[i].Price + 40)</li>
        <li>Status: @Model[i].Delivered</li>
    </ul>
}
```

## Types of Views 🔹

Besides the standard views in the ASP.NET MVC projects, there are special types of views that are automatically
ed by the framework if they are present. These views have some specific features and use in the application. The framework detects these views by their name and by their position in the folder structure of the project. Special views that affect all the views no matter what or where they are placed directly in the Views folder. The views that need to be used or imported, but that can be shared by multiple views if they are imported must be stored in a folder inside the Views folder called Shared. Views that are not intended to be accessed directly are written with an **\_** before the name.

### Layout

A layout view is exactly what the name suggests, a view that is basically the layout of the page. The layout can be used by views and this makes all views have the same layout, but the contents of the page change. The benefits of having one layout are huge. There is only one code for the layout, meaning that if you change something about the layout all the views get the change. It also simplifies the boilerplate HTML code like the head, body, title as well as imports such as CSS and scripts. This makes the views much cleaner and simpler. Layout views are added in the Shared folder and are marked by an **\_** before the name. To position the view that will go in the layout, @RenderBody is used. Whenever that is used, that place is where the code from the view generating will go.

#### In the \_Layout.cshtml

```csharp cshtml
<!DOCTYPE html>
<html>
<head>
	// Whatever title is passed to ViewBag, it will render here, in the Layout
    <title>@ViewBag.Title - PizzaApp</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <div class="container body-content">
	    // On the line where @RenderBody() is will be the view that we open
        @RenderBody()
        <hr />
        <footer>
            <p>&copy;PizzaApp</p>
        </footer>
    </div>
    <script src="~/lib/jquery/dist/jquery.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.js"></script>
    <script src="~/js/site.js"></script>
</body>
</html>
```

#### In the view

```csharp cshtml
@{
ViewBag.Title  =  "Home"; // Changing the ViewBag.Title (shows in the layout)
Layout  =  "~/Views/Shared/_Layout.cshtml"; // Using the layout to this view
}
```

### ViewStart and ViewImports

ViewStart and ViewImports are views that affect all the views that we create in our ASP.NET application. They are not imported or used. If the framework finds them it uses them automatically. They are placed directly in the Views folder. Both of these views start with an **\_** before their names.

#### ViewStart

When we want to use the same code in every view that we create we use the ViewStart view. In it, we can write some code and the razor engine will execute that code upon every loading of any view. Usually, in this view we write code that is repeating on every view such as adding a layout.

```csharp cshtml
@{
	// setting the layout for all the views
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```

#### ViewImports

As by the name, ViewImports is a view where we store all our imports for every view that we create. This is a view where we usually write using statements that we need in all of our views. For instance, if we need a using statement to our models we create a using statement in the ViewImports to the folder Models so that we don't have to write the whole namespace when importing models in our views.

```csharp cshtml
using SEDC.PizzApp.Models
```

### Partial

Partial views are basically view within a view. If a component in our application is repeating or if it is changing in multiple places we can use a partial view. This means that we can create a view with HTML that is only for that feature or component. After that, we can import it in our view once or multiple times with different data depending on the case. Partial views usually have an **\_** before their name as a convention, to indicate that they can be used multiple times and that they must not be used by themselves. Partial views can also require a Model and we can also pass data to a partial view just like a normal one. Since the partial view is used from another view, that parent view must have the needed data and pass it to the partial in order for the partial to have its data.

#### Partial view called \_OrderItem

```csharp cshtml
// This view is stored in the Shared folder
// It can also accept a Model and use it
@model Order
@{
    string status = "Not delivered yet";
    if (Model.Delivered)
    {
        status = "Delivered";
    }
}
<h4>Order no. @Model.Id</h4>
<ul>
    <li>Name: @("Mr./Ms. " + Model.Name)</li>
    <li>Pizza: @Model.Pizza</li>
    <li>Price + Delivery: @(Model.Price + 40)</li>
    <li>Status: @status</li>
</ul>
```

#### Parent view that uses the partial view \_OrderItem

```csharp cshtml
// This is the view that uses the partial view
// The data must be passed from this view to the partial
@using SEDC.PizzApp.Models
@model List<Order>
<h2>Orders:</h2>
@for (int i = 0; i < Model.Count; i++)
{
	// Here we add the relative path as well as the data required
    @Html.Partial("~/Views/Shared/_OrderItem.cshtml", Model[i])
}
```

### Other shared Views

We can create our own shared views if we need them. All views that can be used multiple times on different places and occasions are added in the Shared folder. These views can then be accessed whenever we need them. Usually, these views are connected to some general that all view have in common such as an Error or a Thank You page.

## Extra Materials 📘

- TutorialsPoint Articles on Views
  - [Layout](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_layout_views.htm)
  - [ViewStart](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_start.htm)
  - [ViewImport](https://www.tutorialspoint.com/asp.net_core/asp.net_core_razor_view_import.htm)
- [Microsoft on Partial Views](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-2.1)
- [Quick Reference to Razor Syntax](https://haacked.com/archive/2011/01/06/razor-syntax-quick-reference.aspx/)
