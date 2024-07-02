using GeekStore.Core.Data.Context;
using GeekStore.Pages.Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages.Clientes
{
    public class UpdateModel(GeekStoreDbContext context) : PageModel
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

        public IActionResult OnPost(Guid id, Guid enderecoId, Models.Clientes model)
        {
            model.Id = id;
            model.EnderecoId = enderecoId;
            model!.Endereco!.Id = enderecoId;

            _context.Clientes.Update(model);
            _context.SaveChanges();

            return RedirectToPage("/Clientes/Index");
        }
    }
}
