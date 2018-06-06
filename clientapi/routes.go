package main

import "net/http"

type Route struct {
	Name        string
	Method      string
	Pattern     string
	HandlerFunc http.HandlerFunc
}

type Routes []Route

var routes = Routes{
	Route{
		"ClientIndex",
		"GET",
		"/clients",
		ClientIndex,
	},
	Route{
		"ClientCreate",
		"POST",
		"/client",
		ClientCreate,
	},
	Route{
		"ClientShow",
		"GET",
		"/clients/{clientId}",
		ClientShow,
	},
}