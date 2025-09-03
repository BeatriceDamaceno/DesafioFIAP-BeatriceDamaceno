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

    // GET: api/Aluno
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
    {
        return await _context.Alunos.ToListAsync();
    }

    /*
    // GET: api/Aluno/5
    [HttpGet]
    public async Task<ActionResult<Aluno>> GetUser(string email, string password)
    {
        if (_context.Alunos == null)
        {
            return NoContent();
        }

        string encPassword = Encrypt(password);
        string decPassword;

        foreach (Aluno a in _context.Alunos.Where(c => c.Email == email))
        {
            decPassword = a.Senha;

            if (decPassword == password)
            {
                return a;
            }
        }

        return Problem("Wrong email or password!");
    }
    */

    // GET: api/Aluno/5
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

    // PUT: api/Aluno/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

    // POST: api/Aluno
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAluno", new { alunoid = aluno.AlunoId }, aluno);
    }

    // DELETE: api/Aluno/5
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
