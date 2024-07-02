using System.ComponentModel.DataAnnotations;

namespace GeekStore.Pages.Venda.Models
{
    public class VendaInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid VendaId { get; set; }
        [Required]
        [StringLength(50)]
        public string? CodBarras { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
