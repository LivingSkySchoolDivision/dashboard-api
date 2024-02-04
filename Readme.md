# Dashboard-API
An API for internal dashboards at Living Sky School Division.

## Features
 - Test connectivity with `/ping`
 - Get UTC time with `/time`
 - Get current weather conditions from Environment Canada using `/weather`

# API Endpoints
## Ping
`/ping` is an API endpoint for validating that the API is running and web requests are able to reach it. It can also be used to test connectivity.

Example output:
```json
{
    "ping": "pong"
}
```

## Time
`/time` is an API endpoint for obtaining the current time in UTC ([Coordinated Universal Time](https://en.wikipedia.org/wiki/Coordinated_Universal_Time)). 

This was created because our dashboard projects, which are HTML/Javascript based projects, often run on embedded systems like televisions, which may not provide accurate time. Specifically, a television that we were using _did_ have the correct time set, but exposed a different, incorrect time source to Javascript running in it's embedded browser. This code allowed us to write Javascript to periodically correct a drifting and/or incorrect clock.

Example output:
```json
{
    "year": 2024,
    "month": 2,
    "day": 4,
    "hour": 18,
    "minute": 20,
    "second": 45,
    "millisecond": 709
}
```

## Weather

The `/weather/{station-id}` endpoint can be used to obtain current weather conditions from Environment Canada.

Environment Canada does not (at the time of this writing) offer a REST API for it's data, but it does offer an RSS feed. Code in this project finds and parses that RSS feed, and converts the data in it to JSON so that it can be more easily consumed by a Javascript based application.

Example output for `/weather/sk-34`
```json
{
    "locationId": "sk-34",
    "locationName": "North Battleford",
    "lastUpdated": "2024-02-04T18:00:00+00:00",
    "temperatureCelsius": "-6.7",
    "temperatureFahrenheit": "19.94",
    "temperatureKelvin": "266.45",
    "conditions": "Light Snow",
    "visibility": "5 km",
    "pressure": "102.6 kPa",
    "humidity": "88 %",
    "dewPointCelsius": "-8.4",
    "dewPointFahrenheit": "16.88",
    "wind": "NNE 9 km/h",
    "airQualityHealthIndex": "n/a",
    "observedAt": "North Battleford Airport 12:00 PM CST Sunday 4 February 2024",
    "sourceURL": "https://weather.gc.ca/rss/city/sk-34_e.xml",
    "windChillCelsius": "-11",
    "windChillFahrenheit": "12.2",
    "temperatureCelsiusWithWindChill": "-11",
    "temperatureFahrenheitWithWindChill": "12.2"
}
```
### Finding Environment Canada station ids
1. Go to https://weather.gc.ca/
2. Search for a location that has a weather station.
    - For example, "Regina, SK".
3. Once found, look in the URL for the station id code in the name of the HTML file.
    - For example, `https://weather.gc.ca/city/pages/sk-32_metric_e.html` is for Regina, SK. The code here would be `sk-32`.
    - For Toronto, ON, the URL would be `https://weather.gc.ca/city/pages/on-143_metric_e.html`, and the code would be `on-143`.
    - For Whitehorse, YT, the URL would be `https://weather.gc.ca/city/pages/yt-16_metric_e.html` and the code would be `yt-16`.
4. Send a request to this API with the code as follows: `/weather/sk-32` or `/weather/yt-16`. If the code exists, you should see the current weather conditions.


# Building and deploying
## Building
This project is written in .Net. Assuming you have an appropriate .Net SDK installed on your computer, building this project is as simple as:
1. Clone the repository to your computer
2. Open a terminal or command prompt
3. Navigate to the repo
4. `cd dashboard-api`
5. `dotnet build`
6. You may also run the command `dotnet run` to start the software in developer mode

## Building the container
This software is designed to be built into a container image, to be deployed via Kubernetes. 

If you have Docker, or a similar container runtime (we use [containerd](https://containerd.io/)), you can build the container using the following commands:

```sh
docker build . -t dashboard-api/dev
```
You can then run the container using:
```sh
docker run dashboard-api/dev -p 8080:80
```

You can then access the container by going to http://localhost:8080/ on your system.
