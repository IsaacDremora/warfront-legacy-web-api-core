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
}