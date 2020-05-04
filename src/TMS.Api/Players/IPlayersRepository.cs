using System.Collections.Generic;

namespace TMS.Api.Players
{
    public interface IPlayersRepository
    {
        IEnumerable<Player> GetByTeam(uint teamId);
        Player GetById(uint id);
    }
}