using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_FIAP___Beatrice_Damaceno.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Alunos (Nome, CPF, Nascimento, Email, Senha)
            VALUES
            ('João Silva', '12345678901', '2000-05-15', 'joao.silva@email.com', HASHBYTES('SHA2_256', 'senha123')),
            ('Maria Santos', '98765432109', '1999-08-22', 'maria.santos@email.com', HASHBYTES('SHA2_256', 'mari@2024')),
            ('Pedro Oliveira', '45678912345', '2001-03-10', 'pedro.oliveira@email.com', HASHBYTES('SHA2_256', 'pedro123')),
            ('Ana Costa', '32165498701', '2002-11-30', 'ana.costa@email.com', HASHBYTES('SHA2_256', 'anaCosta!')),
            ('Carlos Pereira', '78912345678', '2000-07-18', 'carlos.pereira@email.com', HASHBYTES('SHA2_256', 'carlosP@ss')),
            ('Juliana Almeida', '65498732109', '2003-01-25', 'juliana.almeida@email.com', HASHBYTES('SHA2_256', 'juli@na2024')),
            ('Ricardo Souza', '23456789012', '1998-12-05', 'ricardo.souza@email.com', HASHBYTES('SHA2_256', 'ricardo98')),
            ('Fernanda Lima', '87654321098', '2001-09-14', 'fernanda.lima@email.com', HASHBYTES('SHA2_256', 'ferN@nda1')),
            ('Bruno Rodrigues', '34567890123', '2002-06-08', 'bruno.rodrigues@email.com', HASHBYTES('SHA2_256', 'brunoRod!')),
            ('Camila Ferreira', '76543210987', '2000-04-20', 'camila.ferreira@email.com', HASHBYTES('SHA2_256', 'camilaF3rr'));
            ");

            migrationBuilder.Sql(@"INSERT INTO Turmas(NomeTurma, DescTurma)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Alunos;");
            migrationBuilder.Sql(@"DELETE FROM Turmas;");
        }
    }
}
