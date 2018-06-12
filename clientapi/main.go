// main.go

package main

func main() {
	a := App{}
	a.Initialize("clientapi", "clientapi", "clientapidb", "3306", "clientapi")

	a.Run(":8080")
}
