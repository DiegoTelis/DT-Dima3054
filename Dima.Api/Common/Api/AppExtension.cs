using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Dima.Api.Common.Api;

public static class AppExtension
{
    public static void ConfigureDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapSwagger().RequireAuthorization();
    }

    public static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        


        // ELE ESTA AGORA NO ENDPOINT - IDENTITY - GETROLESENDPOINT
        //app.MapGroup("v1/identity")
        //    .WithTags("Identity")
        //    .MapGet("/roles", (ClaimsPrincipal user) =>
        //    {
        //        if (user.Identity is null || !user.Identity.IsAuthenticated)
        //            return Results.Unauthorized();

        //        var identity = (ClaimsIdentity)user.Identity;

        //        var roles = identity.FindAll(identity.RoleClaimType)
        //        .Select(x => new
        //        {
        //            x.Issuer,
        //            x.OriginalIssuer,
        //            x.Type,
        //            x.Value,
        //            x.ValueType
        //        });

        //        return TypedResults.Json(roles);
        //    }).RequireAuthorization();

        /*  No acima pode estar usando o 
         *  (UserManager<User> userManager) => 
         * {
         *  var user = await userManager.FindByEmailAsync("email@aqui.com");
         * } --Assim vai consultar no banco... 
         */

    }


}
