using System.Net;
using OpenShiftDemoApp.Services;

namespace OpenShiftDemoApp.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IEndpointRouteBuilder MapMetaEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/_id", (AppInfoProvider provider)
            => TypedResults.Ok(new { AppId = provider.Id }));

        routeBuilder.MapGet("/_env", (AppInfoProvider provider)
            => TypedResults.Ok(new { provider.Environment }));

        routeBuilder.MapGet("/_root-path", (AppInfoProvider provider)
            => TypedResults.Ok(new { provider.AppRootPath }));

        routeBuilder.MapGet("/_hostname", ()
            => TypedResults.Ok(new { HostName = Dns.GetHostName() }));

        return routeBuilder;
    }
}