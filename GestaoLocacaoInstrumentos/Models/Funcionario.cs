using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Models;

    namespace GestaoLocacaoInstrumentos.Models
    {
        public enum CargoEnum
        {
            Gerente,
            Atendente,
            Tecnico,
            Administrativo
        }

        public class Funcionario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Senha { get; set; }
            public CargoEnum Cargo { get; set; }
            //public string Disponivel { get; set; }
            //public bool Disponivel { get; set; } = true; // Valor padrão

        }
    }

