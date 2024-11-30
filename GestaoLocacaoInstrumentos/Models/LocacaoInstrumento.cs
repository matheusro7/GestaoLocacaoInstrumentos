using GestaoLocacaoInstrumentos.Models.GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoLocacaoInstrumentos.Models
{
    public class LocacaoInstrumento
    {
        public int Id { get; set; }

        [Required]
        public int InstrumentoId { get; set; }

        [ForeignKey("InstrumentoId")]
        public Instrumento Instrumento { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime DataLocacao { get; set; }

        public DateTime? DataDevolucao { get; set; }

        [Required]
        public int SalaId { get; set; } // Nova propriedade para associar uma sala

        [ForeignKey("SalaId")]
        public Sala Sala { get; set; } // Relação com a entidade Sala
    }
}

