using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Models;
using System.Collections.Generic;
using GestaoLocacaoInstrumentos.Models.GestaoLocacaoInstrumentos.Models;
using System.Reflection.Emit;
using Agendamento = GestaoLocacaoInstrumentos.Models.Agendamento;

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
        new Estudio
        {
            Id = 1, Nome = "Estúdio A", Capacidade = 5, Valor = 50m, Descricao = "Ar condicionado, frigobar e sofá", Endereco = "Tv"

        },
        new Estudio
        {
            Id = 2, Nome = "Estúdio B", Capacidade = 10, Valor = 100m, Descricao = "Apenas ar condicionado", Endereco = "TV"
        }
    );

            
        }
        

        }
    }



