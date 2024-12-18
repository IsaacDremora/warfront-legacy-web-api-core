using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BuilderUnitController : ControllerBase
{
    private readonly AppDbContext _context;
    public BuilderUnitController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BuilderUnit>>> GetBuilderUnit()
    {
        return Ok(await _context.bldUnits.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BuilderUnit>> GetBldUnitById(int id)
    {
        return Ok(await _context.bldUnits.FirstOrDefaultAsync(d=> d.id == id));
    }

    [HttpPost]
    public async Task<ActionResult<BuilderUnit>> PostBldUnit(BuilderUnit unit)
    {
        await _context.bldUnits.AddAsync(unit);
        await _context.SaveChangesAsync();
        return Ok(unit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BuilderUnit>> PutBldUnit(int id, BuilderUnit newunit)
    {
        var oldUnit = await _context.bldUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (oldUnit is null) return NotFound();
        oldUnit.bldUnitSkinName = newunit.bldUnitSkinName;
        oldUnit.bldUnitSkinURL = newunit.bldUnitSkinURL;
        oldUnit.isFree = newunit.isFree;
        oldUnit.price = newunit.price;
        await _context.SaveChangesAsync();
        return Ok(newunit);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BuilderUnit>> DeleteBldUnit(int id)
    {
        var delUnit = await _context.bldUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (delUnit is null) return NotFound();
        _context.bldUnits.Remove(delUnit);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}