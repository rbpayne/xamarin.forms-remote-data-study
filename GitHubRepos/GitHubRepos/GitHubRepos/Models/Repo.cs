namespace GitHubRepos.Models
{
    public class Repo
    {
        public readonly string Name;
        public readonly string Owner;

        public Repo(string name, string owner)
        {
            Name = name;
            Owner = owner;
        }
    }
}
