using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using projects.Application.Songs.Queries.GetSongs;

namespace projects.Application.Songs.Queries.GetSongById;
public class GetSongByIdQuery : IRequest<SongDto>
{
    public int Id { get; set; }
}
