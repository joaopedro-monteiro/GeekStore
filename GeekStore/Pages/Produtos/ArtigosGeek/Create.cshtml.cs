using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeekStore.Core.Data.Context;
using GeekStore.Pages.Produtos.Infraestrutura.Enum;
using GeekStore.Pages.Produtos.Infraestrutura.Models;

namespace GeekStore.Pages.Produtos.ArtigosGeek
{
    public class CreateModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public CreateModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Infraestrutura.Models.Produtos Produtos { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Produtos.ProdutoCategoria = Categoria.ArtigoGeek;

            _context.Produtos.Add(Produtos);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
