# xamarin.forms-remote-data-study

This repo contains a Xamarin.Forms application that retrieves and displays a list of GitHub repos. It is based on learnings from [Working with Remote Data in Xamarin.Forms Applications](https://www.pluralsight.com/courses/remote-data-xamarin-forms-applications). The GitHub app example is inspired by [Getting Started with Android Development](https://www.pluralsight.com/courses/getting-started-android-development).

## Topics Studied

- [x] Making remote web service API calls with [RestSharp](https://restsharp.dev)
- [x] Creating models for remote data
- [x] Deserializing data with [Json.NET](https://www.newtonsoft.com/json)
- [x] Adding resiliency with [Polly](https://github.com/App-vNext/Polly)
- [x] Caching data with [Akavache](https://github.com/reactiveui/Akavache)
- [x] Handling errors gracefully
- [ ] Checking network availability

## Notes

### How to Display an Error

To get the app to display an error, set the RestClient baseUrl to a nonexistent url (e.g. https://api.github).

```
var restClient = new RestClient("https://api.github");
```

<img src="img/display-error.png" height="640" />
