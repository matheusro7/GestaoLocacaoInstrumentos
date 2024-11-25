using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public string SearchString { get; set; }
    }

}
