using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeekStore.Core.Data.Context;
using GeekStore.Pages.Produtos.Infraestrutura.Models;

namespace GeekStore.Pages.Produtos.Jogos
{
    public class IndexModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public IndexModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        public IList<Infraestrutura.Models.Jogos> Jogos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Jogos = await _context.Jogos.ToListAsync();
        }
    }
}
