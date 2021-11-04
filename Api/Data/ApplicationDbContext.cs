using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AgendamentoEntityTypeConfiguration().Configure(modelBuilder.Entity<Agendamento>());
            base.OnModelCreating(modelBuilder);
        }
    }
}