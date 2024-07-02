using System.Text.Json;
using GeekStore.Core.Data.Context;
using GeekStore.Pages.Produtos.Infraestrutura.Enum;
using GeekStore.Pages.Produtos.Infraestrutura.Models;
using GeekStore.Pages.Venda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Venda
{
    public class NovaVendaModel(GeekStoreDbContext context) : PageModel
    {
        private readonly GeekStoreDbContext _context = context;

        public Produtos.Infraestrutura.Models.Produtos? Produto { get; set; }

        [BindProperty]
        public Models.Venda? Venda { get; set; } = default!;

        [BindProperty] public static List<VendaInfo> CodigoDeBarrasInfo { get; set; } = [];
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            foreach (var line in CodigoDeBarrasInfo)
            {
                line.VendaId = Venda!.Id;
            }

            Venda!.StatusVenda = "Concluído";

            if (Venda == null) return Page();

            await _context.Vendas.AddAsync(Venda);
            await _context.VendasInfo.AddRangeAsync(CodigoDeBarrasInfo);

            await _context.SaveChangesAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetFetchCodBarrasDetails(string? codBarras)
        {
            Produto = await _context.Produtos.FirstOrDefaultAsync(x => x.CodBarras == codBarras);

            if (Produto == null)
            {
                return new JsonResult(new { detail = "Produto não encontrado." });
            }

            string produtoCategoria;

            switch (Produto.ProdutoCategoria)
            {
                case Categoria.Jogo:
                    produtoCategoria = "Jogo";
                    break;

                case Categoria.Acessório:
                    produtoCategoria = "Acessório";
                    break;

                case Categoria.ArtigoGeek:
                    produtoCategoria = "Artigo Geek";
                    break;

                default:
                    produtoCategoria = "Não encontrado";
                    break;
            }

            var produto = new
            {
                NomeDoProduto = Produto.NomeDoProduto,
                Preco = Produto.Valor,
                CodigoDeBarras = Produto.CodBarras,
                Quantidade = Produto.Quantidade,
                Categoria = produtoCategoria
            };

            var json = JsonSerializer.Serialize(produto);

            return Content(json, "application/json");
        }

        public void OnGetCodBarrasList(string codBarras, int quantidade)
        {
            Produto = _context.Produtos.FirstOrDefault(x => x.CodBarras == codBarras);

            CodigoDeBarrasInfo.Add(new VendaInfo { CodBarras = codBarras, Quantidade = quantidade, Valor = quantidade * Produto!.Valor });

        }
    }
}
