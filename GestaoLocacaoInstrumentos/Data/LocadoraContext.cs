using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Models;
using System.Collections.Generic;

namespace GestaoLocacaoInstrumentos.Data
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options)
        {
        }

        // Defina as DbSet para suas entidades
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Instrumento> Instrumentos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Conta> Contas { get; set; }

        // Adicione outros DbSets conforme necessário (Clientes, Agendamentos, etc)
    }
}
