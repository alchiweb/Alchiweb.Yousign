using System.Security.Cryptography;
using System.Text;

namespace Alchiweb.Yousign.Sample.Infrastructure.Services;

public class CryptoService : ICryptoService
{
    private string? _apiKey;
    public CryptoService(IConfiguration configuration)
    {
        _apiKey = configuration.GetSection("Yousign")?.GetValue<string>("apiKey");
    }
    public (string signature, string timestamp) CreateSignature()
    {
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        string signature = CreateSignatureWithTimestamp(timestamp);
        return (signature, timestamp);
    }
    public bool IsSignatureValid(string signature, string timestamp)
    {
        if (string.IsNullOrWhiteSpace(signature) || string.IsNullOrWhiteSpace(timestamp))
            return false;
        var signatureComputed = CreateSignatureWithTimestamp(timestamp);
        return signatureComputed.Equals(signature);
    }

    private string CreateSignatureWithTimestamp(string timestamp)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes($"{timestamp}&{_apiKey}"));
        return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(timestamp)));
    }
}
