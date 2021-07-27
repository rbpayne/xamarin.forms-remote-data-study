using GitHubRepos.ViewModels;

namespace GitHubRepos.Pages
{
    public partial class ReposPage
    {
        public ReposPage(ReposViewModel reposViewModel)
        {
            InitializeComponent();
            BindingContext = reposViewModel;
        }
        
        
    }
}
