using System.Security.Claims;
using static FlowerStore.Core.Constants.AdminConstants;

namespace FlowerStore.Extensions
{
    /// <summary>
    /// Extension for claims. 
    /// </summary>

    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
