using GitHubRepos.Models;
using GitHubRepos.Pages;
using GitHubRepos.Services;
using GitHubRepos.ViewModels;
using RestSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace GitHubRepos
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            // NOTE: In a production grade app we would use Microsoft dependency injection (https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
            var restClient = new RestClient("https://api.github.com/");
            var gitHubClient = new GitHubClient(restClient);
            var reposViewModel = new ReposViewModel(new RepoRepository(gitHubClient));

            MainPage = new NavigationPage(new ReposPage(reposViewModel));
        }

        protected override void OnStart()
        {
            // Make call to GitHub to load repos
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
