using projects.Application.Common.Mappings;
using projects.Domain.Entities;

namespace Application.Albums.Queries.GetAlbums
{
    public class AlbumDto : IMapFrom<Album>
    {
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int? ArtistId { get; set; }
    }
}