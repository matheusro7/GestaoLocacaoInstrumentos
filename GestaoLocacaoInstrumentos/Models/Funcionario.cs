namespace GestaoLocacaoInstrumentos.Models
{
    public enum CargoEnum
    {
        Gerente,
        Atendente,
        Técnico,
        Administrativo
    }
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public CargoEnum Cargo { get; set; }

    }
}

