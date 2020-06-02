package main

import (
	"encoding/json"
	"log"
	"net/http"
	"strconv"

	"github.com/gorilla/mux"
)

var VehicleID = 0

func generateID() int {
	VehicleID++
	return VehicleID
}

type Owner struct {
	Name    string `json:"name"`
	Surname string `json:"surname"`
}

// Our resource struct
type VehicleResource struct {
	ID    string `json:"id"`
	Make  string `json:"make"`
	Model string `json:"model"`
	Owner Owner  `json:"owner"`
}

var vehicles []VehicleResource

// Get all resources
func getAllResources(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(vehicles)
}

func getVehicle(w http.ResponseWriter, r *http.Request) {
	ID := mux.Vars(r)["id"]
	w.Header().Set("Content-Type", "application/json")

	for _, item := range vehicles {
		if ID == item.ID {
			json.NewEncoder(w).Encode(item)
			return
		}
	}
	json.NewEncoder(w).Encode(&VehicleResource{})
}

func updateVehicle(w http.ResponseWriter, r *http.Request) {
	ID := mux.Vars(r)["id"]
	w.Header().Set("Content-Type", "application/json")

	for position, item := range vehicles {
		if ID == item.ID {
			copy(vehicles[position:], vehicles[position+1:])
			vehicles = vehicles[:len(vehicles)-1]
			var vehicle VehicleResource
			vehicle.ID = ID
			vehicles = append(vehicles, vehicle)
			json.NewEncoder(w).Encode(&vehicle)
			return
		}
	}
	json.NewEncoder(w).Encode(vehicles)
}

func createVehicle(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")

	var vehicle VehicleResource
	json.NewDecoder(r.Body).Decode(&vehicle)
	vehicle.ID = strconv.Itoa(generateID())
	vehicles = append(vehicles, vehicle)
	json.NewEncoder(w).Encode(&vehicle)
}

func deleteVehicle(w http.ResponseWriter, r *http.Request) {
	ID := mux.Vars(r)["id"]
	w.Header().Set("Content-Type", "application/json")

	for position, item := range vehicles {
		if ID == item.ID {
			copy(vehicles[position:], vehicles[position+1:])
			vehicles = vehicles[:len(vehicles)-1]
			break
		}
	}
	json.NewEncoder(w).Encode(vehicles)
}

// Main function
func main() {
	r := mux.NewRouter()

	vehicles = append(vehicles, VehicleResource{strconv.Itoa(generateID()), "BMW", "X4", Owner{"Tomasz", "Ktos"}})
	vehicles = append(vehicles, VehicleResource{strconv.Itoa(generateID()), "BMW", "X5", Owner{"Jan", "Kowal"}})
	vehicles = append(vehicles, VehicleResource{strconv.Itoa(generateID()), "BMW", "X6", Owner{"Jan2", "Nowak"}})
	vehicles = append(vehicles, VehicleResource{strconv.Itoa(generateID()), "BMW", "X7", Owner{"Jan3", "Nowakowal"}})

	// registering endpoints
	r.HandleFunc("/goapi/vehicles", getAllResources).Methods("GET")
	r.HandleFunc("/goapi/vehicles", createVehicle).Methods("POST")
	r.HandleFunc("/goapi/vehicles/{id}", getVehicle).Methods("GET")
	r.HandleFunc("/goapi/vehicles/{id}", deleteVehicle).Methods("POST")
	r.HandleFunc("/goapi/vehicles/{id}", updateVehicle).Methods("PUT")

	// Starting the server at port 8000 with logging
	log.Fatal(http.ListenAndServe(":8000", r))
}
