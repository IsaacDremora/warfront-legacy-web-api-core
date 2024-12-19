using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FlagService : IFlagService
{
    private readonly AppDbContext _context;
    public FlagService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddFlagAtUser(int _flagId, int _pinfId)
    {
        var user = await _context.PlayerInf.FirstOrDefaultAsync(d=> d.id == _pinfId);
        var flag = await _context.Flags.FirstOrDefaultAsync(x=>x.id == _flagId);
        if (user is null || flag is null) throw new Exception("user or flag is not found or invalid");
        user.flagAttribute?.Add(flag);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveFlagAtUser(int _flagId, int _pinfId)
    {
        var user = await _context.PlayerInf.FirstOrDefaultAsync(d=> d.id == _pinfId);
        var flag = await _context.Flags.FirstOrDefaultAsync(x=>x.id == _flagId);
        if (user is null || flag is null) throw new Exception("user or flag is not found or invalid");
        if (user.flagAttribute.Contains(flag)!) throw new Exception("user dont contain this flag");
        user.flagAttribute.Remove(flag);
        await _context.SaveChangesAsync();
    }
}

