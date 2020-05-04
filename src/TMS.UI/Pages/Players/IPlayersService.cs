using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMS.UI.Pages.Players
{
    public interface IPlayersService
    {
        Task<IEnumerable<PlayerModel>> GetPlayers(uint teamId);
    }
}