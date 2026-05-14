using APBD10.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentType>().HasData(new List<ComponentType>()
        {
            new ComponentType() { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType() { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType() { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" },
            new ComponentType() { Id = 4, Abbreviation = "MB", Name = "Motherboard" }
        });

        // 2. ComponentManufacturers
        modelBuilder.Entity<ComponentManufacturer>().HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer() { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer() { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices, Inc.", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturer() { Id = 3, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacturer() { Id = 4, Abbreviation = "Corsair", FullName = "Corsair Gaming, Inc.", FoundationDate = new DateOnly(1994, 1, 1) }
        });

        // 3. Components
        modelBuilder.Entity<Component>().HasData(new List<Component>()
        {
            new Component() { Code = "INT-I9-139", Name = "Intel Core i9-13900K", Description = "24-core, 32-thread desktop processor", ComponentManufacturerId = 1, ComponentTypeId = 1 },
            new Component() { Code = "AMD-R9-795", Name = "AMD Ryzen 9 7950X", Description = "16-core, 32-thread desktop processor", ComponentManufacturerId = 2, ComponentTypeId = 1 },
            new Component() { Code = "NV-RTX4090", Name = "NVIDIA GeForce RTX 4090", Description = "24GB GDDR6X flagship GPU", ComponentManufacturerId = 3, ComponentTypeId = 2 },
            new Component() { Code = "COR-32G-D5", Name = "Corsair Vengeance 32GB", Description = "2x16GB DDR5 5600MHz RAM", ComponentManufacturerId = 4, ComponentTypeId = 3 }
        });

        // 4. PCs
        modelBuilder.Entity<Pc>().HasData(new List<Pc>()
        {
            new Pc() { Id = 1, Name = "Titan Build", Weight = 12.5f, Warranty = 24, CreatedAt = new DateTime(2023, 10, 1, 10, 0, 0), Stock = 5 },
            new Pc() { Id = 2, Name = "Ryzen Workstation", Weight = 14.0f, Warranty = 36, CreatedAt = new DateTime(2023, 10, 2, 11, 30, 0), Stock = 3 },
            new Pc() { Id = 3, Name = "Budget Gamer", Weight = 9.5f, Warranty = 12, CreatedAt = new DateTime(2023, 10, 5, 9, 15, 0), Stock = 10 }
        });

        // 5. PCComponents (Junction Table)
        modelBuilder.Entity<PcComponent>().HasData(new List<PcComponent>()
        {
            new PcComponent() { PcId = 1, ComponentCode = "INT-I9-139", Amount = 1 },
            new PcComponent() { PcId = 1, ComponentCode = "NV-RTX4090", Amount = 1 },
            new PcComponent() { PcId = 1, ComponentCode = "COR-32G-D5", Amount = 2 },
            new PcComponent() { PcId = 2, ComponentCode = "AMD-R9-795", Amount = 1 }
        });
        
        base.OnModelCreating(modelBuilder);
    }
}