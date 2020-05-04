using Microsoft.AspNetCore.Authorization;

namespace TMS.UI
{
    public static class Policies
    {
        public const string IsStaff = "IsStaff";

        public static AuthorizationPolicy IsStaffPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("teamrole", "trainer")
                .Build();
        }
    }
}