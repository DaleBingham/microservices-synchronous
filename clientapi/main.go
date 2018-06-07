package main

import (
	"database/sql"
	"log"
	"net/http"

	_ "github.com/mattn/go-sqlite3"
)

func main() {
	// create the database if not already created
	database, _ := sql.Open("sqlite3", "./clients.db")
	statement, _ := database.Prepare("CREATE TABLE IF NOT EXISTS client (id INTEGER PRIMARY KEY, name TEXT, address TEXT, city TEXT, state TEXT, zip TEXT, web TEXT, email TEXT, phone TEXT, created TEXT)")
	statement.Exec()
	// need to close the database
	statement.Close()

	// setup the router
	router := NewRouter()
	// listen and log on port 8080 internally
	log.Fatal(http.ListenAndServe(":8080", router))
}
