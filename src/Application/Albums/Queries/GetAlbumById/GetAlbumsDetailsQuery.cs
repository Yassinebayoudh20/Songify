using MediatR;

namespace Application.Albums.Queries.GetAlbumById
{
    public class GetAlbumsDetailsQuery : IRequest<AlbumDetailsVm>
    {
        public int Id { get; set; }
    }
}