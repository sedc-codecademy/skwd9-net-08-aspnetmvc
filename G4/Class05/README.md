# Views part 2 🍰

## Helpers 🔹

ASP.NET Core gives as multiple systems for generating dynamic HTML code. There are Helpers for almost everything such as generic links to other routes, binding labels to our model, binding input fields to our model, creating forms with submit functionality to the right address etc. Main helper systems are:

- HTML Helpers
  - HTML Helpers are helper methods from the razor engine that we can call with a few parameters
  - After calling these methods, they generate HTML code tailored to the data passed as a parameter
  - With these methods we can do almost anything in our HTML view within a function call
- Tag Helpers
  - A unique feature to the ASP.NET Core framework
  - Dynamic HTML tags that contain C# data and bindings
  - Have almost the same features as the HTML helpers in a different format
  - Tag helpers are enabled by having the ` @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers` in the ViewImports view

### Links

The link HTML helper is a helper that lets us create links to our routes in our MVC application by adding our action and even controller name as parameters. The razor engine will generate an HTML element that represents link and that in the attributes has the right address to the action in question.

##### Razor View ( HTML Helper )

```csharp cshtml
// Calling an action in the same controller
@Html.ActionLink("Back To Home", "Index")
// Calling an action in a different controller and action
@Html.ActionLink("Back to Home","Index","Home")
// Calling an action with parameters
@Html.ActionLink("To First Item", "Order", "Orders", new { id = 0 })
```

##### Razor View ( Tag Helper )

```csharp cshtml
// Calling an action from a controller
<a asp-controller="Home" asp-action="Index">Back to Home</a>
// Calling an action with parameters
<a asp-controller="Orders" asp-action="Order" asp-route-id="0">Order no. 0</a>
```

##### When rendered in HTML

```html
<!-- Without parameter examples -->
<a href="/Orders">Back To Home</a>
<!-- With parameter examples -->
<a href="/Orders/Order/0">To First Item</a>
```

### Display

For displaying things from the model we can also use Html Helpers. The display HTML helper lets us display a string in our views by requesting the name as a string ( loosely typed ) or requesting it by a lambda ( strongly typed )

##### Razor View ( HTML Helper )

```csharp cshtml
// Displaying a property of the Model passed loosely typed
@Html.Display("Name")
// Displaying a property of the Model passed strongly typed
@Html.DisplayFor(x => x.Name)
```

##### When rendered in HTML

```html
<!-- Only text is printed -->
Bob Bobsky
```

### Label

When adding a label for a property we use the Label HTML helper. This helper creates a label html tag with the content of the name of the property. Unlike Display HTML Helper this helper creates a HTML element. The default value will always be the name of the property, but this can be changed by adding an annotation to the properties in the class.

##### Razor View ( HTML Helper )

```csharp cshtml
// Displaying a property name loosely typed
@Html.Label("Name")
// Displaying a property name strongly typed
@Html.LabelFor(x => x.Name)
```

##### Razor View ( Tag Helper )

```csharp cshtml
// Displaying a property name
<label asp-for="Email"></label>
```

##### When rendered in HTML

```html
<label for="Name">Name</label>
```

### TextBox

The TextBox helper is the helper for creating and binding input fields with values. This helper is used when we want to create an input and the value that will be added in that input to be bound to some property of the model. This helper creates an input parameter with all the attributes automatically to bind the property that was added. This means that if that property has a value at the start of the page, that value will be written in the input field. If the input field is changed and the data is posted back to the back-end the value of that property will also be changed.

##### Razor View ( HTML Helper )

```csharp cshtml
// Creating an input for a property loosely typed
@Html.TextBox("Name")
// Creating an input for a property strongly typed
@Html.TextBoxFor(x => x.Name)
```

##### Razor View ( Tag Helper )

```csharp cshtml
// Creating an input for a property loosely typed
<input asp-for="Name" />
```

##### When rendered in HTML

```html
<!-- If there is a value for the property -->
<input id="Name" name="Name" type="text" value="Bob Bobsky" />
<!-- If there is no value for the property -->
<input id="Name" name="Name" type="text" value="" />
```

