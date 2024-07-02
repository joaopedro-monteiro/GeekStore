using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Produtos.Acessorios
{
    public class IndexModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public IndexModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        public IList<Infraestrutura.Models.Acessorios> Acessorios { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Acessorios = await _context.Acessorios.ToListAsync();
        }
    }
}
