using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projects.Application.Artists.Queries.GetArtists;
public class ArtistListVm
{
    public IList<ArtistDto> Artists { get; set; }
    public int Count { get; set; }
}
