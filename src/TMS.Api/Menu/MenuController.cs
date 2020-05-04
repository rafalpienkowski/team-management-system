using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TMS.Api.Menu
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        [Route("items")]
        public IEnumerable<MenuItem> Get()
        {
            var menuItems = new List<MenuItem> {new MenuItem {Name = "Teams", Action = "teams"}};
            if (User.HasClaim("teamrole", "trainer"))
            {
                menuItems.Add(new MenuItem
                {
                    Name = "Games",
                    Action = "games"
                });
            }
            return menuItems;
        }
    }
}