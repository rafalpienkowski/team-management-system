using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TMS.UI.Pages
{
    public class LoginIDP : PageModel
    {
        public async Task OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme);
            }
            else
            {
                Response.Redirect(Url.Content("~/"));
            }
        }
    }
}