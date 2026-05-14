using APBD10.Data;
using APBD10.DTOs;
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
}