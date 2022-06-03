using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Common.Exceptions;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace Application.Albums.Commands.DeleteAlbum
{
    public record DeleteAlbumCommand(int id) : IRequest;

    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAlbumCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _context.Albums
            .Where(s => s.Id == request.id)
            .SingleOrDefaultAsync();

            if (album == null)
            {
                throw new NotFoundException(nameof(Album), request.id);
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}