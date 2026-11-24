using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification;

namespace Alchiweb.Yousign.Sample.Domain;

public class SignerByIdSpec : Specification<Signer>
{
    public SignerByIdSpec(Guid id, SignerWithEnum with)
    {
        switch (with)
        {
            case SignerWithEnum.Signature:
            case SignerWithEnum.All:
                Query
                    .Include(s => s.Signature);
                break;
            //case SignatureByIdWithEnum.None:
            default:
                break;
        }
        Query.Where(s => s.Id == id);

    }
}
