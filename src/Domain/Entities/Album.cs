namespace projects.Domain.Entities;

public class Album
{
    public Album()
    {
        Songs = new HashSet<Song>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public byte[] Image { get; set; }
    public int? ArtistId { get; set; }
    public Artist Artist { get; set; }
    public ICollection<Song> Songs { get; set; }
}