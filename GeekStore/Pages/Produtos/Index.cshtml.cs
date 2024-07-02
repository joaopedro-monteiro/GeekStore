using GeekStore.Core.Data.Context;
using GeekStore.Pages.Produtos.Infraestrutura.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Produtos
{
    public class IndexModel(GeekStoreDbContext context) : PageModel
    {
        private readonly GeekStoreDbContext _context = context;

        public List<Infraestrutura.Models.Produtos>? Produtos { get; set; }
        public List<Infraestrutura.Models.Jogos>? Jogos { get; set; }
        public List<Infraestrutura.Models.Acessorios>? Acessorios { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Jogos = await _context.Jogos.AsNoTracking().Where(x => x.ProdutoCategoria == 0).ToListAsync();
            Acessorios = await _context.Acessorios.AsNoTracking().Where(x => x.ProdutoCategoria == (Categoria)1).ToListAsync();
            Produtos = await _context.Produtos.AsNoTracking().Where(x => x.ProdutoCategoria == (Categoria)2).ToListAsync();

            return Page();
        }
    }
}
