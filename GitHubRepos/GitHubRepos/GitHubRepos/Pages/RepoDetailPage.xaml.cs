using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubRepos.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GitHubRepos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepoDetailPage : ContentPage
    {
        public RepoDetailPage(RepoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
