using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FlagController : ControllerBase
{
    private readonly AppDbContext _context;
    public FlagController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flag>>> GetAllFlags()
    {    
        return Ok(await _context.Flags.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Flag>> GetFlagById(int id)
    {
        var flag = await _context.Flags.FirstOrDefaultAsync(d => d.id == id);
        return flag is not null? Ok(flag) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Flag>> PostFlag(Flag _flag)
    {
        await _context.Flags.AddAsync(_flag);
        await _context.SaveChangesAsync();
        return Ok(_flag);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Flag>> PutFlag(Flag _newFlag, int id)
    {
        var _oldFlag = await _context.Flags.FirstOrDefaultAsync(d=> d.id == id);
        if (_oldFlag == null) return NotFound();
        _oldFlag.flagName = _newFlag.flagName;
        _oldFlag.imgURL = _newFlag.imgURL;
        _oldFlag.isFree = _newFlag.isFree;
        _oldFlag.price = _newFlag.price;
        await _context.SaveChangesAsync();
        return Ok(_newFlag);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFlag (int id)
    {
        var removeFlag = await _context.Flags.FirstOrDefaultAsync(d=> d.id == id);
        if (removeFlag is null) return NotFound();
        _context.Flags.Remove(removeFlag);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}