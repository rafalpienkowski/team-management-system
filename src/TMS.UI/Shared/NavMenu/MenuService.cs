using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TMS.UI.Api;

namespace TMS.UI.Shared.NavMenu
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<MenuItemModel>> GetMenu()
        {
            return await _httpClient.GetJsonAsync<IEnumerable<MenuItemModel>>(_httpContextAccessor, "/menu/items");
        }
    }
}