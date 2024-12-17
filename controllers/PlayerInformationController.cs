using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/api/[controller]")]
public class PlayerInformationController : ControllerBase
{
    private readonly AppDbContext _context;
    public PlayerInformationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerInformation>>> GetPInf()
    {
        return Ok(await _context.PlayerInf.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerInformation>> GetPInfById(int id)
    {
        var pInf = await _context.PlayerInf.FirstOrDefaultAsync(d=> d.id == id);
        if (pInf is null) return NotFound();
        return Ok(pInf);
    }

    [HttpPost]
    public async Task<ActionResult<PlayerInformation>> PostPInf(PlayerInformation pinf)
    {
        await _context.PlayerInf.AddAsync(pinf);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlayerInformation>> PutPInf(int id, PlayerInformation newPinf)
    {
        var oldPinf = await _context.PlayerInf.FirstOrDefaultAsync(d=> d.id == id);
        if (oldPinf is null) return NotFound();
        oldPinf.email = newPinf.email;
        oldPinf.birthDate = newPinf.birthDate;
        oldPinf.flagAttribute = newPinf.flagAttribute;
        oldPinf.registrationDate = newPinf.registrationDate;
        oldPinf.warriorUnitAttribute = newPinf.warriorUnitAttribute;
        await _context.SaveChangesAsync();
        return Ok(newPinf);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlayerInformation>> DeletePInf(int id)
    {
        var delPInf = await _context.PlayerInf.FirstOrDefaultAsync(d=> d.id == id);
        if (delPInf is null) return NotFound();
        _context.PlayerInf.Remove(delPInf);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}