
using Microsoft.EntityFrameworkCore;

public class WarriorUnitService : IWarriorUnitService
{
    private readonly AppDbContext _context;
    public WarriorUnitService(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddWarUnitAtUser(int _userId, int _warUnitId)
    {
        var user = await _context.PlayerInf.FirstOrDefaultAsync(d=>d.id == _userId);
        var warUnit = await _context.WarriorUnits.FirstOrDefaultAsync(d=>d.id == _warUnitId);
        if(user is null || warUnit is null) throw new Exception("user or warUnit is not found");
        user.warriorUnitAttribute?.Add(warUnit);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveWarUnitAtUser(int _userId, int _warUnitId)
    {
        var user = await _context.PlayerInf.FirstOrDefaultAsync(d=>d.id == _userId);
        var warUnit = await _context.WarriorUnits.FirstOrDefaultAsync(d=>d.id == _warUnitId);
        if(user is null || warUnit is null) throw new Exception("user or warUnit is not found");
        if(user.warriorUnitAttribute is null) throw new Exception("user dont have warUnit attrubutes");
        if(user.warriorUnitAttribute.Contains(warUnit)!) throw new Exception("user dont have this warunitAttribute");
        user.warriorUnitAttribute.Remove(warUnit);
        await _context.SaveChangesAsync();
    }
}