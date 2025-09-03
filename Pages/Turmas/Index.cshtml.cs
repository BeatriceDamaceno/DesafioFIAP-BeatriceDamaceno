using Desafio_FIAP___Beatrice_Damaceno.Models;
using Desafio_FIAP___Beatrice_Damaceno.Pages.Alunos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Turmas
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public TurmaPaginated<Turma> Turmas { get;set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            int pageSize = 10;
            IQueryable<Turma> turmasQuery = from t in _context.Turmas select t;

            Turmas = await TurmaPaginated<Turma>.CreateAsync(turmasQuery.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
