using Application.Albums.Queries.GetAlbums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Common.Exceptions;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace Application.Albums.Queries.GetAlbumById
{
    public class GetAlbumsDetailsQueryHandler : IRequestHandler<GetAlbumsDetailsQuery, AlbumDetailsVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAlbumsDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AlbumDetailsVm> Handle(GetAlbumsDetailsQuery request, CancellationToken cancellationToken)
        {
            var album =await  _context.Albums.Where(a => a.Id == request.Id)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();

            if(album == null) {
                throw new NotFoundException(nameof(Album),album);
            };

            return new AlbumDetailsVm { Album = album};
        }
    }
}