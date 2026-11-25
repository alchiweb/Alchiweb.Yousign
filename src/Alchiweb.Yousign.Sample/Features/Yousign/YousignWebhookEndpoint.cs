using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Alchiweb.Yousign.Sample.Core.Features.Yousign;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ArcaneWebhook.Server.Api.Features.Yousign;

public static class YousignWebhookEndpoint
{
    public static IEndpointRouteBuilder UseYousignWebHookEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("");

        group.MapPost("/yousign",
            async Task<Results<Ok, BadRequest, UnauthorizedHttpResult, InternalServerError>> (CancellationToken ct,
            [FromHeader(Name = "X-Yousign-Signature-256")] string expectedSignature,
            [FromServices] IYousignService yousignService,
            [FromServices] IConfiguration configuration,
            Stream body
            //HttpContext context
            //Payload payload
            ) =>
            {
                using StreamReader reader = new StreamReader(body, Encoding.UTF8);
                var bodyContent = await reader.ReadToEndAsync();
                var yousignSecretKey = configuration.GetSection("Yousign")?.GetValue<string>("webhookSecretKey");
                if (string.IsNullOrEmpty(yousignSecretKey))
                    return TypedResults.Unauthorized();
                string computedSignature = "sha256=" + GenerateSignature(bodyContent, yousignSecretKey);
                if (!computedSignature.Equals(expectedSignature))
                    return TypedResults.Unauthorized();
                var payload = JsonSerializer.Deserialize<Alchiweb.Yousign.Webhook.Payload>(bodyContent);
                if (payload == null)
                    return TypedResults.BadRequest();
                return await yousignService.GetYousignEvent(payload, ct) ? TypedResults.Ok() : TypedResults.InternalServerError();
            })
        .WithName("Yousign webhook");
        return builder;
    }

    public static string GenerateSignature(string message, string secret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        return Convert.ToHexString(hashBytes).ToLower(); // or use Base64
    }
}
