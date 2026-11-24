using AlchiwebApp.Core;
using AlchiwebApp.PagingFiltering.Paging;
using AlchiwebApp.Server.Core;
using Alchiweb.Yousign.Sample.Core.Features.Yousign;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ArcaneWebhook.Server.Api.Features.Yousign;

public static class SignatureApiEndpoint
{
    public static IEndpointRouteBuilder UseSignatureApiEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/signature");
        #region Standard (CRUD methods)

        group.MapGet("",
            async Task<Results<Ok<ApiResponse<PagedList<SignatureDto>>>, NotFound, InternalServerError>> (CancellationToken ct,
                [FromServices] ISignatureService apiService,
                SignatureDtoFilter filter,
                SignatureDtoWithEnum with
                ) => await RouteHelper.GetListGeneric<ISignatureService, SignatureDto, SignatureDtoFilter, SignatureDtoWithEnum>(ct, apiService, filter, with))
            //.RequireAuthorization(AppFeatures.Business.ReadSignatures)
            .WithSummary("Get list of Signatures")
            .WithDescription("Get list of Signatures");

        group.MapGet("{id}",
            async Task<Results<Ok<ApiResponse<SignatureDto>>, NotFound, InternalServerError>> (CancellationToken ct,
                [FromServices] ISignatureService apiService,
                Guid id,
                SignatureDtoWithEnum with
                ) => await RouteHelper.GetByIdGeneric<ISignatureService, SignatureDto, SignatureDtoWithEnum>(ct, apiService, id, with))
            //.RequireAuthorization(AppFeatures.Business.ReadSignatures)
            .WithSummary("Get a Signature by Id")
            .WithDescription("Get a Signature by Id");

        //group.MapPost("",
        //    async Task<Results<Ok<ApiResponse<SignatureDto>>, NotFound, InternalServerError>> (CancellationToken ct,
        //        [FromServices] ISignatureService apiService,
        //        SignatureRequest request
        //        ) => await RouteHelper.CreateGeneric<ISignatureService, SignatureDto, SignatureRequest>(ct, apiService, request))
        //    //.RequireAuthorization(AppFeatures.Business.ManageSignatures)
        //    .WithSummary("Create a new Signature")
        //    .WithDescription("Creates a new Signature");

        //group.MapPut("",
        //    async Task<Results<Ok<ApiResponse<SignatureDto>>, NotFound, InternalServerError>> (CancellationToken ct,
        //        [FromServices] ISignatureService apiService,
        //        SignatureRequest request
        //        ) => await RouteHelper.UpdateGeneric<ISignatureService, SignatureDto, SignatureRequest>(ct, apiService, request))
        //    //.RequireAuthorization(AppFeatures.Business.ManageSignatures)
        //    .WithSummary("Update a Signature")
        //    .WithDescription("Update a Signature");

        //group.MapDelete("{id}",
        //    async Task<Results<Ok<ApiResponse>, NotFound, InternalServerError>> (CancellationToken ct,
        //        [FromServices] ISignatureService apiService,
        //        Guid id
        //        ) => await RouteHelper.DeleteGeneric<ISignatureService, SignatureDto>(ct, apiService, id))
        //    //.RequireAuthorization(AppFeatures.Business.ManageSignatures)
        //    .WithSummary("Delete a Signature")
        //    .WithDescription("Delete a Signature");

        #endregion
        return builder;
    }
}
