using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_FIAP___Beatrice_Damaceno.Migrations
{
    /// <inheritdoc />
    public partial class PaginationSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Alunos (Nome, CPF, Nascimento, Email, Senha)
            VALUES
            ('Amanda Rocha', '11122233344', '2001-02-14', 'amanda.rocha@email.com', HASHBYTES('SHA2_256', 'amandaR@123')),
            ('Diego Martins', '22233344455', '1999-11-08', 'diego.martins@email.com', HASHBYTES('SHA2_256', 'diegoM!99')),
            ('Larissa Nunes', '33344455566', '2002-07-23', 'larissa.nunes@email.com', HASHBYTES('SHA2_256', 'lar!ssa202')),
            ('Rafael Costa', '44455566677', '2000-12-30', 'rafael.costa@email.com', HASHBYTES('SHA2_256', 'rafaC0sta#')),
            ('Tatiane Silva', '55566677788', '2003-04-17', 'tatiane.silva@email.com', HASHBYTES('SHA2_256', 'tatiSilv@3')),
            ('Vinícius Oliveira', '66677788899', '2001-09-05', 'vinicius.oliveira@email.com', HASHBYTES('SHA2_256', 'viniOli09!')),
            ('Patrícia Santos', '77788899900', '2002-01-19', 'patricia.santos@email.com', HASHBYTES('SHA2_256', 'patSantos22')),
            ('Gabriel Lima', '88899900011', '2000-06-12', 'gabriel.lima@email.com', HASHBYTES('SHA2_256', 'gabL1ma@00')),
            ('Carolina Alves', '99900011122', '2003-03-28', 'carolina.alves@email.com', HASHBYTES('SHA2_256', 'carolAlv3s')),
            ('Marcos Pereira', '00011122233', '1998-08-15', 'marcos.pereira@email.com', HASHBYTES('SHA2_256', 'marcosP98@')),
            ('Isabela Rodrigues', '11223344556', '2002-10-22', 'isabela.rodrigues@email.com', HASHBYTES('SHA2_256', 'isaRod2022')),
            ('Thiago Souza', '22334455667', '2001-05-07', 'thiago.souza@email.com', HASHBYTES('SHA2_256', 'thiagoS#21')),
            ('Jéssica Ferreira', '33445566778', '2003-07-14', 'jessica.ferreira@email.com', HASHBYTES('SHA2_256', 'jessFerr@03')),
            ('Leonardo Barbosa', '44556677889', '2000-03-03', 'leonardo.barbosa@email.com', HASHBYTES('SHA2_256', 'leoBarb2000')),
            ('Vanessa Cardoso', '55667788990', '2002-12-09', 'vanessa.cardoso@email.com', HASHBYTES('SHA2_256', 'vanaCard@02'));
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
