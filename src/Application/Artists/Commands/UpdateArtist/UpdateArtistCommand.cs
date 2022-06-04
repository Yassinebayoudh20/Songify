using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Common.Exceptions;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace projects.Application.Artists.Commands.UpdateArtist;
public class UpdateArtistCommand : IRequest<int>
{
      public int Id { get; set; }
      public string Name { get; set; }
      public byte[] Photo { get; set; }
}

public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, int>
{
    private readonly IApplicationDbContext _context;
    public UpdateArtistCommandHandler (IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        var artist =await _context.Artists.FindAsync(new object[] { request.Id},cancellationToken);
        if(artist==null) throw new NotFoundException(nameof(Artist),artist);
        
        artist.Name = request.Name;
        artist.Photo = request.Photo;
        

        _context.Artists.Update(artist);
        await _context.SaveChangesAsync(cancellationToken);

        return artist.Id;
    }
}
