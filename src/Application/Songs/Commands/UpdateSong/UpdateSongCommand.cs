using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using projects.Application.Common.Exceptions;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace projects.Application.Songs.Commands.UpdateSong;
public class UpdateSongCommand : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public byte[] Image { get; set; }
    public int AlbumId { get; set; }
}

public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
    {
        var song = await _context.Songs.FindAsync(new object[] { request.Id} , cancellationToken);
        
        if(song == null)
        {
            throw new NotFoundException(nameof(Song), request.Id);
        }

        song.Title = request.Title;
        song.Image = request.Image;
        song.AlbumId = request.AlbumId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
