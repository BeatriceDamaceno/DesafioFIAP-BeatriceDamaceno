using Desafio_FIAP___Beatrice_Damaceno.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Alunos
{
    [Authorize]
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
        public Aluno Aluno { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Aluno.Senha = HashPassword(Aluno.Senha);

            _context.Alunos.Add(Aluno);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private string HashPassword(string password)
        { 
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
