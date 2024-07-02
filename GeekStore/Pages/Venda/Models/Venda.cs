using System.ComponentModel.DataAnnotations;

namespace GeekStore.Pages.Venda.Models
{
    public class Venda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 dígitos")]
        public string? CpfDoCliente { get; set; }
        public DateTime DataDaVenda { get; set; } = DateTime.Now;

        [Required]
        [StringLength(60)]
        public string? TipoPagamento { get; set; }

        [Required]
        [StringLength(60)]
        public string? StatusPagamento { get; set; }

        [Required]
        [StringLength(60)]
        public string? StatusVenda { get; set; }
        public double TotalDaVenda { get; set; }
    }
}
