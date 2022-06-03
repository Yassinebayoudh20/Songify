using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projects.Application.Common.Interfaces;

namespace Application.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int? ArtistId { get; set; }
    }

    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAlbumCommandHandler()
        {
        }

        public UpdateAlbumCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _context.Albums.Where(a => a.Id == request.Id).SingleOrDefaultAsync();

            album.Title = request.Title;
            album.Image = request.Image;
            album.ArtistId = request.ArtistId;

            _context.Albums.Update(album);

            await _context.SaveChangesAsync(cancellationToken);

            return album.Id;
        }
    }
}