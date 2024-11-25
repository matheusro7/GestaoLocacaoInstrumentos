using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public class LocacaoInstrumento
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public int InstrumentoId { get; set; }
        public Instrumento Instrumento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
