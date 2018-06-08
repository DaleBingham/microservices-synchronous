// main.go

package main

func main() {
	a := App{}
	a.Initialize("clientapi", "Client@pi!", "clientapi")

	a.Run(":8080")
}
