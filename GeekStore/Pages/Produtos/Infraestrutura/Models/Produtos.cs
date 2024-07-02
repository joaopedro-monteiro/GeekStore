using GeekStore.Pages.Produtos.Infraestrutura.Enum;
using System.ComponentModel.DataAnnotations;

namespace GeekStore.Pages.Produtos.Infraestrutura.Models
{
    public class Produtos
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string? CodBarras { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O produto deve ter no máximo 100 caractéres")]
        public string? NomeDoProduto { get; set; }

        [Required]
        public Categoria ProdutoCategoria { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "O fabricante deve ter no máximo 70 caractéres")]
        public string? Fabricante { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double Valor { get; set; }
    }
}
