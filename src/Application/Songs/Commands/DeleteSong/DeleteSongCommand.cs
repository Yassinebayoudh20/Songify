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

namespace projects.Application.Songs.Commands.DeleteSong;


public record DeleteSongCommand(int id) : IRequest;

public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
    {
        var song =await _context.Songs
            .Where(s => s.Id == request.id)
            .SingleOrDefaultAsync(cancellationToken);

        if(song == null)
        {
            throw new NotFoundException(nameof(Song), request.id);
        }

        _context.Songs.Remove(song);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
