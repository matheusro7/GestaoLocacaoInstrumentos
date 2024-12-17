using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
namespace GestaoLocacaoInstrumentos.Models;

    public class Agendamento
    {
        public int Id { get; set; }

        //[Required]
        public string Estudio { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime Data { get; set; }

        //[Required]
        //[DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        //[Required]
        //[DataType(DataType.Time)]
        public TimeSpan HoraFim { get; set; }

        //[Required]
        public string Cliente { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

}
