using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("/api/[controller]")]
public class WarriorUnitController : ControllerBase
{
    private readonly AppDbContext _context;
    public WarriorUnitController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WarriorUnit>>> GetWUnits()
    {
        return Ok(await _context.WarriorUnits.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WarriorUnit>> GetWUnitById(int id)
    {
        var wunit= await _context.WarriorUnits.FirstOrDefaultAsync(d=>d.id == id);
        return wunit is not null? Ok(wunit) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<WarriorUnit>> PostWUnit(WarriorUnit unit)
    {
        await _context.WarriorUnits.AddAsync(unit);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<WarriorUnit>> PutWUnit(WarriorUnit unit, int id)
    {
        var oldUnit = await _context.WarriorUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (oldUnit is null) return NotFound();
        oldUnit.isFree = unit.isFree;
        oldUnit.price = unit.price;
        oldUnit.warrioirUnitSkinName = unit.warrioirUnitSkinName;
        oldUnit.warriorUnitSkinURL = unit.warriorUnitSkinURL;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<WarriorUnit>> DeleteWUnit(int id)
    {
        var delwunit = await _context.WarriorUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (delwunit is null) return NotFound();
        _context.WarriorUnits.Remove(delwunit);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}