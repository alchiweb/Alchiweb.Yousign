using System;
using System.Collections.Generic;
using System.Text;
using AlchiwebApp.Core.Interfaces;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public interface ISignatureService :
    IApiServiceList<SignatureDto, Guid, SignatureDtoFilter, SignatureDtoWithEnum>,
    IApiServiceGet<SignatureDto, Guid, SignatureDtoWithEnum>,
    IApiServiceCreate<SignatureDto, Guid, SignatureRequest>,
    IApiServiceUpdate<SignatureDto, Guid, SignatureRequest>,
    IApiServiceDelete<SignatureDto, Guid>,
    IApiService<SignatureDto, Guid>
{
}
