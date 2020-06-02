# Brain breakers :black_circle:

Now that you have gotten a decent grasp of Go's basics, structs and interfaces, let's move over to a more practical example.

In this task, you will build a RESTful API server.

## CRUD API

Come up with a resource that your app would serve (ie. Books, Cars, Customers, ect.). It should have at least 4 fields, including an auto-incremented ID.

A slice containing all instances of said resource should be stored in-memory. Using a persistent DB is not required. Starting contents (at least 4 items) can be hard-coded.

### Endpoints

Your app should expose the following endpoints (illustrated by an example resource - Cars):

#### Get single

```
GET goapi/cars/{id}
```

#### Get list

```
GET goapi/cars
```

#### Create

```
POST goapi/cars
```

#### Update

```
PUT goapi/cars/{id}
```

#### Delete

```
POST goapi/cars/{id}
```

### Sample requests

`GET goapi/cars/1`

Response:

```js
{
  "id": 1,
  "make": "BMW",
  "model": "330i",
  "owner": {"name": "John", "surname": "Doe"}
}
```

`POST goapi/cars`

Request:

```js
{
  "make": "VW",
  "model": "Golf",
  "owner": {"name": "Andrew", "surname": "Doe"}
}
```

Response:

```js
{
  "id": 4,
  "make": "VW",
  "model": "Golf",
  "owner": {"name": "Andrew", "surname": "Doe"}
}
```

## Tips and recommendations

-   Use [gorilla/mux](https://github.com/gorilla/mux) for routing. To install it, run: `go get -u github.com/gorilla/mux`
-   As a starting point, you can use the boilerplate provided in this directory ;)
-   Bare in mind that Go's `net/http` package will call a new go subroutine for every client connection to your server. Make sure to mitigate the race condition in access to your in-memory data by using either mutexes or channels. [This blog post](https://eli.thegreenplace.net/2019/on-concurrency-in-go-http-servers/) discusses that in-depth.
