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
    public byte[] Photo { get; set; }
    public ICollection<ArtistAlbumsDto> Albums { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Artist, ArtistDto>()
            .ForMember(m => m.Albums.Select(a => a.Title),
                       opt => opt.MapFrom(m => m.Albums.Select(s => s.Title)));
    }
}

public class ArtistAlbumsDto
{
    public string Title { get; set; }
}