using System.Collections.Generic;

namespace TMS.Api.Teams
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly List<Team> _teams = new List<Team>
        {
            new Team
            {
                Id = 1,
                Name = "Seniors", 
                League = "I league"
            }, 
            new Team
            {
                Id = 2,
                Name = "Juniors", 
                League = "IV league"
            }
        };

        public IEnumerable<Team> GetAll()
        {
            return _teams;
        }
    }
}