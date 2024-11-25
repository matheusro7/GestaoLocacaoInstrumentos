using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public class Estudio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string Endereco { get; set; }
        public decimal Valor { get; set; }
    }

}
