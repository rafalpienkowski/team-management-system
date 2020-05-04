using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TMS.UI.Api;

namespace TMS.UI.Pages.Players
{
    public class PlayersService : IPlayersService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PlayersService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<PlayerModel>> GetPlayers(uint teamId)
        {
            return await _httpClient.GetJsonAsync<IEnumerable<PlayerModel>>(_httpContextAccessor, $"/teams/{teamId}/players");
        }
    }
}