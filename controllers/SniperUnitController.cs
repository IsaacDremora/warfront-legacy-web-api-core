using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/[controller]")]
public class SniperUnitController : ControllerBase
{
    private readonly AppDbContext _context;
    public SniperUnitController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SniperUnit>>> GetSniperUnit()
    {
        return Ok(await _context.SniperUnits.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SniperUnit>> GetSniperUnitById(int id)
    {
        var sUnit = await _context.SniperUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (sUnit is null) return NotFound();
        return Ok(sUnit);
    }

    [HttpPost]
    public async Task<ActionResult<SniperUnit>> PostSniperUnit(SniperUnit unit)
    {
        await _context.SniperUnits.AddAsync(unit);
        await _context.SaveChangesAsync();
        return Ok(unit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SniperUnit>> PutSniperUnit(int id, SniperUnit newUnit)
    {
        var oldUnit = await _context.SniperUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (oldUnit is null) return NotFound();
        oldUnit.isFree = newUnit.isFree;
        oldUnit.price = newUnit.price;
        oldUnit.sniperUnitSkinName = newUnit.sniperUnitSkinName;
        oldUnit.sniperUnitSkinURL = newUnit.sniperUnitSkinURL;
        await _context.SaveChangesAsync();
        return Ok(newUnit);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SniperUnit>> DeleteSniperUnit(int id)
    {
        var delUnit = await _context.SniperUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (delUnit is null) return NotFound();
        _context.SniperUnits.Remove(delUnit);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}