using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeekStore.Core.Data.Context;
using GeekStore.Pages.Produtos.Infraestrutura.Models;

namespace GeekStore.Pages.Produtos.ArtigosGeek
{
    public class DeleteModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public DeleteModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Infraestrutura.Models.Produtos Produtos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);

            if (produtos == null)
            {
                return NotFound();
            }
            else
            {
                Produtos = produtos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos != null)
            {
                Produtos = produtos;
                _context.Produtos.Remove(Produtos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
