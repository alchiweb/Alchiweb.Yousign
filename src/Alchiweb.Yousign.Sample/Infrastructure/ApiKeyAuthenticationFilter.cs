using Alchiweb.Yousign.Sample.Infrastructure.Services;

namespace Alchiweb.Yousign.Sample.Infrastructure;

public class ApiKeyAuthenticationFilter : IEndpointFilter
{
    protected readonly ICryptoService _cryptoService;

    public ApiKeyAuthenticationFilter(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }


    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        string signature = context.HttpContext.Request.Headers[ICryptoService.SIGNATURE_HEADER].FirstOrDefault() ?? "";
        string timestamp = context.HttpContext.Request.Headers[ICryptoService.TIMESTAMP_HEADER].FirstOrDefault() ?? "";

        _cryptoService.IsSignatureValid(signature, timestamp);

        if (!_cryptoService.IsSignatureValid(signature, timestamp))
            return TypedResults.Unauthorized();

        return await next(context);
    }
}
