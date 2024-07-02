using GeekStore.Core.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages.Clientes
{
    public class CreateModel(GeekStoreDbContext context) : PageModel
    {
        private readonly GeekStoreDbContext _context = context;

        [BindProperty]
        public Models.Clientes? Model { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Model!.Endereco!.Id = Model.EnderecoId;

            _context.Clientes.Add(Model!);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
