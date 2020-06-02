package main

import (
	"fmt"
)

type IVehicle interface {
	Move()
	viewDetails()
}

var VehicleID = 0

func (v *Vehicle) viewDetails() {
	fmt.Println(v.ID)
	fmt.Println(v.Brand)
	fmt.Println(v.Model)
	fmt.Println(v.HP)
	fmt.Println(v.Doors)
}

func (m *Motorcycle) viewDetails() {
	fmt.Println(m.ID)
	fmt.Println(m.Brand)
	fmt.Println(m.Model)
	fmt.Println(m.HP)
	fmt.Println(m.Doors)
	fmt.Println(m.NewField1)
	fmt.Println(m.NewField2)
}

func (c *Car) viewDetails() {
	fmt.Println(c.ID)
	fmt.Println(c.Brand)
	fmt.Println(c.Model)
	fmt.Println(c.HP)
	fmt.Println(c.Doors)
	fmt.Println(c.FuelType)
	fmt.Println(c.MaxSpeed)
}

type Vehicle struct {
	ID    int
	Doors int
	Brand string
	Model string
	HP    int
}

func (v *Vehicle) Move() {
	fmt.Println("Vehicle " + v.Brand + " " + v.Model + " is moving.")
}

func NewVehicle(doors int, brand string, model string, hp int) *Vehicle {
	v := &Vehicle{ID: VehicleID, Doors: doors, Brand: brand, Model: model, HP: hp}
	VehicleID++
	return v
}

type Car struct {
	FuelType string
	MaxSpeed int
	*Vehicle
}

func NewCar(doors int, brand string, model string, hp int, fuelType string, maxSpeed int) *Car {
	return &Car{fuelType, maxSpeed, NewVehicle(doors, brand, model, hp)}
}

type Motorcycle struct {
	NewField1 int
	NewField2 string
	*Vehicle
}

func NewMotorcycle(doors int, brand string, model string, hp int, newField1 int, newField2 string) *Motorcycle {
	return &Motorcycle{newField1, newField2, NewVehicle(doors, brand, model, hp)}
}

func (m *Motorcycle) wheelie() {
	fmt.Println(m.Brand + " " + m.Model + " made a nice wheelie.")
}

func (m *Motorcycle) Move() {
	fmt.Println("Motorcycle " + m.Brand + " " + m.Model + " is flying.")
}

func main() {

	vehicles := []IVehicle{
		NewCar(5, "BMW", "X7", 570, "Petrol", 250),
		NewCar(5, "BMW", "X6", 620, "Petrol", 280),
		NewMotorcycle(0, "Suzuki", "Hayabusa", 173, 69, "something"),
		NewCar(5, "BMW", "X5", 420, "Diesel", 230),
		NewMotorcycle(0, "Honda", "CBR", 115, 100, "something2"),
		NewMotorcycle(0, "Kawasaki", "Ninja", 120, 1, "something3")}

	for _, v := range vehicles {
		v.Move()
		v.viewDetails()
		if v, ok := v.(*Motorcycle); ok {
			v.wheelie()
		}
	}

	// car1 := NewCar(5, "BMW", "X6", 620, "Petrol", 280)
	// car1.Move()
	// car1.viewDetails()
	// m1 := NewMotorcycle(0, "Suzuki", "Hayabusa", 173, 69, "something")
	// m1.Move()
	// m1.viewDetails()
	// m1.wheelie()
}
