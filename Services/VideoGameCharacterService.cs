using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Db;
using VideoGameCharacterAPI.Dtos;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Services;

public class VideoGameCharacterService(AppDbcontext context) : IVideoGameCharacterService
{
    // static List<Character> characters = new List<Character> {
    //     new Models.Character {Id=1, Name="Mario", Game="Super Mario Bros.", Role="Protagonist" },
    //     new Models.Character {Id=2, Name="Yule Msee", Game="Need for Speed: Most Wanted", Role="Hero"},
    //     new Models.Character {Id=3, Name="Clarence 'Razor' Callahan", Game="Need for Speed: Most Wanted", Role="Antagonist"},
    //     new Models.Character {Id=4, Name="Darius", Game="Need for Speed: Carbon", Role="Villain"},
    // };

    public async Task<VideoGameCharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
    {
        var newCharacter = new Character
        {
            Name = character.Name,
            Game = character.Game,
            Role = character.Role,
        };

        context.Characters.Add(newCharacter);
        await context.SaveChangesAsync();

        return new VideoGameCharacterResponse
        {
            Id = newCharacter.Id,
            Name = newCharacter.Name,
            Game = newCharacter.Game,
            Role = newCharacter.Role,
        };
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        var characterExists = await context.Characters.FindAsync(id);
        if (characterExists is null) return false;

        context.Characters.Remove(characterExists);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<VideoGameCharacterResponse>> GetAllCharacterAsync() => await context.Characters.Select(
        c => new VideoGameCharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role,
        }
    ).ToListAsync();    

    public async Task<VideoGameCharacterResponse?> GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters.Where(c => c.Id == id).Select(
        c => new VideoGameCharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role,
        }
    ).FirstOrDefaultAsync();
        return result;
    }

    public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
    {
        var characterExists = await context.Characters.FindAsync(id);
        if (characterExists is null) return false;

        characterExists.Name = character.Name;
        characterExists.Game = character.Game;
        characterExists.Role = character.Role;

        await context.SaveChangesAsync();
        return true;
    }
}