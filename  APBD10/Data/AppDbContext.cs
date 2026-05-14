using APBD10.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Component> Components { get; set; }
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}