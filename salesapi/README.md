# Client API using NodeJS and PostgreSQL
This is a single Java Spring Boot API microservice with MongoDB backend as a POC. It was started with the Spring Initialzr https://start.spring.io.  It is to show how to do a single API around a particular domain with a database that is its own in a separate programming language and database server. This requires Docker, Java v 8.0 or later, and a web browser to run. Optionally you can use a SQL tool such as mongo-express to view the database if you so desire.

## Database Container
* run the 'docker build -t salesapidb .' from within the database directory of inventoryapi
* run the database: 'docker run -d --rm --name salesapidb -p 27017:27017 salesapidb'

## Database Setup
Use the Mongo DB database created above and tie it into the application.properties file to match the name, server, and port.

## API Calls

GET http://localhost:xxxx/api/sales/ gets back a JSON listing of the Inventory class.

GET http://localhost:xxxx/api/sales/1 gets back a JSON listing of the Inventory class for the first record. You must add a record to view anything.

POST http://localhost:xxxx/api/sales/ will add this Inventory item with the information below
```
{
	"name" : "Kids Bicycle Helmet - Medium", 
	"description": "Kids bicycle helmet with strap for medium sized head.", 
	"price": 15.09, 
	"saleprice": null,
	"quantity": 11, 
	"company" : 1
}
```
PUT http://localhost:xxxx/api/sales/1 will update this Inventory item with the information below
```
{
	"name" : "Kids Bicycle Helmet - Medium", 
	"description": "Kids bicycle helmet with strap for medium sized head.", 
	"price": 15.99, 
	"saleprice": null,
	"quantity": 11, 
	"company" : 1
}
```
DELETE http://localhost:xxxx/api/sales/1 will delete this Inventory item if found

## ToDo's

* Log events to an event stream
* better documentation