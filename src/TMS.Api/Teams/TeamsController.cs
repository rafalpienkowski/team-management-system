using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Framework;

namespace TMS.Api.Teams
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _teamsRepository;

        public TeamsController(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        [HttpGet]
        public IEnumerable<TeamDto> Get()
        {
            var teamDtos = _teamsRepository.GetAll().Select(t => new TeamDto(t)).ToList();
            if (User.HasClaim("teamrole", "trainer"))
            {
                foreach (var teamDto in teamDtos)
                {
                    teamDto.Links.Add(new Link
                    {
                        Href = $"teams/{teamDto.Id}/games",
                        Rel = "Games",
                        Type = "GET"
                    });
                }
            }
            return teamDtos;
        }
        
        [HttpGet]
        [Route("{teamId:int}/games")]
        public IEnumerable<Game> GetGames(int teamId)
        {
            var games = new List<Game>
            {
                new Game
                {
                    Home = new GameTeam
                    {
                        Name = "Astoria Bydgoszcz",
                        Score = 101
                    },
                    Guest = new GameTeam
                    {
                        Name = "Polski Cukier Toruń",
                        Score = 87
                    }
                }
            };

            return games;
        }
    }
}