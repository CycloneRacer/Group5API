using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group5API.Models;

[Route("api/[controller]")]
[ApiController]
public class TeamMembersController : ControllerBase
{
    private readonly Group5APIContext _context;
    public TeamMembersController(Group5APIContext context)
    {
        _context = context;
    }

    //Need To Replace Below Functions. 11/19/2026 - KJR

    [HttpGet]
    public IActionResult GetTeamMembers()
    {
        return Ok(_context.TeamMember.ToList());
    }

    [HttpPost]
    public IActionResult PostTeamMember(TeamMember teammember)
    {
        _context.TeamMember.Add(teammember);
        _context.SaveChanges();
        return Ok("Team Member Added Successfully");
    }

    [HttpGet("{id}")]
    public IActionResult GetTeamMember(int id)
    {
        var student = _context.TeamMember.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTeamMember(int id)
    {
        var student = _context.TeamMember.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        _context.TeamMember.Remove(student);
        _context.SaveChanges();
        return Ok("Team Member Deleted Successfully");
    }

    [HttpPut]
    public IActionResult PutStudent(TeamMember teammember)
    {
        var t = _context.TeamMember.Find(teammember.Id);
        if (teammember == null)
        {
            return NotFound();
        }
        else
        {
            t.Name = teammember.Name;
            t.Email = teammember.Email;
            t.Major = teammember.Major;
            t.Year = teammember.Year;
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Team Member Updated Successfully");
        }
    }
}

//Old Code for Reference - 11/24/2026 KJR
/*

// GET: api/TeamMember
[HttpGet]
public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMember()
{
    return await _context.TeamMember.ToListAsync();
}


// GET: api/TeamMember/5
[HttpGet("{id}")]
public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
{
    var teammember = await _context.TeamMember.FindAsync(id);

    if (teammember == null)
    {
        return NotFound();
    }

    return teammember;
}

// PUT: api/TeamMember/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
public async Task<IActionResult> PutTeamMember(int? id, TeamMember teammember)
{
    if (id != teammember.Id)
    {
        return BadRequest();
    }

    _context.Entry(teammember).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!TeamMemberExists(id))
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

// POST: api/TeamMember
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPost]
public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teammember)
{
    _context.TeamMember.Add(teammember);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetTeamMember", new { id = teammember.Id }, teammember);
}

// DELETE: api/TeamMember/5
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteTeamMember(int? id)
{
    var teammember = await _context.TeamMember.FindAsync(id);
    if (teammember == null)
    {
        return NotFound();
    }

    _context.TeamMember.Remove(teammember);
    await _context.SaveChangesAsync();

    return NoContent();
}

private bool TeamMemberExists(int? id)
{
    return _context.TeamMember.Any(e => e.Id == id);
}
}

*/