using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Desafio_FIAP___Beatrice_Damaceno.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null;
        public virtual DbSet<Turma> Turmas { get; set; } = null;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SecretariaFIAP;Integrated Security=True");
        }
    }
}
