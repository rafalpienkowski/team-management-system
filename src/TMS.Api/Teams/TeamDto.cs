using System.Collections.Generic;
using TMS.Api.Framework;

namespace TMS.Api.Teams
{
    public class TeamDto : Dto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string League { get; set; }

        public TeamDto(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            League = team.League;
            
            Links.Add(new Link
            {
                Href = $"teams/{Id}/players",
                Rel = "Players",
                Type = "GET"
            });
            }
    }
}