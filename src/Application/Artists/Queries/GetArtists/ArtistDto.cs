using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using projects.Application.Common.Mappings;
using projects.Domain.Entities;

namespace projects.Application.Artists.Queries.GetArtists;
public class ArtistDto :IMapFrom<Artist>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MusicType { get; set; }
    public byte[] Photo { get; set; }
    public ICollection<ArtistAlbumsDto> Albums { get; set; }

 
}

public class ArtistAlbumsDto : IMapFrom<Album>
{
    public string Title { get; set; }
}