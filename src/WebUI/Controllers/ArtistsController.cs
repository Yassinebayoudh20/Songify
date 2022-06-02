using Microsoft.AspNetCore.Mvc;
using projects.Application.Artists.Queries.GetArtists;

namespace projects.WebUI.Controllers;
public class ArtistsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ArtistListVm>> FindAll()
    {
        var result = await Mediator.Send(new GetArtistsQuery());

        return result == null || result.Count == 0 ? NoContent() : Ok(result);
    }
}
