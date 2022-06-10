using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Common.Interfaces;

namespace Application.Albums.Queries.GetAlbums
{

    public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, AlbumListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllAlbumsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AlbumListVm> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
             var albums = await _context.Albums
            .Include(al => al.Artist)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

            return new AlbumListVm { Albums = albums, Count = albums.Count };
        }
    }
}