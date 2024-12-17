using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Models;

namespace GestaoLocacaoInstrumentos.Data
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Instrumento> Instrumentos { get; set; }
        public DbSet<LocacaoInstrumento> Locacoes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasData(
                new Funcionario { Id = 1, Nome = "João Silva", Senha = "senha123", Cargo = CargoEnum.Gerente },
                new Funcionario { Id = 2, Nome = "Maria Santos", Senha = "senha456", Cargo = CargoEnum.Atendente }
            );
            modelBuilder.Entity<Estudio>().HasData(
                new Estudio { Id = 1, Nome = "Estúdio A", Capacidade = 5, Valor = 50m, Descricao = "Ar condicionado, frigobar e sofá", Endereco = "Tv" },
                new Estudio { Id = 2, Nome = "Estúdio B", Capacidade = 10, Valor = 100m, Descricao = "Apenas ar condicionado", Endereco = "TV" }
            );
            modelBuilder.Entity<Agendamento>().HasData(
                new Agendamento { Id = 1, Estudio = "Estudio A", Data = DateTime.Now.AddDays(1), HoraInicio = TimeSpan.FromHours(12), HoraFim = TimeSpan.FromHours(13), Cliente = "Cliente 1", Valor = 150.00M },
                new Agendamento { Id = 2, Estudio = "Estudio B", Data = DateTime.Now.AddDays(2), HoraInicio = TimeSpan.FromHours(16), HoraFim = TimeSpan.FromHours(18), Cliente = "Cliente 2", Valor = 200.00M },
                new Agendamento { Id = 3, Estudio = "Estudio A", Data = DateTime.Now.AddDays(3), HoraInicio = TimeSpan.FromHours(20), HoraFim = TimeSpan.FromHours(23), Cliente = "Cliente 13", Valor = 250.00M }
            );

            modelBuilder.Entity<Instrumento>().HasData(
                new Instrumento { Id = 1, Nome = "Violão", Marca = "Yamaha", Modelo = ModeloEnum.Corda, ValorAluguel = 50, Descricao = "Violão acústico" },
                new Instrumento { Id = 2, Nome = "Teclado", Marca = "Casio", Modelo = ModeloEnum.Percussao, ValorAluguel = 70, Descricao = "Tarro" }
            );


            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nome = "João Silva", Senha = "senha123", Email = "mail@mail" },
                new Cliente { Id = 2, Nome = "Maria Santos", Senha = "senha456", Email = "mails@mails" }
            );
        }


    }
 }




