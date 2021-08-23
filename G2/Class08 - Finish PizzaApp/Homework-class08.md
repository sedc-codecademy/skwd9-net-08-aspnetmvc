# Homework - Class 08

Use the SEDC.PizzaApp.Refactored project from Class 08

We need to add a feature for giving feedbacks for the services of our pizza store and pizza app. You will need to implement the whole flow, through
all the three levels of our new architecture. Be careful with the different types of models!

1. Create a model for Feedback that contains the following properties:
- Id (int)
- Name (string) - the name of the visitor that gives feedback 
- Email (string) - email of the visitor that gives the feedback
- Message (string) - content of the feedback

This entity (Feedback) is stand-alone, it doesn't have relations with other tables (entities).

2. Create a repository that handles data access for feedback entities and implements the CRUD operations.

3. Create a service that handles logic for feedbacks.

4. Create a corresponding Controller.

5. Add a menu link in Layout that leads to Feedback page.

6. Implement listing of all feedbacks, inserting a feedback, editing a feedback and deleting a feedback.


## Bonus 1
Maximum three feedbacks are allowed per email. 
In the method for creating a pizza from the previous homework, add validation that there should be only one pizza on promotion.
Think where should this validation be done.

## Bonus 2
B1. Add an action on the order screen for deleting a pizza from an order.

B2. Each time a pizza is added to an order add a field for entering the number of pizzas in that order item. For example we should be able to add 2 Capri or 3 Pepperoni.. Assume that all of these
pizzas is same size, for example 2 Standard Capri or 3 Family Pepperoni.

## Bonus **
Check if the email is in correct format. Think where should this validation be done. 


## Contact
Trainer: stojanovskatanja@hotmail.com

Assistant: manasiev.design@gmail.com