using Microsoft.AspNetCore.Authentication;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsLib
{
    public class ClaimsTransformIdentity : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var claiminfo = (ClaimsIdentity)principal.Identity;
            string[] Name = claiminfo.Name.Split("\\");
            var role = "user"; // Get User roles either from login identity or from DB. As of now Hardcoded
            var c = new Claim(claiminfo.RoleClaimType, role);
            claiminfo.AddClaim(c);
            return Task.FromResult(principal);
        }
    }
}
