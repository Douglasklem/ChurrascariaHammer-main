using Churrascaria.Data.Configuration;
using Churrascaria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Churrascaria.Data.Context
{
    public class ChurrascariaContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB;Initial Catalog=Churrascaria;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConvidadoConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipanteConfiguration());
        }
    }
}
