using GestaoLocacaoInstrumentos.Models;

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
                new Instrumento { Nome = "Cordofones", Marca = "Fender", Modelo = ModeloEnum.Cordas, ValorAluguel = 50, Descricao = "Contrabaixo" },
                new Instrumento { Nome = "Membrafones", Marca = "Gorilla", Modelo = ModeloEnum.Percussão, ValorAluguel = 70, Descricao = "Bumbo" }
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

        public static void SeedAgendamento(LocadoraContext context)
        {
            var agendamentos = new Agendamento[]
            {
            new Agendamento { Id = 1, Estudio = "Estudio A", Data = DateTime.Now.AddDays(1), HoraInicio = TimeSpan.FromHours(12), HoraFim = TimeSpan.FromHours(13), Cliente = "Cliente 1", Valor = 150.00M },
            new Agendamento { Id = 2, Estudio = "Estudio B", Data = DateTime.Now.AddDays(2), HoraInicio = TimeSpan.FromHours(16), HoraFim = TimeSpan.FromHours(18), Cliente = "Cliente 2", Valor = 200.00M },
            new Agendamento { Id = 3, Estudio = "Estudio A", Data = DateTime.Now.AddDays(3),HoraInicio = TimeSpan.FromHours(20), HoraFim = TimeSpan.FromHours(23), Cliente = "Cliente 13", Valor = 250.00M }
            };
            context.Agendamentos.AddRange(agendamentos);
        }
    }
}
