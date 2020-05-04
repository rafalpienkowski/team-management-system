using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace TMS.UI.Pages.Players
{
    public class PlayersInTeamBase : ComponentBase
    {
        [Inject]
        public IPlayersService PlayersService { get; set; }
        
        [Parameter]
        public int TeamId { get; set; }
        
        protected IEnumerable<PlayerModel> Players { get; set; }
        
        protected PlayerModel SelectedPlayer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Players = await PlayersService.GetPlayers((uint) TeamId);
            SelectedPlayer = Players.FirstOrDefault();
        }

        protected void SetPlayer(PlayerModel playerModel)
        {
            SelectedPlayer = playerModel;
        }
    }
}