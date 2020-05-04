using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace TMS.UI.Shared.NavMenu
{
    public class NavMenuBase : ComponentBase
    {
        private bool _collapseNavMenu = true;

        [CascadingParameter]
        Task<AuthenticationState> AuthenticationStateTask { get; set; }
        
        public IEnumerable<MenuItemModel> Items { get; set; } = new List<MenuItemModel>();
        
        [Inject]
        private IMenuService _menuService { get; set; }

        protected string NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateTask;
            if (authenticationState.User.Identity.IsAuthenticated)
            {
                Items = await _menuService.GetMenu();
            }
        }
    }
}