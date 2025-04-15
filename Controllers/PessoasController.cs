using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCrud.Data;
using ApiCrud.Models;

namespace ApiCrud.Controllers
{
    /// <summary>
    /// Retorna todos os Pessoas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoasController(AppDbContext context)
        {
            _context = context;
        }
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var Pessoa = await _context.Pessoas.FindAsync(id);
            if (Pessoa == null) return NotFound();
            return Pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(Pessoa Pessoa)
        {
            _context.Pessoas.Add(Pessoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPessoa), new { id = Pessoa.Id }, Pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, Pessoa Pessoa)
        {
            if (id != Pessoa.Id) return BadRequest();
            _context.Entry(Pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var Pessoa = await _context.Pessoas.FindAsync(id);
            if (Pessoa == null) return NotFound();
            _context.Pessoas.Remove(Pessoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
