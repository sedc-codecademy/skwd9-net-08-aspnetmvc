# Homework (Class07) 👀

_Use the SEDC.PizzaApp.Refactored project from Class 07_

Follow the same pattern that we've implemented for the PIzza, Order and User entities, to create implementation for the **feedbacks** in our application

- Create domain model `Feedback` with the following properties:

  - Id
  - Name
  - Email
  - Message

- Create `FeedbackRepository` that will implement the IRepository interface, and it's predefined methods

#### _Bonus_: In the `IUserService` interface create 2 methods:

- `GiveFeedback` that will accept feedback as parameter and it will just insert the feedback into our static DB
- `GetFeedback` that will return a certain amount of feedback based to the parameter of the method. For example, if GetFeedback is invoked with parameter of 5 => it will return the first 5 feedbacks etc.

###### Hint: Make sure that the app is successfully built and feel free to add all the required logic in order to get there


## Contact
Trainer: panovski.martin93@gmail.com

Co-Trainer: fjanev14@gmail.com

**Happy coding** 😎
