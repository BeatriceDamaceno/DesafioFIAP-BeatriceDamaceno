using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_FIAP___Beatrice_Damaceno.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public Aluno() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlunoId { get; set; }
        
        [Required, DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres")]
        public string Nome { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos"), Required, DataType(DataType.Text)]
        [RegularExpression(@"^\d+$", ErrorMessage = "CPF deve conter apenas números")]
        [Index(nameof(CPF), IsUnique = true)]
        public string CPF { get; set; }
        
        [Required, DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "O email deve ter pelo menos 4 caracteres")]
        [Index(nameof(Email), IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma minúscula, um número e um caractere especial")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
