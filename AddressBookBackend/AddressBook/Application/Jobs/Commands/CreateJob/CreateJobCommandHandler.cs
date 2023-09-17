using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application.Commands
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateJobCommandHandler(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new JobTitle();
            job.NameAr = request.NameAr;
            job.NameEn = request.NameEn;
            _context.JobTitles.Add(job);
            await _context.SaveChangesAsync();
            return job.Id;
        }
    }
}