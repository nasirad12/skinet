using System.Linq;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal User)
        {
            return User?.Claims?.FirstOrDefault( x=> x.Type == ClaimTypes.Email)?
            .Value;
        }
    }
}
