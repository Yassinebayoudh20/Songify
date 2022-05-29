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

namespace projects.Application.Songs.Queries.GetSongs;
public class GetSongsQueryHandler : IRequestHandler<GetSongsQuery, SongsListVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSongsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<SongsListVm> Handle(GetSongsQuery request, CancellationToken cancellationToken)
    {
        var songs = await _context.Songs.ProjectTo<SongDto>(_mapper.ConfigurationProvider).ToListAsync();

        if(songs == null)
        {
            return null;
        }

        return new SongsListVm
        {
            Songs = songs,
            Count = songs.Count
        };
    }
}
