using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Desafio_FIAP___Beatrice_Damaceno.Models;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Alunos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public AlunoPaginated<Aluno> Alunos { get;set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            int pageSize = 10;
            IQueryable<Aluno> alunosQuery = from a in _context.Alunos select a;

            Alunos = await AlunoPaginated<Aluno>.CreateAsync(alunosQuery.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
