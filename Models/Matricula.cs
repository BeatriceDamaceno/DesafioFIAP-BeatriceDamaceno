using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_FIAP___Beatrice_Damaceno.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatriculaId { get; set; }

        [Required, ForeignKey("Alunos")]
        public int AlunoId { get; set; }

        [Required, ForeignKey("Turmas")]
        public int TurmaId { get; set; }

    }
}
