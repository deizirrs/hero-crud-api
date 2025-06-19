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
            // Configure your database connection string here
            optionsBuilder.UseSqlite("Data Source=person.sqlite");
        }
    }
}