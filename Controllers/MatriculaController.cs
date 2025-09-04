using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio_FIAP___Beatrice_Damaceno.Models;

[Route("api/[controller]")]
[ApiController]
public class MatriculaController : ControllerBase
{
    private readonly AppDbContext _context;
    public MatriculaController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtém todas as matrículas cadastradas
    /// </summary>
    /// <returns>Lista de todas as matrículas</returns>
    /// <response code="200">Retorna a lista de matrículas</response>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
    {
        return await _context.Matriculas.ToListAsync();
    }

    /// <summary>
    /// Obtém uma matrícula específica pelo ID
    /// </summary>
    /// <param name="matriculaid">ID da matrícula</param>
    /// <returns>Dados da matrícula solicitada</returns>
    /// <response code="200">Retorna a matrícula encontrada</response>
    /// <response code="404">Matrícula não encontrada</response>
    [HttpGet("{matriculaid}")]
    public async Task<ActionResult<Matricula>> GetMatricula(int matriculaid)
    {
        var matricula = await _context.Matriculas.FindAsync(matriculaid);

        if (matricula == null)
        {
            return NotFound();
        }

        return matricula;
    }

    /// <summary>
    /// Atualiza os dados de uma matrícula existente
    /// </summary>
    /// <param name="matriculaid">ID da matrícula a ser atualizada</param>
    /// <param name="matricula">Objeto matrícula com os dados atualizados</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="204">Matrícula atualizada com sucesso</response>
    /// <response code="400">IDs não correspondem</response>
    /// <response code="404">Matrícula não encontrada</response>
    [HttpPut("{matriculaid}")]
    public async Task<IActionResult> PutMatricula(int? matriculaid, Matricula matricula)
    {
        if (matriculaid != matricula.MatriculaId)
        {
            return BadRequest();
        }

        _context.Entry(matricula).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MatriculaExists(matriculaid))
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
    /// Cria uma nova matrícula
    /// </summary>
    /// <param name="matricula">Objeto matrícula a ser criada</param>
    /// <returns>Dados da matrícula criada</returns>
    /// <response code="201">Matrícula criada com sucesso</response>
    /// <response code="400">Dados inválidos</response>
    [HttpPost]
    public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
    {
        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMatricula", new { matriculaid = matricula.MatriculaId }, matricula);
    }

    /// <summary>
    /// Exclui uma matrícula específica
    /// </summary>
    /// <param name="matriculaid">ID da matrícula a ser excluída</param>
    /// <returns>Resultado da operação</returns>
    /// <response code="204">Matrícula excluída com sucesso</response>
    /// <response code="404">Matrícula não encontrada</response>
    [HttpDelete("{matriculaid}")]
    public async Task<IActionResult> DeleteMatricula(int? matriculaid)
    {
        var matricula = await _context.Matriculas.FindAsync(matriculaid);
        if (matricula == null)
        {
            return NotFound();
        }

        _context.Matriculas.Remove(matricula);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MatriculaExists(int? matriculaid)
    {
        return _context.Matriculas.Any(e => e.MatriculaId == matriculaid);
    }
}
