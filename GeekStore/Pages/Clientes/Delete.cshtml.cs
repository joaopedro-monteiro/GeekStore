using GeekStore.Core.Data.Context;
using GeekStore.Pages.Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages.Clientes
{
    public class DeleteModel(GeekStoreDbContext context) : PageModel
    {
        private readonly GeekStoreDbContext _context = context;

        public Models.Clientes? Model { get; set; }
        public Endereco? Endereco { get; set; }
        public async Task<IActionResult> OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Model = await _context.Clientes.FindAsync(id);
            Endereco = await _context.Endereco.FindAsync(Model!.EnderecoId);

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid? id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            var endereco = await _context.Endereco.FindAsync(cliente!.EnderecoId);

            _context.Clientes.Remove(cliente);
            _context.Endereco.Remove(endereco!);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Clientes/Index");
        }
    }
}
