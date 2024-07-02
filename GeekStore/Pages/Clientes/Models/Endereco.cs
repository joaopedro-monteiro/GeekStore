using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Clientes.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }

        [MaxLength(8, ErrorMessage = "O CEP deve conter 8 dígitos"), MinLength(8)]
        [Required]
        public string? Cep { get; set; }

        [Required]
        public string? Estado { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Cidade { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Bairro { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Complemento { get; set; }

        [Required]
        public int Numero { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Rua { get; set; }
    }
}
