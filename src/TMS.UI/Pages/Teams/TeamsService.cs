using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TMS.UI.Api;

namespace TMS.UI.Pages.Teams
{
    public class TeamsService : ITeamsService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TeamsService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<TeamModel>> GetTeams()
        {
            return await _httpClient.GetJsonAsync<IEnumerable<TeamModel>>(_httpContextAccessor, "/teams");
        }
    }
}