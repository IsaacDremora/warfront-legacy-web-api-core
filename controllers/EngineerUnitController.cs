using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/[controller]")]
public class EngineerUnitController : ControllerBase
{
    private readonly AppDbContext _context;
    public EngineerUnitController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EngineerUnit>>> GetEngUnit()
    {
        return Ok(await _context.engUnits.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EngineerUnit>> GetEngUnitById(int id)
    {
        var unit = await _context.engUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (unit is null) return NotFound();
        return Ok(unit);
    }

    [HttpPost]
    public async Task<ActionResult<EngineerUnit>> PostEngUnit(EngineerUnit unit)
    {
        await _context.engUnits.AddAsync(unit);
        await _context.SaveChangesAsync();
        return Ok(unit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EngineerUnit>> PutEngUnit(int id, EngineerUnit newunit)
    {
        var oldUnit = await _context.engUnits.FirstOrDefaultAsync(d=> d.id == id);
        if (oldUnit is null) return NotFound();
        oldUnit.engUnitSkinName = newunit.engUnitSkinName;
        oldUnit.engUnitSkinURL = newunit.engUnitSkinURL;
        oldUnit.isFree = newunit.isFree;
        oldUnit.price = newunit.price;
        await _context.SaveChangesAsync();
        return Ok(newunit);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<EngineerUnit>> DelEngUnit(int id)
    {
       var delUnit = await _context.engUnits.FirstOrDefaultAsync(d=> d.id == id);
       if (delUnit is null) return NotFound();
       _context.engUnits.Remove(delUnit);
       await _context.SaveChangesAsync();
       return NoContent();
    }
}