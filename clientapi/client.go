package main

import "time"

type Client struct {
	Id      int       `json:"id"`
	Name    string    `json:"name"`
	Address string    `json:"address"`
	City    string    `json:"city"`
	State   string    `json:"state"`
	ZIP     string    `json:"zip"`
	Web     string    `json:"web"`
	Email   string    `json:"email"`
	Phone   string    `json:"phone"`
	Created time.Time `json:"created"`
}

type Clients []Client
