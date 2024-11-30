using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace GestaoLocacaoInstrumentos.Models
    {
        public class Agendamento
        {
            public int Id { get; set; }

            [Required]
            public int SalaId { get; set; }

            [ForeignKey("SalaId")]
            public Sala Sala { get; set; }

            [Required]
            public int UsuarioId { get; set; }

            [ForeignKey("UsuarioId")]
            public Usuario Usuario { get; set; }

            [Required]
            public DateTime DataAgendamento { get; set; }

            [Required]
            public TimeSpan HoraInicio { get; set; }

            [Required]
            public TimeSpan HoraFim { get; set; }

            [StringLength(200)]
            public string Observacoes { get; set; }
        }
    }

}
