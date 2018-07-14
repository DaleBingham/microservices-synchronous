# Reports API .NET Core calling other microservices
This is a single .net core API microservice that calls the other 4 microservices to get all the data. With each API owning its own data source, this is a reporting API that pulls together data from other APIs by ID and puts them together in a reporting format. This requires Docker, .NET Core 2.1 (or latest), and a web browser to run. 

## Setup

Feel free to clone and/or download this and use as you will. If there are edits you can certainly hit me up, make issues, do PR's, etc. No "man" is an island...

### If you want to build the images and then run docker-compose up -d
* go to the reportsapi directory and run 'docker build -t reportsapi .' to build the .NET Core Web API image locally
* from the root run 'docker-compose up -d' to run as a daemon or 'docker-compose up' to run interactively and see all logs

## API Calls

GET http://localhost:xxxx/swagger/ gives you the Swagger API documentation generated from the Person Controller where xxxx is the port 5000 or whatever you set it to be.

GET http://localhost:xxxx/api/reports/ gets back a JSON listing of a list of Reports showing the sale, person, inventory, and client data.

GET http://localhost:xxxx/api/report/5b4a34371ed797000108b09b gets back a JSON listing of a Report showing the sale, person, inventory, and client data.

## ToDo's still
* Document better
