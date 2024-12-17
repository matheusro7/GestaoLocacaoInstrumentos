using System.ComponentModel.DataAnnotations;

namespace GestaoLocacaoInstrumentos.Models
{
    public class Sala
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int Capacidade { get; set; }

        [StringLength(100)]
        public string Localizacao { get; set; }

        public bool Disponivel { get; set; }

        [DataType(DataType.Currency)]
        public decimal ValorPorHora { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }
    }
}

