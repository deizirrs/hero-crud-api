using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Models;

namespace Person.route
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
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

              route.MapGet("", async (PersonContext context) =>
              {
                  var people = await context.People.ToListAsync();
                  return Results.Ok(people);
              });

              route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
              {
                  //Usando o FirstOrDefaultAsync porque ele evita que a aplicação gere um execeção, caso não tenha o id no banco de dados.
                  //OBS: Pode se usar também o FindAsync(id), passando somente o id e sem a necessidade de utilizar a expressão lambda
                  var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

                  if (person == null)
                      return Results.NotFound();
                  
                  person.ChangeName(req.name);
                  await context.SaveChangesAsync();

                  return Results.Ok();
              });
        }  
        
    }
}