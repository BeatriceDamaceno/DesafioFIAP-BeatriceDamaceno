using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Desafio_FIAP___Beatrice_Damaceno.Models;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages
{
    public class EditModel : PageModel
    {
        private readonly Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext _context;

        public EditModel(Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Turma Turma { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma =  await _context.Turmas.FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }
            Turma = turma;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(Turma.TurmaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}
