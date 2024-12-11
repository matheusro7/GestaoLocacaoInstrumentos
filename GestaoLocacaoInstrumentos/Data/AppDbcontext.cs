using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Models;

namespace GestaoLocacaoInstrumentos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Instrumento> Instrumentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais
            modelBuilder.Entity<Instrumento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Modelo).HasMaxLength(50);
                entity.Property(e => e.Marca).HasMaxLength(50);
                entity.Property(e => e.Descricao).HasMaxLength(500);
                entity.Property(e => e.ValorAluguel).HasColumnType("decimal(18,2)");
            });
        }
    }
}
