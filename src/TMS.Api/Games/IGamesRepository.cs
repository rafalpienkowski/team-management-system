using System.Collections.Generic;

namespace TMS.Api.Games
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetGames();
        Result Add(Game game);
        Result Edit(Game game);
    }
}