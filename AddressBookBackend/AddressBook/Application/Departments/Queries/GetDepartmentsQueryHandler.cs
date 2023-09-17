using AddressBook.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, List<DepartmentModel>>
    {
        private readonly ApplicationDbContext _context;

        public GetDepartmentsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentModel>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _context.Departments.ToListAsync(cancellationToken);
            var res = departments.Select(x => new DepartmentModel
            {
                Id = x.Id,
                NameAr = x.NameAr,
                NameEn = x.NameEn
            });
            return res.ToList();

        }




    }
}