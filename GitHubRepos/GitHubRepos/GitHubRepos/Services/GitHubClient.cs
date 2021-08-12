using System;
using GitHubRepos.Models.Remote;
using Newtonsoft.Json;
using RestSharp;

namespace GitHubRepos.Services
{
    /*
     * "Client" name taken from https://softwareengineering.stackexchange.com/a/342406/355398.
     * More good resources: https://softwareengineering.stackexchange.com/a/90032/355398
     */
    public class GitHubClient
    {
        /*
         * NOTE: This should not be static if you are using dependency
         * injection. However, it is fine for this illustration.
         */
        public static GitHubSearchResult SearchRepos()
        {
            /*
             * Most of this code was generated from Postman
             * See https://learning.postman.com/docs/sending-requests/generate-code-snippets/ for more info.
             */
            var client =
                new RestClient("https://api.github.com/search/repositories?q=xamarin.forms&sort=stars&order=desc")
                {
                    Timeout = -1
                };
            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);
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
