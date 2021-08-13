# xamarin.forms-remote-data-study

This repo contains a Xamarin.Forms application that retrieves and displays a list of GitHub repos. It is based on learnings from [Working with Remote Data in Xamarin.Forms Applications](https://www.pluralsight.com/courses/remote-data-xamarin-forms-applications). The GitHub app example is inspired by [Getting Started with Android Development](https://www.pluralsight.com/courses/getting-started-android-development).

<img src="img/app-screenshot.png" height="820" />

## Topics Studied

- Making remote web service API calls with [RestSharp](https://restsharp.dev)
- Creating models for remote data
- Deserializing data with [Json.NET](https://www.newtonsoft.com/json)
- Adding resiliency with [Polly](https://github.com/App-vNext/Polly)
- Caching data with [Akavache](https://github.com/reactiveui/Akavache)
- Handling errors gracefully
- Checking network availability

## Notes

### How to Display Errors

#### HTTP Error

To see how the app handles an HTTP error:

1. Set the RestClient baseUrl to a nonexistent url (e.g. https://api.github)

```c#
var restClient = new RestClient("https://api.github");
```

2. Restart the app
3. Tap the "LOAD REPOS" button

<img src="img/http-error.png" height="820" />

#### Network Offline

To see how the app handles a network offline error, turn on airplane mode and tap "LOAD REPOS".

<img src="img/network-offline.png" height="820" />
