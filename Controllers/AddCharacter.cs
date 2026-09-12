using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterAPI.Dtos;
using VideoGameCharacterAPI.Models;
using VideoGameCharacterAPI.Services;


namespace VideoGameCharacterAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<VideoGameCharacterResponse>>> GetCharacters() => Ok(await service.GetAllCharacterAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<VideoGameCharacterResponse>> GetCharacterById(int id)
    {
        var character = await service.GetCharacterByIdAsync(id);

        // ternary operator would also work
        if (character is null)
        {
            return NotFound("Character not found!");
        }

        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<VideoGameCharacterResponse>> CreateCharacter(CreateCharacterRequest character)
    {
        var newCharacter = await service.AddCharacterAsync(character);
        return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
    {
        var updateCharacter = await service.UpdateCharacterAsync(id, character);
        return updateCharacter ? NoContent() : NotFound("Character with provided ID not found!");
    }

    [HttpDelete("id")]
    public async Task<ActionResult> DeleteCharacter(int id)
    {
        var isDeleted = await service.DeleteCharacterAsync(id);
        return isDeleted ? NoContent() : NotFound("Character with provided ID not found!");
    }

}