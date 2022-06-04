using MediatR;
using projects.Application.Common.Interfaces;

namespace Application.System.Commands
{
    public class SimpleDataSeederCommand : IRequest
    {
        
    }

    public class SimpleDataSeederCommandHandler : IRequestHandler<SimpleDataSeederCommand>
    {

        private readonly IApplicationDbContext _context;
        public SimpleDataSeederCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SimpleDataSeederCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SimpleDataSeeder(_context);
            await seeder.SeedAllAsync(cancellationToken);
            return Unit.Value;
        }
    }
}