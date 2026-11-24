namespace Alchiweb.Yousign.Sample.Infrastructure.Services;

public interface ICryptoService
{
    public const string SIGNATURE_HEADER = "X-Signature";
    public const string TIMESTAMP_HEADER = "X-Timestamp";
    public (string signature, string timestamp) CreateSignature();
    public bool IsSignatureValid(string signature, string timestamp);
}
