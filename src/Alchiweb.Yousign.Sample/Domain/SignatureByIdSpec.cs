using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification;

namespace Alchiweb.Yousign.Sample.Domain;

public class SignatureByIdSpec : Specification<Signature>
{
    public SignatureByIdSpec(Guid id, SignatureWithEnum with)
    {
        switch (with)
        {
            case SignatureWithEnum.All:
                Query
                    .Include(s => s.Approvers)
                    .Include(s => s.Signers)
                    .Include(s => s.Documents);
                break;
            case SignatureWithEnum.Approvers:
                Query
                    .Include(s => s.Approvers);
                break;
            case SignatureWithEnum.Documents:
                Query
                    .Include(s => s.Documents);
                break;
            case SignatureWithEnum.Signers:
                Query
                    .Include(s => s.Signers);
                break;

            //case SignatureByIdWithEnum.None:
            default:
                break;
        }
        Query.Where(s => s.Id == id);

    }
}
