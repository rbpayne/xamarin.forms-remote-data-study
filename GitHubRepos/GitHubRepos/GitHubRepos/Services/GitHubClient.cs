using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubRepos.Models.Remote;
using GitHubRepos.Utilities;
using Newtonsoft.Json;
using Polly;
using RestSharp;

namespace GitHubRepos.Services
{
    /*
     * "Client" name taken from https://softwareengineering.stackexchange.com/a/342406/355398.
     * More good resources: https://softwareengineering.stackexchange.com/a/90032/355398
     */
    public class GitHubClient
    {
        private readonly IRestClient _restClient;

        public GitHubClient(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<GitHubSearchResult?> SearchRepos()
        {
            try
            {
                var request = new RestRequest("search/repositories");
                request.AddParameter("q", "xamarin.forms");
                request.AddParameter("sort", "stars");
                request.AddParameter("order", "desc");

                string jsonResult = string.Empty;

                var responseMessage = await Policy
                    .Handle<HttpRequestException>(exception =>
                    {
                        Debug.WriteLine($"{exception.GetType().Name} : {exception.Message}");
                        return true;
                    })
                    //.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking: 2, durationOfBreak: TimeSpan.FromSeconds(30))
                    .WaitAndRetryAsync(
                        5,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                    .ExecuteAsync(async () => await _restClient.ExecuteAsync(request));

                if (!responseMessage.IsSuccessful)
                {
                    throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
                }
                
                jsonResult = responseMessage.Content;
                var searchResult = JsonConvert.DeserializeObject<GitHubSearchResult>(jsonResult);

                return searchResult;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.GetType().Name} : {e.Message}");
                throw;
            }
        }
    }
}