### DropDownList

Drop down lists can also be created with a HTML Helper. There are two ways of creating a drop down list. The hard way is to create a SelectList with SelectListItems ( like a dictionary with the values and keys for the drop down ) and send that to the view. The easier way is to just send an enum to the view and all the values from the enum will be generated with the html helper.

##### Razor View ( HTML Helper )

```csharp cshtml
// Creating a dropdown for all the values of the enum and mapping it to a property
@Html.DropDownListFor(x => x.Size, Html.GetEnumSelectList(Model.Size.GetType()))
// Creating a dropdown for all the values of the enum and mapping it to a property with a starting choice/label
@Html.DropDownListFor(x => x.Size, Html.GetEnumSelectList(Model.Size.GetType()), "Select a pizza")
```

##### Razor View ( Tag Helper )

```csharp cshtml
// Creating a dropdown for all the values of the enum and mapping it to a property
<select asp-for="Size" asp-items="Html.GetEnumSelectList<PizzaSize>()">
</select>
// Creating a dropdown for all the values of the enum and mapping it to a property with a starting choice/label
<select asp-for="Size" asp-items="Html.GetEnumSelectList<PizzaSize>()">
	<option value="">Select a pizza</option>
</select>
```

##### When rendered in HTML

```html
<!-- Values are what maps the value clicked back to an enum -->
<select id="Size" name="Size">
  <option value="1">Medium</option>
  <option value="2">Large</option>
  <option value="3">Family</option>
</select>

<!-- Example 2 -->
<select id="Size" name="Size">
  <option value="">Select a pizza</option>
  <option value="1">Medium</option>
  <option value="2">Large</option>
  <option value="3">Family</option>
</select>
```

### HiddenField

The hidden field helper is used a lot and it's main objective is to send data that the user does not need to see on the screen. Since the back-end does not know from where the model came from, we must send data to identify models that we send to views. The properties that we send for identifying the model later are stored in these hidden fields. Data like this is an Id of some object or some status that we need to keep and send back to the back-end application with the model. Hidden fields is basically an input that is not displayed.

##### Razor View ( HTML Helper )

```csharp cshtml
// Creating an input field that is hidden for a property loosely typed
@Html.Hidden("Id")
// Creating an input field that is hidden for a property strongly typed
@Html.HiddenFor(x => x.Id)
```

##### Razor View ( Tag Helper )

```csharp cshtml
// Creating an input field that is hidden for a property
<input type="hidden" asp-for="Id" />
```

##### When rendered in HTML

```html
<!-- Will not show for the user. No need for extra css or js -->
<input id="FirstName" name="FirstName" type="hidden" value="Dragan" />
```

## Forms 🔹

In order to send some data back to the back-end we need to add all our data into a form. Basically all the TextBoxes that are bound to some properties need to be in a form so we can send them back. There is an HTML helper for a form that automatically knows which path to post to and detects the inputs that are bound with the model. When using this helper we just write TextBoxes in it that are bound to the model properties and a submit button or input. The rest is already set by the helper. The helper posts back to an action in the current controller that has the same name as the action that called the view and has the [HttpPost] attribute

#### With Helper

##### Razor View ( HTML Helper )

```csharp cshtml
@using(Html.BeginForm())
{
	@Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
    <br/>
    <button type="submit"> Submit </button>
}
```

##### Razor View ( Tag Helper )

```csharp cshtml
<form asp-controller="Order" asp-action="Order" method="post">
    <label asp-for="FirstName"></label>
    <input asp-for="FirstName" />
    <br/>
    <label asp-for="LastName"></label>
    <input asp-for="LastName" />
    <br/>
    <button type="submit"> Submit </button>
</form>
```

##### When rendered in HTML

```html
<form action="/order/order" method="post">
  <label for="FirstName">First Name</label>
  <input id="FirstName" name="FirstName" type="text" value="Dragan" />
  <br />
  <label for="LastName">Last Name</label>
  <input id="LastName" name="LastName" type="text" value="" />
  <br />
  <button type="submit">Submit</button>
</form>
```

