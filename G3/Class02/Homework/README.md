# Homework for happy weekend

### Requirements

1. Create Product controller that will have two action GetProductById(int id) and GetProductByName(string name).
The action end points should be available at urls:

    /product/get-product/3

    /product/get-product/shoes

2. Create Movie controller that will have two actions. The first action should have a parameter of type DateTime and the second should have the parameter of type Boolean. 
The action end points should be available at urls:

    /homework/movie/get-movies/2019-05-03

    /homework/movie/get-available/true

#### Bonus

* Create Order controller that will be able to create an order. After creating the order the user should be redirected to the /Home route.
* Bonus: Action end points should be available at: /pizza/order/create-order/
