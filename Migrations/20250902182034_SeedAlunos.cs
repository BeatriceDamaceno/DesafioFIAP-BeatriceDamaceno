using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_FIAP___Beatrice_Damaceno.Migrations
{
    public partial class SeedAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Alunos (Nome, CPF, Nascimento, Email, Senha)
                VALUES
                ('João Silva', '12345678901', '2000-05-15', 'joao.silva@email.com', 'senha123'),
                ('Maria Santos', '98765432109', '1999-08-22', 'maria.santos@email.com', 'mari@2024'),
                ('Pedro Oliveira', '45678912345', '2001-03-10', 'pedro.oliveira@email.com', 'pedro123'),
                ('Ana Costa', '32165498701', '2002-11-30', 'ana.costa@email.com', 'anaCosta!'),
                ('Carlos Pereira', '78912345678', '2000-07-18', 'carlos.pereira@email.com', 'carlosP@ss'),
                ('Juliana Almeida', '65498732109', '2003-01-25', 'juliana.almeida@email.com', 'juli@na2024'),
                ('Ricardo Souza', '23456789012', '1998-12-05', 'ricardo.souza@email.com', 'ricardo98'),
                ('Fernanda Lima', '87654321098', '2001-09-14', 'fernanda.lima@email.com', 'ferN@nda1'),
                ('Bruno Rodrigues', '34567890123', '2002-06-08', 'bruno.rodrigues@email.com', 'brunoRod!'),
                ('Camila Ferreira', '76543210987', '2000-04-20', 'camila.ferreira@email.com', 'camilaF3rr');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Alunos WHERE CPF IN('12345678901'," +
                                                                "'98765432109', " +
                                                                "'45678912345', " +
                                                                "'32165498701', " +
                                                                "'78912345678', " +
                                                                "'65498732109', " +
                                                                "'23456789012', " +
                                                                "'87654321098', " +
                                                                "'34567890123', " +
                                                                "'76543210987') ");
        }
    }
}
