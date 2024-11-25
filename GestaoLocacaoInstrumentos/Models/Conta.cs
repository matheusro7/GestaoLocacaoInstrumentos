using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int NenhumInstrumentoEmprestado { get; set; }
        public int NenhumaReservaInstrumento { get; set; }
        public int NenhumInstrumentoDevolvido { get; set; }
        public int InstrumentoSemRetorno { get; set; }
        public decimal ValorMulta { get; set; }
    }
}
