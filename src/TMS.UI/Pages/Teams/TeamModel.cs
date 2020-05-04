using System.Collections.Generic;
using TMS.UI.Api;

namespace TMS.UI.Pages.Teams
{
    public class TeamModel
    {
        public string Name { get; set; }
        public string League { get; set; }
        public IList<Link> Links { get; set; }
    }
}