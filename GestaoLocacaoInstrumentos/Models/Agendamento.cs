namespace GestaoLocacaoInstrumentos.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

 
        public string Estudio { get; set; }


        public DateTime Data { get; set; }

 
        public TimeSpan HoraInicio { get; set; }


        public TimeSpan HoraFim { get; set; }


        public string Cliente { get; set; }

        public decimal Valor { get; set; }



    }

}