﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeekStore.Core.Data.Context;
using GeekStore.Pages.Produtos.Infraestrutura.Models;

namespace GeekStore.Pages.Produtos.Jogos
{
    public class EditModel : PageModel
    {
        private readonly GeekStore.Core.Data.Context.GeekStoreDbContext _context;

        public EditModel(GeekStore.Core.Data.Context.GeekStoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Infraestrutura.Models.Jogos Jogos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos =  await _context.Jogos.FirstOrDefaultAsync(m => m.Id == id);
            if (jogos == null)
            {
                return NotFound();
            }
            Jogos = jogos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jogos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogosExists(Jogos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Produtos/Index");
        }

        private bool JogosExists(Guid id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}
