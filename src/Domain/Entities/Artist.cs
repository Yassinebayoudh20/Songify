using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projects.Domain.Entities;
public class Artist : BaseAuditableEntity
{
    public Artist()
    {
        Albums = new HashSet<Album>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string MusicType { get; set; }
    public byte[] Photo { get; set; }
    public ICollection<Album> Albums { get; set; }
}
