using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public enum ModeloEnum
    {
        Cordas,
        Eletrônico,
        Percussão,
        Sporo,
        Teclado,
        Outros
    }
    public class Instrumento
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorAluguel { get; set; }
        public ModeloEnum Modelo { get; set; }
    }

}
