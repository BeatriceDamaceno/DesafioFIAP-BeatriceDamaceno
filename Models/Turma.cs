using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_FIAP___Beatrice_Damaceno.Models
{
    [Table("Turmas")]
    public class Turma
    {
        public Turma () { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurmaId { get; set; }

        [Required, DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres")]
        public string NomeTurma { get; set; }

        [Required,StringLength(100), DataType(DataType.MultilineText)]
        public string DescTurma { get; set; }

        [NotMapped]
        public int QtdAlunos { get; set; }
    }
}
