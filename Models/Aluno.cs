using System.Collections.Generic;
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
        
        [StringLength(100), Required, DataType(DataType.Text)]
        public string Nome { get; set; }

        [StringLength (11), Required, DataType(DataType.Text)]
        [Index(nameof(CPF), IsUnique = true)]
        public string CPF { get; set; }
        
        [Required, DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [StringLength(60), Required, DataType(DataType.EmailAddress)]
        [Index(nameof(Email), IsUnique = true)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public byte[] Senha { get; set; }

    }
}
