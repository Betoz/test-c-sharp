# Test C#
This is a test project with the goal of having a minimal dockerized .NET Core API application. We are not there yet.

## Build and start
Built image with
```bash
docker build -t the-test-application:test-rev TheTestApplication
```
and start it with
```bash
docker container run -dit --name my-test-application -p 80:80 the-test-application:test-rev
```

## Test
Curl or visit
* <http://localhost/weatherforecast>

## Shut down
```
docker container rm -f my-test-application
```
