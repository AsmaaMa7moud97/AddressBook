using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class EditJobCommandHandler : IRequestHandler<EditJobCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public EditJobCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(EditJobCommand request, CancellationToken cancellationToken)
        {
            var job = _context.JobTitles.Where(x => x.Id == request.Id).FirstOrDefault();
            job.NameAr = request.NameAr;
            job.NameEn = request.NameEn;
            _context.JobTitles.Update(job);
            await _context.SaveChangesAsync();
            return job.Id;
        }
    }
}