using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace projects.Application.Artists.Commands.CreateArtist;
public class CreateArtistCommand : IRequest<int>
{
    public string Name { get; set; }
    public byte[] Photo { get; set; }
}

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateArtistCommandHandler (IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
    {
          var artist = new Artist();
        artist.Name = request.Name;
        artist.Photo = request.Photo;

        _context.Artists.Add(artist);

        await _context.SaveChangesAsync(cancellationToken);

        return artist.Id;
    }
}
