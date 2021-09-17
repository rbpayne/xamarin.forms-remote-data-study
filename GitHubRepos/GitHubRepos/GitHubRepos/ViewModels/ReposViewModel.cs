using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GitHubRepos.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace GitHubRepos.ViewModels
{
    public class ReposViewModel : INotifyPropertyChanged
    {
        private readonly RepoRepository _repository;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<RepoViewModel> Repos { get; private set; } = new List<RepoViewModel>();
        public NetworkStatus NetworkStatus { get; set; }
        [DependsOn(nameof(NetworkStatus))]
        public bool IsRefreshing => NetworkStatus == NetworkStatus.Loading;
        public ICommand RefreshReposCommand { get; }

        public ReposViewModel(RepoRepository repository)
        {
            _repository = repository;
            repository.PropertyChanged += RepositoryOnPropertyChanged;

            RefreshReposCommand = new Command(RefreshRepos);

            RefreshRepos();
        }

        private void RepositoryOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_repository.Repos))
            {
                Repos = _repository.Repos.Select(repo => new RepoViewModel(repo)).ToList();
            }
        }

        public void RefreshRepos()
        {
            NetworkStatus = NetworkStatus.Loading;
            Task.Run(async () =>
            {
                try
                {
                    await _repository.RefreshRepos();
                    NetworkStatus = NetworkStatus.Done;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    NetworkStatus = NetworkStatus.Error;
                }
            });
        }
    }
}
