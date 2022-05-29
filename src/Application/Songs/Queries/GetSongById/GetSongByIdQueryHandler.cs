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
using projects.Application.Songs.Queries.GetSongs;

namespace projects.Application.Songs.Queries.GetSongById;
public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, SongDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSongByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<SongDto> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
    {
        var song = await _context.Songs
            .ProjectTo<SongDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(s => s.Id == request.Id,cancellationToken);

        if(song == null) return null;

        return song;
            
    }
}
