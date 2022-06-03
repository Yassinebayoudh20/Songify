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

namespace projects.Application.Artists.Commands.DeleteArtist;

public record DeleteArtistCommand(int id) : IRequest;

public class DeleteSongCommandHandler : IRequestHandler<DeleteArtistCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
    {
        var artist =await _context.Artists
            .Where(s => s.Id == request.id)
            .SingleOrDefaultAsync(cancellationToken);

        if(artist == null)
        {
            throw new NotFoundException(nameof(Artist), request.id);
        }

        _context.Artists.Remove(artist);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

