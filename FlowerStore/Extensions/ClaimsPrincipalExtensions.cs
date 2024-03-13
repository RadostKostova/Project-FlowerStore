using System.Security.Claims;

namespace FlowerStore.Extensions
{
    /// <summary>
    /// Extension for getting the user's id. 
    /// The method will be used frequently, so it should be an extension and will reduce code duplication.
    /// </summary>

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
