using APBD10.DTOs;

namespace APBD10.Services;

public interface IDbService
{
    Task<IEnumerable<GetPcDto>> GetAllPcsAsync();
    Task<GetPcComponentsDto> GetPcByIdAsync(int id);
    Task<PostPcResponseDto> PostPcAsync(PostPcDto dto);
    Task UpdatePcAsync(int id, PutPcDto dto);
}