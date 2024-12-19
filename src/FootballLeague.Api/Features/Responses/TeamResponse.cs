namespace FootballLeague.Api.Features.Responses
{
    public class TeamResponse
    {
        public TeamResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}
