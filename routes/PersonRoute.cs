using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Person.Data;
using Person.Models;

namespace Person.route
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
          //  app.MapGet("person", () => new PersonModel("Deizi"));
          var route = app.MapGroup("person");
          route.MapPost("", async (PersonRequest req, PersonContext context) =>
          {
              //criando a instância de uma pessoa, passando o parâmetro construido na classe record (name)
              var person = new PersonModel(req.name);
              
              //utilizando recurso do context(Banco de dados)
              //Resumo: crie uma pessoa pra mim com o nome que eu passei e adicione ela dentro do context(Banco de dados)
              //OBS: isso não garante que ela (person) vai estar no banco de dados, até que seja feito o commit
              await context.AddAsync(person);
              
              //Fazendo o commit,
              //ele basicamente vai ao banco de dados, no sql server e faz o commit
              await context.SaveChangesAsync();
          });

        }  
        
    }
}