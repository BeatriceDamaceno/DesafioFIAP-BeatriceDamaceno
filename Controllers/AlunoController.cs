using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio_FIAP___Beatrice_Damaceno.Models;
using System.Security.Cryptography;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly AppDbContext _context;
    public AlunoController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtém todos os alunos cadastrados
    /// </summary>
    /// <returns>Lista de todos os alunos</returns>
    /// <response code="200">Retorna a lista de alunos</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
    {
        return await _context.Alunos.ToListAsync();
    }

    /// <summary>
    /// Obtém um aluno específico pelo ID
    /// </summary>
    /// <param name="alunoid">ID do aluno</param>
    /// <returns>Dados do aluno solicitado</returns>
    /// <response code="200">Retorna o aluno encontrado</response>
    /// <response code="404">Aluno não encontrado</response>
    [HttpGet("{alunoid}")]
    public async Task<ActionResult<Aluno>> GetAluno(int alunoid)
    {
        var aluno = await _context.Alunos.FindAsync(alunoid);

        if (aluno == null)
        {
            return NotFound();
        }
        
        return aluno;
    }

    /// <summary>
    /// Atualiza os dados de um aluno existente
    /// </summary>
    /// <param name="alunoid">ID do aluno a ser atualizado</param>
    /// <param name="aluno">Objeto aluno com os dados atualizados</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="204">Aluno atualizado com sucesso</response>
    /// <response code="400">IDs não correspondem</response>
    /// <response code="404">Aluno não encontrado</response>
    [HttpPut("{alunoid}")]
    public async Task<IActionResult> PutAluno(int? alunoid, Aluno aluno)
    {
        if (alunoid != aluno.AlunoId)
        {
            return BadRequest();
        }

        _context.Entry(aluno).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlunoExists(alunoid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    /// <summary>
    /// Cria um novo aluno
    /// </summary>
    /// <param name="aluno">Objeto aluno a ser criado</param>
    /// <returns>Dados do aluno criado</returns>
    /// <response code="201">Aluno criado com sucesso</response>
    /// <response code="400">Dados inválidos</response>
    [HttpPost]
    public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAluno", new { alunoid = aluno.AlunoId }, aluno);
    }

    /// <summary>
    /// Exclui um aluno específico
    /// </summary>
    /// <param name="alunoid">ID do aluno a ser excluído</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="204">Aluno excluído com sucesso</response>
    /// <response code="404">Aluno não encontrado</response>
    [HttpDelete("{alunoid}")]
    public async Task<IActionResult> DeleteAluno(int? alunoid)
    {
        var aluno = await _context.Alunos.FindAsync(alunoid);
        if (aluno == null)
        {
            return NotFound();
        }

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AlunoExists(int? alunoid)
    {
        return _context.Alunos.Any(e => e.AlunoId == alunoid);
    }
}
