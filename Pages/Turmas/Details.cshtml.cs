using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Desafio_FIAP___Beatrice_Damaceno.Models;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Turmas
{
    public class DetailsModel : PageModel
    {
        private readonly Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext _context;

        public DetailsModel(Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext context)
        {
            _context = context;
        }

        public Turma Turma { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FirstOrDefaultAsync(m => m.TurmaId == id);

            if (turma is not null)
            {
                Turma = turma;

                return Page();
            }

            return NotFound();
        }
    }
}
