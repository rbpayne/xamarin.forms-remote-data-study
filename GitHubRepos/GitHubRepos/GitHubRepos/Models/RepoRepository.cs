using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GitHubRepos.Models.Remote;
using GitHubRepos.Services;

namespace GitHubRepos.Models
{
    public class RepoRepository : INotifyPropertyChanged
    {
        private readonly GitHubClient _gitHubClient;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Repo> Repos { get; private set; } = new List<Repo>();

        public RepoRepository(GitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }

        public async Task RefreshRepos()
        {
            GitHubSearchResult searchResult;

            try
            {
                searchResult = await _gitHubClient.SearchRepos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Unable to get search result from GitHub");
            }

            if (searchResult.Items == null)
            {
                return;
            }

            List<Repo> searchItemsToRepos =
                searchResult.Items.Select(item => new Repo(item.Name, item.Owner.Login)).ToList();

            Repos = searchItemsToRepos;
        }
    }
}
