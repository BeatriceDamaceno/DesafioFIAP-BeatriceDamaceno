using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio_FIAP___Beatrice_Damaceno.Models;

[Route("api/[controller]")]
[ApiController]
public class TurmaController : ControllerBase
{
    private readonly AppDbContext _context;
    public TurmaController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtém todas as turmas cadastradas
    /// </summary>
    /// <returns>Lista de todas as turmas</returns>
    /// <response code="200">Retorna a lista de turmas</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
    {
        return await _context.Turmas.ToListAsync();
    }

    /// <summary>
    /// Obtém uma turma específica pelo ID
    /// </summary>
    /// <param name="turmaid">ID da turma</param>
    /// <returns>Dados da turma solicitada</returns>
    /// <response code="200">Retorna a turma encontrada</response>
    /// <response code="404">Turma não encontrada</response>
    [HttpGet("{turmaid}")]
    public async Task<ActionResult<Turma>> GetTurma(int turmaid)
    {
        var turma = await _context.Turmas.FindAsync(turmaid);

        if (turma == null)
        {
            return NotFound();
        }

        return turma;
    }

    /// <summary>
    /// Atualiza os dados de uma turma existente
    /// </summary>
    /// <param name="turmaid">ID da turma a ser atualizada</param>
    /// <param name="turma">Objeto turma com os dados atualizados</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="204">Turma atualizada com sucesso</response>
    /// <response code="400">IDs não correspondem</response>
    /// <response code="404">Turma não encontrada</response>
    [HttpPut("{turmaid}")]
    public async Task<IActionResult> PutTurma(int? turmaid, Turma turma)
    {
        if (turmaid != turma.TurmaId)
        {
            return BadRequest();
        }

        _context.Entry(turma).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TurmaExists(turmaid))
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
    /// Cria uma nova turma
    /// </summary>
    /// <param name="turma">Objeto turma a ser criada</param>
    /// <returns>Dados da turma criada</returns>
    /// <response code="201">Turma criada com sucesso</response>
    /// <response code="400">Dados inválidos</response>
    [HttpPost]
    public async Task<ActionResult<Turma>> PostTurma(Turma turma)
    {
        _context.Turmas.Add(turma);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTurma", new { turmaid = turma.TurmaId }, turma);
    }

    /// <summary>
    /// Exclui uma turma específica
    /// </summary>
    /// <param name="turmaid">ID da turma a ser excluída</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="204">Turma excluída com sucesso</response>
    /// <response code="404">Turma não encontrada</response>
    [HttpDelete("{turmaid}")]
    public async Task<IActionResult> DeleteTurma(int? turmaid)
    {
        var turma = await _context.Turmas.FindAsync(turmaid);
        if (turma == null)
        {
            return NotFound();
        }

        _context.Turmas.Remove(turma);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TurmaExists(int? turmaid)
    {
        return _context.Turmas.Any(e => e.TurmaId == turmaid);
    }
}
