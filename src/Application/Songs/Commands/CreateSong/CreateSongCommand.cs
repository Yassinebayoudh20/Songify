using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace projects.Application.Songs.Commands.CreateSong;
public class CreateSongCommand : IRequest<int>
{
    public string Title { get; set; }
    public byte[] Image { get; set; }
    public int AlbumId { get; set; }
}

public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateSongCommand request, CancellationToken cancellationToken)
    {
        var song = new Song();
        song.Title = request.Title;
        song.Image = request.Image;
        song.AlbumId = request.AlbumId;

        _context.Songs.Add(song);

        await _context.SaveChangesAsync(cancellationToken);

        return song.Id;
    }
}
