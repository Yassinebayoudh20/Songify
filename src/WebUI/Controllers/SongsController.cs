using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projects.Application.Songs.Commands.CreateSong;
using projects.Application.Songs.Commands.DeleteSong;
using projects.Application.Songs.Commands.UpdateSong;
using projects.Application.Songs.Queries.GetSongById;
using projects.Application.Songs.Queries.GetSongs;

namespace projects.WebUI.Controllers;
[Authorize]
public class SongsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<SongsListVm>> FindAll()
    {
        var result = await Mediator.Send(new GetSongsQuery());

        return result == null || result.Count == 0 ? NoContent() : Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<SongDetailsVm>> FindById(int Id)
    {
        var result = await Mediator.Send(new GetSongByIdQuery { Id = Id});

        return result == null 
            ? BadRequest($"Song with Id = {Id} was not found") 
            : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody]CreateSongCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateSongCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteSongCommand(id));

        return NoContent();
    }

}
