namespace FootballLeague.Api.Entities
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        public int Id { get;  }

        public string Name { get; private set; }

        public Standings Standings { get; }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
