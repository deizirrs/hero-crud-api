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

              var person = new PersonModel(req.name);
              await context.AddAsync(person);
              await context.SaveChangesAsync();
          });

              route.MapGet("", async (PersonContext context) =>
              {
                  var people = await context.People.ToListAsync();
                  return Results.Ok(people);
              });

              route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
              {
                  //Usando o FirstOrDefaultAsync para ele evita que a aplicação gere um execeção, caso não tenha o id no banco de dados.
                  //OBS: Pode se usar também o FindAsync(id), passando somente o id e sem a necessidade de utilizar a expressão lambda.
                  var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

                  if (person == null)
                      return Results.NotFound();
                  
                  person.ChangeName(req.name);
                  await context.SaveChangesAsync();

                  return Results.Ok();
              });

              
            // Ao invés de excluir os dados da Person por completo (Hard Delete), vamos utilizar o Soft Delete, alterando o nome para "DESATIVADO" sem remover o registro do sistema.
              route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
              {
                  var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

                  if (person == null)
                      return Results.NotFound();
                  
                  person.SetInactive();
                  await context.SaveChangesAsync();

                  return Results.Ok();
              });
        }  
        
    }
}