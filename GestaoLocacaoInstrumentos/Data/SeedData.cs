using Microsoft.AspNetCore.Mvc;

using GestaoLocacaoInstrumentos.Models;
using GestaoLocacaoInstrumentos.Models.GestaoLocacaoInstrumentos.Models;

namespace GestaoLocacaoInstrumentos.Data
{
    public static class SeedData
    {
        public static void SeedFuncionarios(LocadoraContext context)
        {
            var funcionarios = new Funcionario[]
            {
                new Funcionario { Nome = "João Silva", Senha = "senha123", Cargo = CargoEnum.Gerente },
                new Funcionario { Nome = "Maria Santos", Senha = "senha456", Cargo = CargoEnum.Atendente }
            };
            context.Funcionarios.AddRange(funcionarios);
        }

        public static void SeedInstrumentos(LocadoraContext context)
        {
            var instrumentos = new Instrumento[]
            {
                new Instrumento { Nome = "Violão", Marca = "Yamaha", Modelo = "F310", ValorAluguel = 50, Descricao = "Violão acústico" },
                new Instrumento { Nome = "Teclado", Marca = "Casio", Modelo = "CT-X700", ValorAluguel = 70, Descricao = "Teclado portátil" }
            };
            context.Instrumentos.AddRange(instrumentos);
        }

        public static void SeedEstudios(LocadoraContext context)
        {
            var estudios = new Estudio[]
            {
                new Estudio { Nome = "Sala A", Capacidade = 5, Endereco = "Rua Principal, 123", Valor = 100 },
                new Estudio { Nome = "Sala B", Capacidade = 3, Endereco = "Rua Secundária, 456", Valor = 80 }
            };
            context.Estudios.AddRange(estudios);
        }
    }
}
