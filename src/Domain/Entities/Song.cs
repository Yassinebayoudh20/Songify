namespace projects.Domain.Entities;

public class Song : BaseAuditableEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public byte[] Image { get; set; }
}