using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Vouzamo.Grid.Web
{
    public static class Middleware
    {
        public static void UseGrid(this IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                if (IsGridRequest(context))
                {
                    context.Request.Path = new PathString("/index.html");
                }

                return next();
            });
        }

        private static bool IsGridRequest(HttpContext context)
        {
            return !context.Request.Path.Value.StartsWith("/api/") && !context.Request.Path.Value.StartsWith("/textures/");
        }
    }
}
