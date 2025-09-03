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

    // GET: api/Turma
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
    {
        return await _context.Turmas.ToListAsync();
    }

    // GET: api/Turma/5
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

    // PUT: api/Turma/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

    // POST: api/Turma
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Turma>> PostTurma(Turma turma)
    {
        _context.Turmas.Add(turma);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTurma", new { turmaid = turma.TurmaId }, turma);
    }

    // DELETE: api/Turma/5
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
