using System.ComponentModel.DataAnnotations;

namespace GeekStore.Pages.Clientes.Models
{
    public class Clientes
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(50), MinLength(2)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string? Cpf { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "O RG deve ter exatamente 10 dígitos.")]
        public string? Rg { get; set; }
        public DateTime DataDoCadastro { get; set; } = DateTime.Now;
        public Guid EnderecoId { get; set; } = Guid.NewGuid();
        [Required]
        public Endereco? Endereco { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Telefone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
