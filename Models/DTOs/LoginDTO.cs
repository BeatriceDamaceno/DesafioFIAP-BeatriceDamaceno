using System.ComponentModel.DataAnnotations;

namespace Desafio_FIAP___Beatrice_Damaceno.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Login é Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Senha é Obrigatória")]
        public string Senha { get; set; }
    }
}
