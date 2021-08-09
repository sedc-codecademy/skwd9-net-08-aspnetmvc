# Homework

•	Create an ASP.NET Core 3.1 MVC application that is used for managing a Book Library. 

•	One book should have an Id, Title, year of publishing and list of authors (Id, First and Last Name). 

•	There should be a StaticDb implementation, that keeps a list of all the Books available in the library that can be acquired at any time.

•	There should be a functionality to view a List of all the books available (Id, Title, Year)

•	There should be a functionality to view Book Details. (all properties)

•	There should be functionality to add a Book to the library. 

•	There should be functionality to edit the info of a Book in the library.

•	There should be functionality to remove a Book from the library.

•	Homework: Create a book controller with the following actions:

    o	Localhost:12345/books => accesses the action that is used for returning a view with a list of books

    o	Localhost:12345/book/details/{id} -> if this is accessed with book Id that exists it returns a view with the details of the book, otherwise it redirects to the index action of the controller. The Id is not nullable.
    o	Action that returns an empty result
    o	Action that returns JSON result
•	Create the needed domain and view models that will be used in the application. 

•	Create views that map to the models and show the data consisted in the model.

•	Send title through ViewBag or ViewData (your choice) to the books list View.

Bonus:  
•	Extend Book with Genre (value from enum) and book rating which should be a number between 1 – 5 (it can be decimal with maximum 2 points)  hint: enums should be stored under Models/Enums
