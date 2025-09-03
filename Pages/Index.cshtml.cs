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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Turma> Turma { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Turma = await _context.Turmas.ToListAsync();
        }
    }
}
