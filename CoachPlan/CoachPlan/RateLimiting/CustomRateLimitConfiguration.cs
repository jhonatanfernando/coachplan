﻿using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace CoachPlan.RateLimiting;

public class CustomRateLimitConfiguration : RateLimitConfiguration
{
    public CustomRateLimitConfiguration(IOptions<IpRateLimitOptions> ipOptions, IOptions<ClientRateLimitOptions> clientOptions) : base(ipOptions, clientOptions)
    {
    }

    public override void RegisterResolvers()
    {
        base.RegisterResolvers();
        ClientResolvers.Add(new QueryStringClientIdResolveContributor());
    }
}

public class QueryStringClientIdResolveContributor : IClientResolveContributor
{
    public Task<string> ResolveClientAsync(HttpContext httpContext)
    {
        return Task.FromResult<string>(httpContext.Request.Query["X-ClientId"]);
    }
}
