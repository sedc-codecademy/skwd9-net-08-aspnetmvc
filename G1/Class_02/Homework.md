# Homework - Class 02

**Work with the SEDC.PizzaApp**

1. In the already created PizzaController use the created Index action 
to return a JsonResult with list of all pizzas

2. Add Details action with optional parameter id.
   If id is null it should return empty result, else it should return a view with simple html that will have only h1 element saying Pizza Details page. It should be accessed through route Ex: http://localhost:12345/[Controller Name]/Details/{id?}


## Bonus
1. For the second requirement try to use RedirectToAction() instead of EmptyResult.
If the id is null or 0 then redirect the user to the Error action from the HomeController.  

2. Find the Error.cshtml view, delete all the html from it and add h2 element that will display message: 'The given pizza was not found!'
---

## Contact

Trainer: panovski.martin93@gmail.com

Co-Trainer: fjanev14@gmail.com
