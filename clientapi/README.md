# Client API using Golang and MySQL
This is a single Golang API microservice with MySQL backend as a POC. It is to show how to do a single API around a particular domain with a database that is its own in a separate programming language and database server. This requires Docker, Golang 1.10.x (or latest), and a web browser to run. Optionally you can use a SQL tool such as MySQL Workbench to view the database if you so desire.

## Database Container

* run the 'docker build -t clientapidb .' from within the database directory of clientapi
* run 'docker run -d --name clientapidb --rm -p 3306:3306  clientapidb' to launch the db individually


## Database Structure for MySQL
```
CREATE TABLE clients (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(300) NOT NULL,
    city VARCHAR(100) NOT NULL,
    state VARCHAR(50) NOT NULL,
    zip VARCHAR(10) NOT NULL,
    web VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone VARCHAR(12) NOT NULL,
    created VARCHAR(100) NOT NULL
);
```

## API Calls

GET http://localhost:xxxx/clients/ gets back a JSON listing of the Clients class.

GET http://localhost:xxxx/client/1 gets back a JSON listing of the Client class for the first record. You must add a record to view anything.

POST http://localhost:xxxx/client will add this client with the information below
```
{
	"Name": "KBRwyle", 
	"Address": "22309 Exploration Drive", 
	"City": "Lexington Park", 
	"State": "Maryland", 
	"ZIP": "20619", 
	"Web": "https://www.kbrwyle.com", 
	"Email": "info@wyle.com", 
	"Phone": "301-555-1212"
}
```
PUT http://localhost:xxxx/client will update this client with the information below
```
{
    "Id" : 1,
	"Name": "KBRwyle", 
	"Address": "22309 Exploration Drive", 
	"City": "Lexington Park", 
	"State": "Maryland", 
	"ZIP": "20619", 
	"Web": "https://www.kbrwyle.com", 
	"Email": "info@wyle.com", 
	"Phone": "301-555-1212"
}
```

## ToDo's

* Log events to an event stream
* better documentation