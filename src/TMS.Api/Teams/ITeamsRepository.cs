using System.Collections.Generic;

namespace TMS.Api.Teams
{
    public interface ITeamsRepository
    {
        IEnumerable<Team> GetAll();
    }
}