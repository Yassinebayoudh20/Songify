using AutoMapper;
using projects.Application.Artists.Queries.GetArtists;
using projects.Application.Common.Mappings;
using projects.Domain.Entities;

namespace Application.Albums.Queries.GetAlbums
{
    public class AlbumDto : IMapFrom<Album>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int ArtistId { get; set; }
        public AlbumArtistDto Artist { get; set; }

    }

    public class AlbumArtistDto : IMapFrom<Artist>
    {
        public string Name { get; set; }
        public string MusicType { get; set; }
    }

}