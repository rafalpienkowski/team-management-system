using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TMS.Api.Games
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = Policies.IsStaff)]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public IEnumerable<Game> Get() => _gamesRepository.GetGames();

        [HttpPost]
        public Result Add(Game game) => _gamesRepository.Add(game);

        [HttpPut]
        public Result Edit(Game game) => _gamesRepository.Edit(game);
    }
}