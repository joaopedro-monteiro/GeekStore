using GeekStore.Core.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Venda
{
    public class IndexModel(GeekStoreDbContext dbContext) : PageModel
    {
        private readonly GeekStoreDbContext _context = dbContext;

        public List<Models.Venda>? Vendas { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Vendas = await _context.Vendas.ToListAsync();

            return Page();
        }
    }
}
