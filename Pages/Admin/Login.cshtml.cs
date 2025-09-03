using Desafio_FIAP___Beatrice_Damaceno.Models.DTOs;
using Desafio_FIAP___Beatrice_Damaceno.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Admin
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly AuthService _authService;

        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

        public LoginModel(AuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _authService.LoginAsync(LoginDTO.Login, LoginDTO.Senha);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, "Login ou senha invalidos");
                return Page();
            }

            // Store token in cookie or session
            Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddHours(1)
            });

            return RedirectToPage("/Index");
        }
    }
}
