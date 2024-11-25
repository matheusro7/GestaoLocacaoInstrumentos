using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public class Instrumento
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorAluguel { get; set; }
    }

}
