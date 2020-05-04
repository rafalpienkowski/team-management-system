using Microsoft.AspNetCore.Components;

namespace TMS.UI.Pages.Players
{
    public class SelectedPlayerDetailsBase : ComponentBase
    {
        [Parameter]
        public PlayerModel SelectedPlayer { get; set; }
    }
}