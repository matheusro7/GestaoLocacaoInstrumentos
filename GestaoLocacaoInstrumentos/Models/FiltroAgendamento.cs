using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public class FiltroAgendamento
    {
        //[Required]
        public string Estudio { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime Data { get; set; }

        //[Required]
        public string Cliente { get; set; }
    }
}
