using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_FIAP___Beatrice_Damaceno.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Alunos ADD CONSTRAINT UQ_Email UNIQUE (Email)");
            migrationBuilder.Sql(@"ALTER TABLE Alunos ADD CONSTRAINT UQ_CPF UNIQUE (CPF)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
