using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GeekStore.Pages.Produtos.Acessorios
{
    public class DeleteModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public DeleteModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessorios = await _context.Acessorios.FindAsync(id);
            if (acessorios != null)
            {
                Acessorios = acessorios;
                _context.Acessorios.Remove(Acessorios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
