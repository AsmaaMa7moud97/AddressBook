using AddressBook.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, List<JobModel>>
    {
        private readonly ApplicationDbContext _context;

        public GetJobsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobModel>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
        {
           var jobs = await _context.JobTitles.ToListAsync(cancellationToken);
            var res = jobs.Select(x => new JobModel
            {
                Id = x.Id,
                NameAr = x.NameAr,
                NameEn = x.NameEn
            });
            return res.ToList();
        }




    }
}