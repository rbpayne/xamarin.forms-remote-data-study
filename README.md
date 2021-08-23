# Xamarin.Forms Remote Data Study

This repo contains a Xamarin.Forms application that retrieves and displays a list of GitHub repos.

<img src="img/app-screenshot.png" max-height="820" />

## Topics Studied

- Making remote web service calls with [RestSharp](https://restsharp.dev)
- Creating remote data models and deserializing with [Json.NET](https://www.newtonsoft.com/json)
- Adding resiliency (request retry logic) with [Polly](https://github.com/App-vNext/Polly)
- Reducing load time by caching with [Akavache](https://github.com/reactiveui/Akavache)
- Handling errors gracefully with [alert pop-ups](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/pop-ups)
- Checking network availability with [Xamarin.Essentials: Connectivity](https://docs.microsoft.com/en-us/xamarin/essentials/connectivity?tabs=android)

## Architecture Diagram

![](img/architecture-diagram.jpg)

## Notes

### Displaying Error Alerts

#### HTTP Error

To see how the app handles an HTTP error:

1. Set the RestClient baseUrl to a nonexistent url (e.g. https://api.github)

```c#
var restClient = new RestClient("https://api.github");
```

2. Restart the app
3. Tap "LOAD REPOS"

<img src="img/http-error.png" max-height="820" />

#### Network Offline

To see how the app handles a network offline error, turn on airplane mode and tap "LOAD REPOS".

<img src="img/network-offline.png" max-height="820" />

## See Also

- [Working with Remote Data in Xamarin.Forms Applications](https://www.pluralsight.com/courses/remote-data-xamarin-forms-applications)
- [Xamarin.Forms Web Service Tutorial](https://docs.microsoft.com/en-us/xamarin/get-started/tutorials/web-service/?tabs=vswin)
- [Consume a RESTful web service](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/web-services/rest)
- [Getting Started with Android Development](https://www.pluralsight.com/courses/getting-started-android-development)
