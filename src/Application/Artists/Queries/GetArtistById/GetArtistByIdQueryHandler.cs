using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Artists.Queries.GetArtists;
using projects.Application.Common.Exceptions;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace projects.Application.Artists.Queries.GetArtistById;
public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistDetailsVm>
{
       private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArtistByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ArtistDetailsVm> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
    {
       var artist =await  _context.Artists.Where(a => a.Id == request.Id)
       .ProjectTo<ArtistDto>(_mapper.ConfigurationProvider)
       .SingleOrDefaultAsync();

       if(artist == null) {
           throw new NotFoundException(nameof(Artist),artist);
       };

       return new ArtistDetailsVm { Artist = artist};
    }
}
