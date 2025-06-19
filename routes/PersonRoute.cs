using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.route
{
    public static class PersonRoute
    {
        public static void RegisterRoutes(WebApplication app)
        {
            app.MapGet("/", () => Results.Redirect("/Person"));
        }
        
    }
}