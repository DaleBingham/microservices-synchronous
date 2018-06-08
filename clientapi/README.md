


## Database Container

docker run -d --name clientapidb --rm -e MYSQL_ROOT_PASSWORD=Myp@ssword! -e MYSQL_DATABASE=clientapi -e MYSQL_USER=clientapi -e MYSQL_PASSWORD=Client@pi! -p 3306:3306  mysql:8
2f8ec1edbe59fa27be22e230402787758ad7d8e2d600cdc50a749d9a90c900d5


## Database Structure for MySQL

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