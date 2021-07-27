using GitHubRepos.Models;

namespace GitHubRepos.ViewModels
{
    public class RepoViewModel
    {
        private readonly Repo _repo;

        public string Name => _repo.Name;
        public string Owner => _repo.Owner;

        public RepoViewModel(Repo repo)
        {
            _repo = repo;
        }
    }
}
