using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Produtos.Acessorios
{
    public class DetailsModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public DetailsModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        public Infraestrutura.Models.Acessorios Acessorios { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorios = await _context.Acessorios.FirstOrDefaultAsync(m => m.Id == id);
            if (acessorios == null)
            {
                return NotFound();
            }
            else
            {
                Acessorios = acessorios;
            }
            return Page();
        }
    }
}
