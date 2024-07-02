using GeekStore.Pages.Produtos.Infraestrutura.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages.Produtos.Acessorios
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
        public Infraestrutura.Models.Acessorios Acessorios { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Acessorios.ProdutoCategoria = Categoria.Acessório;

            _context.Acessorios.Add(Acessorios);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
