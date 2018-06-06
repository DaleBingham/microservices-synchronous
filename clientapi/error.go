package main

// generic error to log, for now
type jsonErr struct {
	Code int    `json:"code"`
	Text string `json:"text"`
}
