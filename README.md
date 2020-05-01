# ThreadQueueSample
Showcase for aspnet core Threadpool Starvation

## Prerequisites
### Install dotnet-counters
https://github.com/dotnet/diagnostics/blob/master/documentation/dotnet-counters-instructions.
### Install a load Testing Tool
To test this use a load test tool. For example https://github.com/codesenberg/bombardier
`go get -u github.com/codesenberg/bombardier`

## Start the webserver
`dotnet run -c Release`

## Run some load tests
### 500ms with clean async await
`bombardier -k -c 128 -n 50000 https://localhost:5001/blocking/non500ms`
### 50ms with clean async await
`bombardier -k -c 128 -n 50000 https://localhost:5001/blocking/non50ms`

### Run the bad Requests which block 500ms
`bombardier -k -c 128 -n 50000 https://localhost:5001/blocking/block500ms`

Depending on your hardware you have to adjust the -c parameter. My Setup is a Ryzen 3950. So the default `ThreadPool.GetMinThreads();` is 32.

## Observations
As expected the server as a high throughput as long you don't have blocking requests.
* Only GET /blocking/non500ms ==> ~250rps
* Only GET /blocking/non50ms ==> ~2500rps
* Mix of non50ms and non500ms ==> Same Numbers
* Mixing the block500ms into the mix ==> ThreadPool Starvation warnings and even crashing bombardier with timeouts
