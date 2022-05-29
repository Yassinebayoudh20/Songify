using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projects.Application.Common.Mappings;
using projects.Domain.Entities;

namespace projects.Application.Songs.Queries.GetSongs;
public class SongDto : IMapFrom<Song>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public byte[] Image { get; set; }
}
