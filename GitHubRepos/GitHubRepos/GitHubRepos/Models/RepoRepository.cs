using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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
            var searchResult = await _gitHubClient.SearchRepos();

            if (searchResult?.Items == null)
            {
                // TODO: Throw an exception and tell the user that we found nothing
                return;
            }

            List<Repo> searchItemsToRepos =
                searchResult.Items.Select(item => new Repo(item.Name, item.Owner.Login)).ToList();

            Repos = searchItemsToRepos;
        }
    }
}
