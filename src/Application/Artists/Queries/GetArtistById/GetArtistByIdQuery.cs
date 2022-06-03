using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace projects.Application.Artists.Queries.GetArtistById;
public class GetArtistByIdQuery : IRequest<ArtistDetailsVm>
{
    public int Id { get; set; }
}
