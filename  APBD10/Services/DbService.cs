using APBD10.Data;
using APBD10.DTOs;
using APBD10.Entities;
using APBD10.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetPcDto>> GetAllPcsAsync()
    {
        var res = await _dbContext.Pcs
            .Select(p => new GetPcDto()
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync(); 
        
        if (res.Count == 0)
        {
            throw new NotFoundException();
        }
        
        return res;
    }

    public async Task<GetPcComponentsDto> GetPcByIdAsync(int id)
    {
        var res = await _dbContext.Pcs
            .Where(p => p.Id == id)
            .Select(p => new GetPcComponentsDto()
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock,
                // Match the "components" key in your JSON
                PcComponents = p.PcComponents.Select(pc => new PcComponentDto
                {
                    Amount = pc.Amount,
                    Component = new ComponentDto
                    { 
                        Code = pc.Component.Code,
                        Name = pc.Component.Name,
                        Description = pc.Component.Description,
                        Manufacturer = new ManufacturerDto
                        {
                            Id = pc.Component.ComponentManufacturer.Id,
                            Abbreviation = pc.Component.ComponentManufacturer.Abbreviation,
                            FullName = pc.Component.ComponentManufacturer.FullName,
                            FoundationDate = pc.Component.ComponentManufacturer.FoundationDate
                        },
                        Type = new TypeDto
                        {
                            Id = pc.Component.ComponentType.Id,
                            Abbreviation = pc.Component.ComponentType.Abbreviation,
                            Name = pc.Component.ComponentType.Name
                        }
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();
        
        if (res == null)
            throw new NotFoundException();
        
        return res;
    }

    public async Task<PostPcResponseDto> PostPcAsync(PostPcDto dto)
    {
        var newPc = new Pc()
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        await _dbContext.Pcs.AddAsync(newPc);
        await _dbContext.SaveChangesAsync();
        
        return new PostPcResponseDto()
        {
            Id = newPc.Id,
            Name = newPc.Name,
            Weight = newPc.Weight,
            Warranty = newPc.Warranty,
            CreatedAt = newPc.CreatedAt,
            Stock = newPc.Stock
        };
    }

    public async Task UpdatePcAsync(int id, PutPcDto dto)
    {
        var pc = await _dbContext.Pcs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException();
        }
        
        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;
        
        await _dbContext.SaveChangesAsync();
    }
}