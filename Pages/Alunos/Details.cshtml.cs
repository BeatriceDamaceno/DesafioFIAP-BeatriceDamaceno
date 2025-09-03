using Desafio_FIAP___Beatrice_Damaceno.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Alunos
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext _context;

        public DetailsModel(Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext context)
        {
            _context = context;
        }

        public Aluno Aluno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.AlunoId == id);

            if (aluno is not null)
            {
                Aluno = aluno;

                return Page();
            }

            return NotFound();
        }
    }
}
