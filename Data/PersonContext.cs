using Microsoft.EntityFrameworkCore;
using Person.Models;

namespace Person.Data
{
    public class PersonContext : DbContext
    {
        //Representação da tabela no Banco de Dados
        public DbSet<PersonModel> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=person.sqlite");
        }
    }
}