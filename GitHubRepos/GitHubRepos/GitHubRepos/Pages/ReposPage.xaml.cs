using System;
using System.Diagnostics;
using GitHubRepos.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GitHubRepos.Pages
{
    public partial class ReposPage
    {
        private readonly ReposViewModel reposViewModel;

        public ReposPage(ReposViewModel reposViewModel)
        {
            InitializeComponent();
            BindingContext = this.reposViewModel = reposViewModel;
        }

        private void NavigateToRepo(object sender, EventArgs e)
        {
            if (!(((BindableObject) sender).BindingContext is RepoViewModel repoViewModel))
            {
                return;
            }

            try
            {
                Navigation.PushAsync(new RepoDetailPage(repoViewModel));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }
}
