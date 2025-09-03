using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_FIAP___Beatrice_Damaceno.Migrations
{
    /// <inheritdoc />
    public partial class AdminSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Admins (Login, Senha) VALUES ('admin@email.com', HASHBYTES('SHA2_256', 'Admin!123123'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
