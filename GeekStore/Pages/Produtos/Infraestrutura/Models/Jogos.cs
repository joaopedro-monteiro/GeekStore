using System.ComponentModel.DataAnnotations;

namespace GeekStore.Pages.Produtos.Infraestrutura.Models
{
    public class Jogos : Produtos
    {

        [StringLength(50, ErrorMessage = "A plataforma deve ter no máximo 50 caractéres")]
        public string? Plataforma { get; set; }


        public int PrazoDeGarantia { get; set; }
    }
}
