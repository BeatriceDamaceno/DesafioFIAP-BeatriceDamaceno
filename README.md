# Desafio FIAP - Beatrice Damaceno
**Uma API RESTful simples para gerenciamento de alunos, turmas e matrículas, desenvolvida em .NET com Swagger para documentação interativa.**

# Funcionalidades
* Alunos: CRUD completo de alunos
* Turmas: CRUD completo de turmas
* Matrículas: CRUD completo de matrículas (relacionamento alunos-turmas)
* Documentação Interativa: Swagger UI integrado

# Como Executar
##  Pré-requisitos
* Windows 7/8/10/11

* .NET Runtime 6.0 ou superior

# Passo a Passo
* Acesse a página de releases do projeto
* Baixe o arquivo 'Desafio FIAP - Beatrice Damaceno.zip'
* Extraia o arquivo em uma pasta de sua preferência
* Execute 'Desafio FIAP - Beatrice Damaceno.exe'
* Abra seu navegador e acesse: http://localhost:5000
* Você será levado a uma página de Login. para autenticar, utilize o email 'admin@email.com' e a senha 'Admin!123123'
* Depois disso, você pode usar o botão na tela inicial para acessar o Swagger, ou usar os botões Alunos e Turmas para visualizar cadastros e realizar matrículas.

# Considerações
* Ao executar o projeto, as Migrations serão rodadas automaticamente, gerando um banco de dados local "SecretariaFIAP", criando as tabelas adequadas e as populando com dados mockados. Portanto, o script para geração desse banco não será necessário. 

# Endpoints Disponíveis
## Alunos
* GET /api/Aluno - Lista todos os alunos
* GET /api/Aluno/{id} - Obtém um aluno específico
* POST /api/Aluno - Cria um novo aluno
* PUT /api/Aluno/{id} - Atualiza um aluno existente
* DELETE /api/Aluno/{id} - Exclui um aluno

# Turmas
* GET /api/Turma - Lista todas as turmas
* GET /api/Turma/{id} - Obtém uma turma específica
* POST /api/Turma - Cria uma nova turma
* PUT /api/Turma/{id} - Atualiza uma turma existente
* DELETE /api/Turma/{id} - Exclui uma turma

# Matrículas
* GET /api/Matricula - Lista todas as matrículas
* GET /api/Matricula/{id} - Obtém uma matrícula específica
* POST /api/Matricula - Cria uma nova matrícula
* PUT /api/Matricula/{id} - Atualiza uma matrícula existente
* DELETE /api/Matricula/{id} - Exclui uma matrícula

🛠️ Tecnologias Utilizadas
* .NET 9.0
* Entity Framework Core
* Swagger
* SQL Server
