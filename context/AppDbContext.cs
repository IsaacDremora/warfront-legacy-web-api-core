using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users {get;set;}
    public DbSet<PlayerInformation> PlayerInf {get;set;}
    public DbSet<Session> Sessions {get;set;}
    public DbSet<Flag> Flags {get;set;}
    public DbSet<WarriorUnit> WarriorUnits {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Warfront-legacy-users;Username=postgres;Password=1563");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}