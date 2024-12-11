using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GestaoLocacaoInstrumentos.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
