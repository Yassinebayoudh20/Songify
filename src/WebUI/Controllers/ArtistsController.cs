using Microsoft.AspNetCore.Mvc;
using projects.Application.Artists.Commands.CreateArtist;
using projects.Application.Artists.Commands.DeleteArtist;
using projects.Application.Artists.Commands.UpdateArtist;
using projects.Application.Artists.Queries.GetArtistById;
using projects.Application.Artists.Queries.GetArtists;
using projects.Application.Common.Exceptions;

namespace projects.WebUI.Controllers;
public class ArtistsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ArtistListVm>> FindAll()
    {
        var result = await Mediator.Send(new GetArtistsQuery());

        return result == null || result.Count == 0 ? NoContent() : Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArtistDetailsVm>> FindById(int id)
    {
        try
        {
            var result = await Mediator.Send(new GetArtistByIdQuery { Id = id });
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateArtistCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, [FromBody] UpdateArtistCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        try
        {
            await Mediator.Send(command);

        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await Mediator.Send(new DeleteArtistCommand(id));

        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }

        return NoContent();
    }
}
