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
        public Status Status { get; set; }

        public ReposViewModel(RepoRepository repository)
        {
            _repository = repository;
            repository.PropertyChanged += RepositoryOnPropertyChanged;

            RefreshRepos();
        }

        private void RepositoryOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_repository.Repos))
            {
                Repos = _repository.Repos.Select(repo => new RepoViewModel(repo)).ToList();
            }
        }

        private void RefreshRepos()
        {
            Status = Status.Loading;
            Task.Run(async () =>
            {
                try
                {
                    await _repository.RefreshRepos();
                    Status = Status.Done;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Status = Status.Error;
                }
            });
        }
    }
}
