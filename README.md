# Test C#
This is a test project with the goal of having a minimal dockerized .NET Core API application + PostgreSQL database.
We are not there yet.

The current application is an API managing message storage in in-memory database.

## Build and run
Built image
```bash
$ docker image build --tag thetestapplication TheTestApplication
```
Run container with image
```bash
$ docker container run --name runningtestapplication --detach --publish 80:80 thetestapplication
```

## Test
The database is empty at start. Getting all messages should return an empty list.
```Bash
$ curl -f http://localhost/api/messages
[]
```
Here, the **-f** option makes the curl show error responses if any.

Add data
```Bash
$ curl -f http://localhost/api/messages -H "Content-Type: application/json" -d '{"message":"Hello world"}'
{"id":1,"message":"Hello world"}
```
```Bash
$ curl -f http://localhost/api/messages -H "Content-Type: application/json" -d '{"message":"Come here"}'
{"id":2,"message":"Come here"}
```
```Bash
$ curl -f http://localhost/api/messages -H "Content-Type: application/json" -d '{"message":"Pasta for lunch"}'
{"id":3,"message":"Pasta for lunch"}
```
```Bash
$ curl -f http://localhost/api/messages -H "Content-Type: application/json" -d '{"message":"Welcome home"}'
{"id":4,"message":"Welcome home"}
```
```Bash
$ curl -f http://localhost/api/messages -H "Content-Type: application/json" -d '{"message":"There is more"}'
{"id":5,"message":"There is more"}
```
Read data
```Bash
$ curl -f http://localhost/api/messages
[{"id":1,"message":"Hello world"},{"id":2,"message":"Come here"},{"id":3,"message":"Pasta for lunch"},{"id":4,"message":"Welcome home"},{"id":5,"message":"There is more"}]
```
```Bash
$ curl -f http://localhost/api/messages/3
{"id":3,"message":"Pasta for lunch"}
```
```Bash
$ curl -f http://localhost/api/messages/6
curl: (22) The requested URL returned error: 404 Not Found
```
Delete data
```Bash
$ curl -f http://localhost/api/messages/3 -X DELETE
{"id":3,"message":"Pasta for lunch"}
```
```Bash
$ curl -f http://localhost/api/messages/6 -X DELETE
curl: (22) The requested URL returned error: 400 Bad Request
```
Read data
```Bash
$ curl -f http://localhost/api/messages/3
curl: (22) The requested URL returned error: 404 Not Found
```
```Bash
$ curl -f http://localhost/api/messages
[{"id":1,"message":"Hello world"},{"id":2,"message":"Come here"},{"id":4,"message":"Welcome home"},{"id":5,"message":"There is more"}]
```

## Shut down
```bash
$ docker container rm -f runningtestapplication
```
