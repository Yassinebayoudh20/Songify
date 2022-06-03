using System.Collections;

namespace Application.Albums.Queries.GetAlbums
{
    public class AlbumListVm
    {
        public IList<AlbumDto> Albums { get; set; }
        public int Count { get; set; }
    }
}