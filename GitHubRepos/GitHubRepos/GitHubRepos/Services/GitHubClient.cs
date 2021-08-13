using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubRepos.Models.Remote;
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

        public async Task<GitHubSearchResult> SearchRepos()
        {
            var request = new RestRequest("search/repositories");
            request.AddParameter("q", "xamarin.forms");
            request.AddParameter("sort", "stars");
            request.AddParameter("order", "desc");

            var response = await _restClient.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Unable to retrieve repos. API error message: {response.ErrorMessage}");
            }

            var searchResult = JsonConvert.DeserializeObject<GitHubSearchResult>(response.Content);

            if (searchResult == null)
            {
                throw new NullReferenceException("Unable to serialize response from API.");
            }

            return searchResult;
        }
    }
}
