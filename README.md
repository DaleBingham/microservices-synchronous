# Synchronous Microservices
An example of microservices that house and run their own data themselves.  You can call the individual people, client, inventory, or sale APIs for CRUD operations.  They are all "synchronous" as far as getting their data immediately from the API. We are using several programming languages and database engines on purpose to show that APIs do not care what language you run it. Just that the contract is rigth! We have the following APIs within this project:
* people API for CRUD on people with .NET Core and MSSQL Server Express Linux
* client API for CRUD on clients with Golang and MySQL (these are basically companies)
* inventory API for CRUD on inventory with NodeJS and PostgreSQL
* sale API for CRUD on sales with Java Spring Boot and MongoDB
* reporting API (coming soon) for read-only access on data from the above, i.e. sale linked to inventoryId, personId, and clientId for reference with the full recordset for each sale. Assuming one item per sale for simplicity. This is the one that ties it all together.

## Setup

Feel free to clone and/or download this and use as you will. If there are edits you can certainly hit me up, make issues, do PR's, etc. No "man" is an island...

* You can run each API separately by having the runtimes and pulling down the projects to run within each folder. Be careful as all are set to port 8080 by default. Feel free to change that. I left them on purpose to show port translation later. 
* There is a single docker-compose.yml file to run 'docker-compose up -d' if you want to spin up all containers and have them communicate. Note the environment pieces within the main docker-compose as it links to other containers by name.

### If you want to build the images and then run docker-compose up -d
* run 'build-api-images' sh or cmd as appropriate based on your OS.

### Building the Database Containers
* run 'build-database-images' sh or cmd as appropriate based on your OS.

## API Calls

See the relevant folders for the separate README files and API calls. Also each API (outside of the Golang API) has swagger 2.0 documentation that you can use and follow. The folders have README.md files in them to explain each API independently a little more in depth.

## DB Structure

See the relevant folders for the separate README files and database structure. All databases are designed to run within containers with startup SQL scripts or
schemas already built for the microservices. 

## ToDo's still
* Document better, including https://www.draw.io/ documentation via images
* Implement GitOps with Jenkins to auto-deploy locally with changes and webhooks
* Messaging for eventual consistency of data
* Istio implementation for service mesh design
* Event Driven Architecture
* Implement /_/health checks for the APIs and subsystems
