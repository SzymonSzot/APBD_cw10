using APBD10.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext(DbContextOptions options) : base(options) { }

    public AppDbContext() { }
    
    public DbSet<Component> Components { get; set; }
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
}