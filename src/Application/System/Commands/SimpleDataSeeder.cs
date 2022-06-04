using projects.Application.Common.Interfaces;
using projects.Domain.Entities;

namespace Application.System.Commands
{
    public class SimpleDataSeeder
    {
        private readonly IApplicationDbContext _context;

        private readonly Dictionary<int, Artist> Artists = new Dictionary<int, Artist>();
        private readonly Dictionary<int, Song> Songs = new Dictionary<int, Song>();
        private readonly Dictionary<int, Album> Albums = new Dictionary<int, Album>();

        public SimpleDataSeeder(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
             if (_context.Artists.Any())
            {
                return;
            }

            await SeedArtistsAsync(cancellationToken);
            await SeedAlbumsAsync(cancellationToken);
            await SeedSongsAsync(cancellationToken);

        }

        private async Task SeedAlbumsAsync(CancellationToken cancellationToken)
        {
           
            Albums.Add(1, new Album {  Title = "Good Girl Gone Bad", Image = null});
            Albums.Add(2, new Album {  Title = "Monster", Image = null});

            foreach (var album in Albums.Values)
            {
                _context.Albums.Add(album);
            }
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedSongsAsync(CancellationToken cancellationToken)
        {
            
            Songs.Add(1, new Song {  Title = "Disturbia", Image = null });
            Songs.Add(2, new Song {  Title = "Emberella", Image = null});

            Songs.Add(3, new Song {  Title = "Telephone", Image = null});
            Songs.Add(4, new Song {  Title = "Bad Romance", Image = null});

            foreach (var song in Songs.Values)
            {
                _context.Songs.Add(song);
            }

            await _context.SaveChangesAsync(cancellationToken);

        }

        private async Task SeedArtistsAsync(CancellationToken cancellationToken)
        {
           

            Artists.Add(1, new Artist {  Name = "Rihanna", Photo = null });
            Artists.Add(2, new Artist {  Name = "Lady Gaga", Photo = null });
            Artists.Add(3, new Artist {  Name = "Sia", Photo = null });

            foreach (var artist in Artists.Values)
            {
                _context.Artists.Add(artist);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}