using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteJobCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = _context.JobTitles.Where(x => x.Id == request.Id).FirstOrDefault();
            _context.JobTitles.Remove(job);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}