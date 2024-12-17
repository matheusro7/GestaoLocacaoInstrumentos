using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Drawing;



namespace GestaoLocacaoInstrumentos.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LocadoraContext context)
        {
            context.Database.EnsureCreated();

            if (context.Funcionarios.Any())
            {
                return;
            }

            var funcionarios = new Funcionario[]
            {
                new Funcionario { Nome = "João Silva", Senha = "senha123", Cargo = CargoEnum.Gerente },
                new Funcionario { Nome = "Maria Santos", Senha = "senha456", Cargo = CargoEnum.Atendente }
            };

            var estudios = new Estudio[]
                {
                new Estudio { Id = 1, Nome = "Estúdio A", Capacidade = 5, Valor = 50m, Descricao = "Ar condicionado, frigobar e sofá", Endereco = "Tv" },
                new Estudio { Id = 2, Nome = "Estúdio B", Capacidade = 10, Valor = 100m, Descricao = "Ar condicionado e sofá", Endereco = "Tv" }
                };

            context.Funcionarios.AddRange(funcionarios);
            context.Estudios.AddRange(estudios);
            context.SaveChanges();
        }
            };
        }

