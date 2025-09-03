using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Desafio_FIAP___Beatrice_Damaceno.Models;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext _context;

        public CreateModel(Desafio_FIAP___Beatrice_Damaceno.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Turma Turma { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Turmas.Add(Turma);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
