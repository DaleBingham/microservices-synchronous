# microservices-synchronous
An example of microservices calling to get a process done synchronously using several programming languages and database engines. We have the following 
APIs within this project:
* people API for CRUD on people
* client API for CRUD on clients
* inventory API for CRUD on inventory (coming)
* sale API for CRUD on sales (coming)
* reporting API for read-only access on data from the above with eventual consistency (coming)

## Setup

Feel free to clone and/or download this and use as you will. If there are edits you can certainly hit me up, make issues, do PR's, etc. No "man" is an island...

### If you want to build the images and then run docker-compose up -d
* tbd

### If you want to do yourself you can follow these steps
* tbd

### Building the Database Containers
* tbd


## API Calls

See the relevant folders for the separate README files and API calls

## DB Structure

See the relevant folders for the separate README files and database structure. All databases are designed to run within containers with startup SQL scripts or
schemas already built for the microservices. 

## ToDo's still
* Document better
* Messaging for eventual consistency of data
* Istio implementation for service mesh design
* Event Driven Architecture