using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GitHubRepos.Models;

namespace GitHubRepos.ViewModels
{
    public class ReposViewModel : INotifyPropertyChanged
    {
        private readonly RepoRepository _repository;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<RepoViewModel> Repos { get; private set; } = new List<RepoViewModel>();
        public bool IsRefreshing { get; set; }

        public ReposViewModel(RepoRepository repository)
        {
            _repository = repository;

            repository.PropertyChanged += RepositoryOnPropertyChanged;
        }

        private void RepositoryOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_repository.Repos))
            {
                Repos = _repository.Repos.Select(repo => new RepoViewModel(repo)).ToList();
            }
        }

        /// <summary>
        /// NOTE: This MUST have a return type of "Task" and not "void". Otherwise, exceptions will not be caught by
        /// event that triggered this method and the app will crash.
        ///
        /// More resources:
        ///     - https://stackoverflow.com/a/12144426/11809808
        ///     - https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming
        /// </summary>
        public async Task RefreshRepos()
        {
            try
            {
                IsRefreshing = true;
                await _repository.RefreshRepos();
                IsRefreshing = false;
            }
            catch (Exception e)
            {
                IsRefreshing = false;
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
