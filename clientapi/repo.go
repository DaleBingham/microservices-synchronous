package main

import (
	"fmt"
	"time"
)

var currentId int

var clients Clients

// Give us some seed data
func init() {
	RepoCreateClient(Client{Name: "KBRwyle", Address: "26393 Exploration Drive", City: "Lexington Park", State: "Maryland", ZIP: "20619", Web: "https://www.kbrwyle.com", Email: "dale.bingham@wyle.com", Phone: "301-555-1212", Created: time.Now()})
	RepoCreateClient(Client{Name: "Aspire9", Address: "12345 North Drive", City: "Millersville", State: "Maryland", ZIP: "20099", Web: "https://www.aspire9.com", Email: "daniel.slick@aspire9.com", Phone: "240-555-1212", Created: time.Now()})
}

func RepoFindClient(id int) Client {
	for _, t := range clients {
		if t.Id == id {
			return t
		}
	}
	// return empty Todo if not found
	return Client{}
}

//need to check for race condtions
func RepoCreateClient(t Client) Client {
	currentId += 1
	t.Id = currentId
	clients = append(clients, t)
	return t
}

func RepoDestroyClient(id int) error {
	for i, t := range clients {
		if t.Id == id {
			clients = append(clients[:i], clients[i+1:]...)
			return nil
		}
	}
	return fmt.Errorf("Could not find Client with id of %d to delete", id)
}
