# Homework - Class 03

Use the SEDC.PizzaApp project from Class 03

1.	Extend the Pizza model with the following properties:
-	Price : decimal
-	PizzaSize : Enum (PizzaSize with two members: Normal and Family)
-	HasExtras - boolean


2. Create Pizza ViewModel with the following properties
a.	Id
b.	Name
c.	Price 
d.	PizzaSize


3. Extend the OrderViewModel with property UserAddress from the address of the user and add it to the OrderDetailsViewModel Mapper.

4. Create a Mapper from Pizza Model to Pizza View Model

5. Add static List of Pizzas in the StaticDb and create list of pizza view models in the Index action in Pizza Controller and return it to the view.

6. Use the id parameter in the Details action to find the pizza in the static list and return pizza view model to the view by using ViewBag. 
If the pizza was not found or the parameter id was not provided return Empty result.

7. In the Index and Details actions in the Pizza Controller send titles to the views via ViewData.

## Bonus
Use the property HasExtras in the Pizza Mapper, so if it is true the price returned in the view model should be increased by 10.

## Bonus **
Use extension method for creating a mapper from Pizza Model to Pizza View Model.


## Contact
Trainer: stojanovskatanja@hotmail.com

Assistant: manasiev.design@gmail.com