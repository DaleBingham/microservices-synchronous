


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

## ToDo's

* Log events to an event stream
* better documentation