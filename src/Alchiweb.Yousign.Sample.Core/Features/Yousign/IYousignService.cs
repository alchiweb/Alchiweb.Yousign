using System;
using System.Collections.Generic;
using System.Text;
using AlchiwebApp.Core.Interfaces;
using Alchiweb.Yousign.Sample.Core.Features.Yousign.Enums;

namespace Alchiweb.Yousign.Sample.Core.Features.Yousign;

public interface IYousignService
{
    public Task<bool> GetYousignEvent(Alchiweb.Yousign.Webhook.Payload payload, CancellationToken ct = default);
}
