using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly AppDbContext _context;
    public SessionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Session>>> GetAllSessions()
    {
        return Ok(await _context.Sessions.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Session>> GetSessionById(int id)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(d=> d.id == id);
        return session is not null? Ok(session) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Session>> PostSession(Session _session, int winnerId, int loserId)
    {
        var winnerPlayer = await _context.PlayerInf.FirstOrDefaultAsync(d=> d.id == winnerId);
        var loserPlayer = await _context.PlayerInf.FirstOrDefaultAsync(d=>d.id == loserId);
        if (winnerPlayer is null || loserPlayer is null) return NotFound();
        _session.sessionDateTime = DateTime.Now.ToUniversalTime();
        _session.winner = winnerPlayer;
        _session.loser = loserPlayer;
        await _context.Sessions.AddAsync(_session);
        await _context.SaveChangesAsync();
        return Ok(_session);
    }

    // [HttpPut("{id}")]
    // public async Task<ActionResult<Session>> PutSession(Session _session, int id)
    // {

    // }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Session>> DeleteSession(int id)
    {
        var deleteSession = await _context.Sessions.FirstOrDefaultAsync(d=> d.id == id);
        if (deleteSession is null) return NotFound();
        _context.Sessions.Remove(deleteSession);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}