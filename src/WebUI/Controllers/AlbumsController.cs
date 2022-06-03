using Application.Albums.Commands.CreateAlbum;
using Application.Albums.Commands.DeleteAlbum;
using Application.Albums.Commands.UpdateAlbum;
using Application.Albums.Queries.GetAlbumById;
using Application.Albums.Queries.GetAlbums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace projects.WebUI.Controllers
{
    [Authorize]
    public class AlbumsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<AlbumListVm>> FindAll()
        {
            var result = await Mediator.Send(new GetAllAlbumsQuery());

            return result == null || result.Count == 0 ? NoContent() : Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AlbumDetailsVm>> FindById(int Id)
        {
            var result = await Mediator.Send(new GetAlbumsDetailsQuery { Id = Id });

            return result == null
                ? BadRequest($"Album with Id = {Id} was not found")
                : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAlbumCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAlbumCommand command)
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
            await Mediator.Send(new DeleteAlbumCommand(id));

            return NoContent();
        }
    }
}