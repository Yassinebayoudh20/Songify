using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projects.Application.Songs.Queries.GetSongs;
public class SongsListVm
{
    public IList<SongDto> Songs { get; set; }
    public int Count { get; set; }
}
