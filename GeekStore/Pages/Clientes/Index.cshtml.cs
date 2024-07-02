using GeekStore.Core.Data.Context;
using GeekStore.Pages.Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace GeekStore.Pages.Clientes
{
    public class IndexModel(GeekStoreDbContext context) : PageModel
    {
        private readonly GeekStoreDbContext _context = context;

        [BindProperty]
        public IQueryable<Models.Clientes>? Clientes { get; set; }

        public void OnGet()
        {
            Clientes = _context.Clientes.Join(_context.Endereco,
                 cliente => cliente.EnderecoId,
                 endereco => endereco.Id,
                 (cliente, endereco) => new Models.Clientes()
                 {
                     Id = cliente.Id,
                     Nome = cliente.Nome,
                     Cpf = cliente.Cpf,
                     Rg = cliente.Rg,
                     DataDoCadastro = cliente.DataDoCadastro,
                     Telefone = cliente.Telefone,
                     Email = cliente.Email,
                     EnderecoId = cliente.EnderecoId,
                     Endereco = new Endereco
                     {
                         Id = endereco.Id,
                         Rua = endereco.Rua,
                         Numero = endereco.Numero,
                         Bairro = endereco.Bairro,
                         Complemento = endereco.Complemento,
                         Cidade = endereco.Cidade,
                         Estado = endereco.Estado,
                         Cep = endereco.Cep
                     }
                 }).AsNoTracking();
        }
    }
}
