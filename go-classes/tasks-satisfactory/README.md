# Let's start thinking :large_blue_circle:

Well done getting through the first part! Now let's play around with structs and interfaces.

In this task you will build a library of vehicles.

1. Create a struct Vehicle with at least 4 properties and write a function `NewVehicle()` that would initialize it's values (like a constructor would) and return a pointer to the new Vehicle.
2. Add an ID field to the Vehicle struct that would auto-increment every time a new Vehicle is added.
3. Create the following methods for type Vehicle:
- `move()` that will print the string "Vehicle {Vehicle's name} is moving"
- `viewDetails()` that will print values of all the fields that vehicle has
4. Think of at least two vehilce sub-types (ie. Car, Boat, Motorcycle) and implement them. Struct for each sub-type should contain a pointer to Vehicle type and at least two new fields. Their initializers should call the Vehicle's type initializer.
5. One of the sub-types created in step 4) should have a specific method that no other type has (ie. Boat could have method `swim()`).
6. Make it so that calling the `move()` method on one of Vehicle sub-types will print a more specific string (ie. "Car {Car's license plate number} is moving").
7. Add `viewDetails()` method to all vehicle sub-types so that it prints values of all fields it's struct has (Vehicle fields and fields specific to that sub-type).
8. In your main function, create at least 3 instances of each sub-type of vehicle and put them inside an appropriate slice. Iterate over elements of that slice calling `viewDetails()` and `move()` on each element.
9. In the loop defined in step 8), if the current element is of type described in step 5), additionally call the method specific to that type.