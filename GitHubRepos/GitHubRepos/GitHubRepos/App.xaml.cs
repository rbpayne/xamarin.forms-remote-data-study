using System;
using GitHubRepos.Models;
using GitHubRepos.Pages;
using GitHubRepos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace GitHubRepos
{
    public partial class App : Application
    {
        private static readonly ReposViewModel _reposViewModel = new ReposViewModel(new RepoRepository()); 
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ReposPage(_reposViewModel));
        }

        protected override void OnStart()
        {
            // Make call to GitHub to load repos
            _reposViewModel.RefreshRepos();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
