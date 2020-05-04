using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.UI.Api;

namespace TMS.UI.Pages.Games
{
    public interface IGamesService
    {
        Task<Result<IEnumerable<GameModel>>> GetGames();
        Task<Result> AddGame(GameModel game);
        Task<Result> EditGame(GameModel game);
    }
}