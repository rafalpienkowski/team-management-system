using Microsoft.AspNetCore.Components;

namespace TMS.UI.Pages.Games
{
    public class ScoreComponentBase : ComponentBase
    {
        [Parameter]
        public GameTeamModel Home { get; set; }
        
        [Parameter]
        public GameTeamModel Guest { get; set; }
    }
}