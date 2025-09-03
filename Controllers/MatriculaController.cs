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

    // GET: api/Matricula
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
    {
        return await _context.Matriculas.ToListAsync();
    }

    // GET: api/Matricula/5
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

    // PUT: api/Matricula/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

    // POST: api/Matricula
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
    {
        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMatricula", new { matriculaid = matricula.MatriculaId }, matricula);
    }

    // DELETE: api/Matricula/5
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
