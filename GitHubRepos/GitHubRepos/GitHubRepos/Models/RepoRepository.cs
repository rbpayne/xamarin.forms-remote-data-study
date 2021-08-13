using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using GitHubRepos.Models.Remote;
using GitHubRepos.Services;

namespace GitHubRepos.Models
{
    public class RepoRepository : INotifyPropertyChanged
    {
        private readonly GitHubClient _gitHubClient;
        private readonly IBlobCache _cache;
        private const string GitHubRepos = "GitHubRepos";

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Repo> Repos { get; private set; } = new List<Repo>();

        public RepoRepository(GitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
            _cache = BlobCache.LocalMachine;
        }

        public async Task RefreshRepos()
        {
            GitHubSearchResult? searchResult;

            try
            {
                searchResult = await _cache.GetObject<GitHubSearchResult>(GitHubRepos);
            }
            catch (KeyNotFoundException)
            {
                searchResult = default;
            }

            // If search result is not cached, request data from remote
            if (searchResult == null)
            {
                searchResult = await _gitHubClient.SearchRepos();
                await _cache.InsertObject(GitHubRepos, searchResult, DateTimeOffset.Now.AddSeconds(10));
            }

            if (searchResult == null)
            {
                return;
            }

            List<Repo> searchItemsToRepos =
                searchResult.Items.Select(item => new Repo(item.Name, item.Owner.Login)).ToList();

            Repos = searchItemsToRepos;
        }
    }
}
