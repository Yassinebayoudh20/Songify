using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace projects.Application.Songs.Queries.GetSongs;
public class GetSongsQuery : IRequest<SongsListVm>
{
}
