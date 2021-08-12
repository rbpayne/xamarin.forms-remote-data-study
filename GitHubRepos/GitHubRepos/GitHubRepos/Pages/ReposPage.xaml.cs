using System;
using GitHubRepos.ViewModels;
using Xamarin.Forms;

namespace GitHubRepos.Pages
{
    public partial class ReposPage
    {
        public ReposPage(ReposViewModel reposViewModel)
        {
            InitializeComponent();
            BindingContext = reposViewModel;
        }


        private void NavigateToRepo(object sender, EventArgs e)
        {
            try
            {
                if (((BindableObject) sender).BindingContext is RepoViewModel repoViewModel)
                {
                    Navigation.PushAsync(new RepoDetailPage(repoViewModel));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
