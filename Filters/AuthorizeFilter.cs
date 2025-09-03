using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Desafio_FIAP___Beatrice_Damaceno.Filters
{
    public class AuthorizeFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            // Get the page model type
            var pageType = context.HandlerInstance?.GetType();

            // Check for AllowAnonymous at the class level
            var allowAnonymous = pageType?.GetCustomAttribute<AllowAnonymousAttribute>() != null;

            if (allowAnonymous)
            {
                await next();
                return;
            }

            // Check if user is authenticated
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Don't redirect if we're already on the login page to prevent loops
                var currentPath = context.HttpContext.Request.Path;
                if (!currentPath.Value.Contains("/Admin/Login", StringComparison.OrdinalIgnoreCase))
                {
                    context.Result = new RedirectToPageResult("/Admin/Login");
                    return;
                }
            }

            await next();
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;
    }
}
