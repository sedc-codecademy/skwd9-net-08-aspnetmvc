# SEDC e-store

# General requirements

You are required to develop an e-store application for a client. The store should implement all kind of tech products that you can think of. Phones, lap tops, PCs, headphones, etc. Each product need to have its separate details page where the customer can read more info about the product. 

# Tech requirements
The main page should display all the products in a grid layout. Also, all the CRUD operations for the products need to be implemented. In the first phase, don't mind the authentication part and the roles part.

**Implement kind of database (static db, or file system for now) where all the data will be stored and fetched from**.

Every product entity must have id, name, description, category and review from customers. The rest is based on your perception what else the product should have.

**Note**  
The first phase of this implementation need to satisfied all the controller and views implementation. Don't mind the orders part for this first phase.

Tech detailed requirements:
* The user need to see all the products. It should be the home page of the app
* The application need to have 4 menu items. 
  * About us
  * Products
  * Promotions (Ex. black Friday, cyber Monday etc) 
  * Contact
* Each product card from the grid need to have two buttons. Add to cart and details buttons
* In the first phase implement only the details button to redirect the user to a details page for the given product
* The routing into the application need to have the default pattern: {Controller}/{Action}/{id?}
* It's up to you whether you will use custom names for the routes (actions) or you will use the name of the action itself.
* In the first phase take care only for the products entities in the application. Make sure to implement domain and view models. Each product must have name, category, description, and list of reviews from customers. Think about what kind of entities you should have into the application.
* Make sure you are mapping the domain models into view models and vice versa for purpose of the view communication.

# Deadline
The first phase of the application needs to be implemented by the end of the upcoming week. That means by sunday evening (22.08). 

# Additional info
For any ambiguities or questions contact us on:
martin.panovski93@gmail.conm
fjanev14@gmail.com 

