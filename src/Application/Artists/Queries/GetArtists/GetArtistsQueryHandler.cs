using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Common.Interfaces;

namespace projects.Application.Artists.Queries.GetArtists;
public class GetArtistsQueryHandler : IRequestHandler<GetArtistsQuery, ArtistListVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArtistsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ArtistListVm> Handle(GetArtistsQuery request, CancellationToken cancellationToken)
    {
        var artists =await  _context.Artists
            .Include(i => i.Albums)
            .ProjectTo<ArtistDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new ArtistListVm { Artists = artists, Count = artists.Count };
    }
}
