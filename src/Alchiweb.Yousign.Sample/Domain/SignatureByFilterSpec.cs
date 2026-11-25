using Alchiweb.Yousign.Sample.Domain.Enums;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore.SharedKernel.Extensions;
namespace Alchiweb.Yousign.Sample.Domain;

public class SignatureByFilterSpec : Specification<Signature>
{
    public SignatureByFilterSpec(SignatureFilter filter, SignatureWithEnum with)
    {
        if (with == SignatureWithEnum.All || with == SignatureWithEnum.Signers || filter.SearchSignerStatusFilters.Length > 0)
        {
            Query
                .Include(s => s.Signers);

        }
        if (with == SignatureWithEnum.All || with == SignatureWithEnum.Approvers || filter.SearchApproverFilters.Length > 0 || filter.SearchApproverStatusFilters.Length > 0)
        {
            Query
                .Include(s => s.Approvers.Where(a => filter.SearchApproverFilters.Length == 0
                || (!string.IsNullOrEmpty(a.Email) && a.Email.Contains(filter.SearchApproverFilters[0].SearchValue))
                || (!string.IsNullOrEmpty(a.FirstName) && a.FirstName.Contains(filter.SearchApproverFilters[0].SearchValue))
                || (!string.IsNullOrEmpty(a.LastName) && a.LastName.Contains(filter.SearchApproverFilters[0].SearchValue))
                ));
        }
        if (with == SignatureWithEnum.All || with == SignatureWithEnum.Documents)
        {
            Query
                .Include(s => s.Documents);
        }

        this.ApplyFiltering(filter.DomainFilters, SignatureFieldEnum.Domain, false);
        this.ApplyFiltering(filter.NameFilters, SignatureFieldEnum.Name, false);
        this.ApplyFiltering(filter.SenderEmailFilters, SignatureFieldEnum.SenderEmail, false);
        this.ApplyFiltering(filter.StatusFilters, SignatureFieldEnum.SignatureStatus, false);
        this.ApplyFiltering(filter.LastEventDateFilters, SignatureFieldEnum.LastEventDate, false);
        this.ApplyFiltering(filter.DoneDateFilters, SignatureFieldEnum.DoneDate, false);

        if (filter.SortBy.Count == 0)
        {
            filter.SortBy.Add(SignatureFieldEnum.Id, new());
        }
        this.ApplySorting(filter);
    }
}
