using Alchiweb.Yousign.Sample.Infrastructure;

namespace Microsoft.AspNetCore.Routing;

public static class RouteGroupBuilderExtensions
{
    public static RouteGroupBuilder RequireApiKeyAuthentication(
        this RouteGroupBuilder routeBuilder)
    {
        return routeBuilder.AddEndpointFilter<ApiKeyAuthenticationFilter>();
    }
}
