using AutoMapper;
using MediatR;
using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace Application.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<int>
    {
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int? ArtistId { get; set; }
    }

    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateAlbumCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {

        var album = new Album();
        album.Title = request.Title;
        album.Image = request.Image;
        album.ArtistId = request.ArtistId;

        _context.Albums.Add(album);

        await _context.SaveChangesAsync(cancellationToken);

        return album.Id;
        }
    }
}