## Model attributes 🔹

In the model we can decorate the properties with attributes to get an extra layer of data for our properties. This means that we can add some extra significance to the properties and the razor engine will treat them differently or add some extra data when necessary. These attributes are added above the properties and can be used for validating, displaying different names and pointing out how to be mapped in a database.

### Display attribute

The display attribute basically changes the name of the property so that every time the name of the property is used, instead of the code name ( Ex. FirstName ) we get a different name ( Ex. First name of user ). This helps us when putting labels for our properties. If we decorate our properties with a Display property the label will be displayed in the way we wanted, but the name of the property in the code will stay the same. Attributes related to the database are usually added in the domain models and the ones that affect how the properties are displayed are added in the view models

##### In model

```csharp
public class RegisterViewModel
{
	[Display(Name="First name of user")]
	public string FirstName { get; set; }
	[Display(Name="Last name of user")]
	public string LastName { get; set; }
}
```

##### In view

```csharp cshtml
    @Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
```

##### When rendered in HTML

```html
<label for="FirstName">First name of user</label>
<input id="FirstName" name="FirstName" type="text" value="" />
<br />
<label for="LastName">Last name of user</label>
<input id="LastName" name="LastName" type="text" value="" />
```

## Sending form data to controller 🔹

Sending data from controller to a view is pretty easy. We just return a View() and add the model as a parameter. But in order to return data from the view to a controller back, we need a few extra steps. First, we need to create an action with the same name as the action that returned the view in the first place. This new action will accept the model that we are sending to the view ( the same model that we will return back from the view ) and has the [HttpPost] attribute. If we have a form and a submit button on the view, ASP.NET will know how to connect and submit the form to the Post action that we created by the name of the actions being the same

##### In model

```csharp
// Domain Model
public class User
{
	public int Id {get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public bool IsActive { get; set; }
}
```

```csharp
// View Model
public class RegisterViewModel
{
	[Display(Name="First name of user")]
	public string FirstName { get; set; }
	[Display(Name="Last name of user")]
	public string LastName { get; set; }
}
```

##### In controller

```csharp
// Code will first hit here and render the view with an empty view model
[HttpGet]
public IActionResult Register()
{
	// We send an empty view model because if the model is null we will not be able to access and bind our values
    RegisterViewModel model = new RegisterViewModel();
    return View(model);
}

// Code will hit here when the form is submitted
[HttpPost]
public IActionResult Register(RegisterViewModel model)
{
	// We create a domain model from the view model
    User user = new User()
    {
		Id = Db.GetId(), // Fictional method, imagine that it generates a new id
		FirstName = model.FirstName,
		LastName = model.LastName,
		IsActive = true
	}
	// We add the new user in to our database
	Db.Add(user);
	// We redirect to some other action since this action does is not bound to any view
    return RedirectToAction("Index");
}
```

##### In View

```csharp cshtml
<h1> Register </h1>
@using(Html.BeginForm())
{
    @Html.LabelFor(x => x.FirstName)
    @Html.TextBoxFor(x => x.FirstName)
    <br/>
    @Html.LabelFor(x => x.LastName)
    @Html.TextBoxFor(x => x.LastName)
    <br/>
    <button type="submit"> Submit </button>
}
```

## Extra Materials 📘

- [Posting data from html to mvc core controller](https://jonhilton.net/2017/08/17/how-to-get-data-from-an-html-form-to-your-asp.net-mvc-core-controller/)
- [Good article on HTML Helpers](https://www.c-sharpcorner.com/article/html-helpers-in-Asp-Net-mvc/)
- [Bootstrap 3.3 components](https://getbootstrap.com/docs/3.3/components/)
- [Introduction to bootstrap](https://www.taniarascia.com/what-is-bootstrap-and-how-do-i-use-it/)
- [Video about bootstrap grid](https://www.youtube.com/watch?v=qmPmwdshCMw)
