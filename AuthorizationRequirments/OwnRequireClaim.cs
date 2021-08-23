using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace beerOfThings.AuthorizationRequirments
{
    //Authorization Policy hold all requirments that need to be succeded
    // Authorization Request
    public class OwnRequireClaim : IAuthorizationRequirement
    {
        public string ClaimType { get; }

        public OwnRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }

    }

    //Handling authorization Request
    public class OwnRequireClaimHandler : AuthorizationHandler<OwnRequireClaim>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnRequireClaim requirement)
        {

            bool hasClaim = context.User.Claims.Any(claim => claim.Type == requirement.ClaimType);
            if (hasClaim)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
