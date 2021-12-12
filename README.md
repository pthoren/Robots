Robots
=============
Start the server:
```
dotnet build
dotnet run --project Robots/Robots.csproj
```
Run integration tests:
```
./test.sh
```
TODOs:
- unit tests
- read api urls from config/ discover at runtime
- inject collaborators instead of manually instantiating
- make robot selection strategy pluggable
- cleanup names
- cache robot positions?
- generate api endpoints and clients using an IDL
- error handling/ fault tolerance
- logging
- health checks
- authentication
- containerize

