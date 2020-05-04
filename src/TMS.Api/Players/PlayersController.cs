using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TMS.Api.Players
{
    [ApiController]
    [Route("teams/{teamId:int}/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }
        
        [HttpGet]
        public IEnumerable<Player> Get(int teamId)
        {
            return _playersRepository.GetByTeam((uint)teamId);
        }
    }
}