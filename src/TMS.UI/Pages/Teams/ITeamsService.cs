using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMS.UI.Pages.Teams
{
    public interface ITeamsService
    {
        Task<IEnumerable<TeamModel>> GetTeams();
    }
}