using Microsoft.AspNetCore.Mvc;

using GestaoLocacaoInstrumentos.Models;
using System.Linq;


namespace GestaoLocacaoInstrumentos.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LocadoraContext context)
        {
            context.Database.EnsureCreated(); // Garante que o banco está criado
            // Verifica se já existem funcionários no banco
            if (context.Funcionarios.Any())
            {
                return;
            }

            var funcionarios = new Funcionario[]
            {
                new Funcionario { Nome = "João Silva", Senha = "senha123", Cargo = CargoEnum.Gerente },
                new Funcionario { Nome = "Maria Santos", Senha = "senha456", Cargo = CargoEnum.Atendente }
            };

            context.Funcionarios.AddRange(funcionarios);
            context.SaveChanges();
        }
    }
}

