using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group5API.Models;

[Route("api/[controller]")]
[ApiController]
public class SnacksController : ControllerBase
{
    private readonly Group5APIContext _context;
    public SnacksController(Group5APIContext context)
    {
        _context = context;
    }

    // GET: api/Snacks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Snacks>>> GetSnacks()
    {
        return await _context.Snacks.ToListAsync();
    }

    // GET: api/Snacks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Snacks>> GetSnacks(int id)
    {
        var snacks = await _context.Snacks.FindAsync(id);

        if (snacks == null)
        {
            return NotFound();
        }

        return snacks;
    }

    // PUT: api/Snacks/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSnacks(int? id, Snacks snacks)
    {
        if (id != snacks.ID)
        {
            return BadRequest();
        }

        _context.Entry(snacks).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SnacksExists(id))
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

    // POST: api/Snacks
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Snacks>> PostSnacks(Snacks snacks)
    {
        _context.Snacks.Add(snacks);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSnacks", new { id = snacks.ID }, snacks);
    }

    // DELETE: api/Snacks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSnacks(int? id)
    {
        var snacks = await _context.Snacks.FindAsync(id);
        if (snacks == null)
        {
            return NotFound();
        }

        _context.Snacks.Remove(snacks);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SnacksExists(int? id)
    {
        return _context.Snacks.Any(e => e.ID == id);
    }
}
