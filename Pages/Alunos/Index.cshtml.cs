using Desafio_FIAP___Beatrice_Damaceno.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Alunos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public AlunoPaginated<Aluno> Alunos { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string BuscaString { get; set; }

        public async Task OnGetAsync(int? pageIndex, string buscaString)
        {
            buscaString = buscaString ?? string.Empty;

            int pageSize = 10;
            
            IQueryable<Aluno> alunosQuery = from a in _context.Alunos select a;

            if (!string.IsNullOrWhiteSpace(buscaString))
            {
                alunosQuery = alunosQuery.Where(a => a.Nome.Contains(buscaString));
            }

            alunosQuery = alunosQuery.OrderBy(a => a.Nome);

            Alunos = await AlunoPaginated<Aluno>.CreateAsync(alunosQuery.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
