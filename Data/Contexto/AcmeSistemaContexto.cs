using AcmeSistemaServidor.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcmeSistemaServidor.Data.Contexto
{
    public class AcmeSistemaContexto : DbContext
    {
        public AcmeSistemaContexto(DbContextOptions<AcmeSistemaContexto> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //cpf unico
            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.CPF)
                .IsUnique();

            //index Paciente.Nome
            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.Nome);

            //datetime with timezone (postgreSQL)
            modelBuilder.Entity<Tratamento>()
                .Property(t => t.Data)
                .HasColumnType("timestamp with time zone");
        }
    }
}
