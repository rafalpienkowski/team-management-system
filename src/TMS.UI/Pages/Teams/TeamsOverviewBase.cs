using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace TMS.UI.Pages.Teams
{
    public class TeamsOverviewBase : ComponentBase
    {
        [Inject] 
        public ITeamsService TeamsService { get; set; }

        public IEnumerable<TeamModel> Teams { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Teams = await TeamsService.GetTeams();
        }
    }
}