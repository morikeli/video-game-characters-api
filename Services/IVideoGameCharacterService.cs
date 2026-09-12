using VideoGameCharacterAPI.Dtos;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Services;

public interface IVideoGameCharacterService
{
    Task<List<VideoGameCharacterResponse>> GetAllCharacterAsync();
    Task<VideoGameCharacterResponse?> GetCharacterByIdAsync(int id);
    Task<VideoGameCharacterResponse> AddCharacterAsync(CreateCharacterRequest character);
    Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);
    Task<bool> DeleteCharacterAsync(int id);
}
