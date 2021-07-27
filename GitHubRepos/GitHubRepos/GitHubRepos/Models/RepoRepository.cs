using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GitHubRepos.Services;

namespace GitHubRepos.Models
{
    public class RepoRepository : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Repo> Repos { get; private set; } = new List<Repo>();

        public void RefreshRepos()
        {
            var searchItems = GitHubService.SearchRepos().Items;

            // TODO: There may be another way to handle this
            if (searchItems == null)
            {
                return;
            }

            var searchItemsToRepos = searchItems.Select(item => new Repo(item.Name, item.Owner.Login)).ToList();

            Repos = searchItemsToRepos;
        }
    }
}
