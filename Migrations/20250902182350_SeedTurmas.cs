using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_FIAP___Beatrice_Damaceno.Migrations
{
    public partial class SeedTurmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO Turmas (NomeTurma, DescTurma)
            VALUES
            ('Programação Básica', 'Curso introdutório de programação para iniciantes, abordando lógica e algoritmos'),
            ('Banco de Dados SQL', 'Fundamentos de bancos de dados relacionais e linguagem SQL'),
            ('Desenvolvimento Web', 'Curso completo de desenvolvimento web com HTML, CSS, JavaScript e frameworks'),
            ('C# e .NET Core', 'Desenvolvimento de aplicações com C# e .NET Core framework'),
            ('Python para Data Science', 'Uso de Python para análise de dados, machine learning e visualização'),
            ('JavaScript Avançado', 'Técnicas avançadas de JavaScript e desenvolvimento front-end moderno'),
            ('Mobile com Flutter', 'Desenvolvimento de aplicativos mobile multiplataforma com Flutter'),
            ('DevOps Essentials', 'Introdução às práticas de DevOps, CI/CD e ferramentas de automação'),
            ('UI/UX Design', 'Princípios de design de interface e experiência do usuário para aplicações'),
            ('Segurança da Informação', 'Conceitos fundamentais de segurança e proteção de dados em sistemas');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Turmas WHERE TurmaId <= 10");
        }
    }
}
