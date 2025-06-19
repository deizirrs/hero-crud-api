using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Person.routes.Models;

namespace Person.route
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            app.MapGet("person", () => new PersonModel("Deizi"));

        }  
        
    }
}