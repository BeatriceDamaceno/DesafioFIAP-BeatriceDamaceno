using Desafio_FIAP___Beatrice_Damaceno.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Turmas
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Turma Turma { get; set; } = default!;
        public List<Aluno> AlunosMatriculados { get; set; }
        public List<SelectListItem> AlunosDisponiveis { get; set; }

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

                await CarregarAlunos(id.Value);
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAddAlunoAsync(int turmaId, int alunoId)
        {
            var existing = await _context.Matriculas.FirstOrDefaultAsync(m => m.TurmaId.Equals(turmaId) && m.AlunoId.Equals(alunoId));

            if (existing is null)
            {
                var matricula = new Matricula
                {
                    TurmaId = turmaId,
                    AlunoId = alunoId
                };

                _context.Add(matricula);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Details", new { id = turmaId });
        }

        public async Task<IActionResult> OnPostRemoveAlunoAsync(int turmaId, int alunoId)
        {
            var matricula = await _context.Matriculas.FirstOrDefaultAsync(m => m.TurmaId.Equals(turmaId) && m.AlunoId.Equals(alunoId));

            if (matricula is not null)
            {
                _context.Remove(matricula);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Details", new { id = turmaId });
        }

        public async Task CarregarAlunos(int turmaId)
        {
            var matriculas = await _context.Matriculas
            .Where(m => m.TurmaId == turmaId)
            .ToListAsync();

            var alunosMatriculadosIds = matriculas.Select(a => a.AlunoId).ToList();

            if (alunosMatriculadosIds.Any())
            {
                AlunosMatriculados = await _context.Alunos
                    .Where(a => alunosMatriculadosIds.Contains(a.AlunoId))
                    .OrderBy(a => a.Nome)
                    .ToListAsync();
            }

            var alunos = await _context.Alunos.ToListAsync();

            AlunosDisponiveis = [.. alunos.Where(a => !alunosMatriculadosIds.Contains(a.AlunoId)).Select(a => new SelectListItem
            {
                Value = a.AlunoId.ToString(),
                Text = $"{a.Nome} - {a.Email}"
            })];

            AlunosDisponiveis = AlunosDisponiveis.OrderBy(a => a.Text).ToList();
        }
    }
}
