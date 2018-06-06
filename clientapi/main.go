package main

import (
	"log"
	"net/http"
)

func main() {
	// setup the router
	router := NewRouter()
	// listen and log on port 8080 internally
	log.Fatal(http.ListenAndServe(":8080", router))
}
