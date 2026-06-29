#nullable enable
using Grand.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Grand.Domain.Stores;
using Grand.Infrastructure.Configuration;
using System.Text.RegularExpressions;

namespace Grand.Web.Common.Middleware;

public class CustomerAndStoreRouteRestrictionMiddleware
{
    #region Fields

    private readonly RequestDelegate _next;

    private readonly List<Regex> _skipPatterns = new() {
        new Regex("^/$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex("^/admin(/.*)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex("^/install/?$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex("^/register-store/?$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex("^/page-not-found/?$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex("^/access-denied/?$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
        new Regex("^/storeclosed/?$", RegexOptions.Compiled | RegexOptions.IgnoreCase),
    };

    private readonly List<string> _restrictedStoreHosts = [
        "localhost",
        "admin.store.localhost",
    ];

    #endregion

    #region Ctor

    /// <summary>
    ///     Ctor
    /// </summary>
    /// <param name="next">Next</param>
    /// <param name="appConfig">AppConfig</param>
    public CustomerAndStoreRouteRestrictionMiddleware(RequestDelegate next, AppConfig appConfig)
    {
        _restrictedStoreHosts = _restrictedStoreHosts.Concat(appConfig.CustomerAndStoreRoutesRestrictedHosts).ToList();
        _next = next;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Invoke middleware actions
    /// </summary>
    /// <param name="context">HTTP context</param>
    /// <param name="contextAccessor">contextAccessor</param>
    /// <returns>Task</returns>
    public async Task InvokeAsync(HttpContext context, IContextAccessor contextAccessor)
    {
        if (context?.Request == null) return;

        var path = context.Request.Path.Value ?? "/";

        // Check if the current path matches any of our regex rules
        var isRestrictedHost = IsRestrictedStore(contextAccessor.StoreContext.CurrentStore);
        var isMatched = _skipPatterns.Any(regex => regex.IsMatch(path));
        if (isRestrictedHost && !isMatched)
        {
            var linkGenerator = context.RequestServices.GetRequiredService<LinkGenerator>();

            var redirectUrl = linkGenerator.GetPathByAction(
                action: "PageNotFound",
                controller: "Common",
                values: new { statusCode = 404 }
            );
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.Redirect(redirectUrl ?? "/page-not-found");
        }
        
   
        await _next(context);
    }

    private bool IsRestrictedStore(Store? currentStore)
    {
        if (currentStore == null)
        {
            return true;
        }
        
        return _restrictedStoreHosts.Any(allowedHost =>
            currentStore.Domains.Any(storeDomain => storeDomain.HostName.Equals(allowedHost)));
    }

    #endregion
}