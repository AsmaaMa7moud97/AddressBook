using AddressBook.Entity;
using AddressBook.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Application
{
    public class GetSearchEmployessQueryHandler : IRequestHandler<GetSearchEmployeesQuery, List<EmployeeModel>>
    {
        private readonly ApplicationDbContext _context;

        public GetSearchEmployessQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeModel>> Handle(GetSearchEmployeesQuery request, CancellationToken cancellationToken)
        {
           var employees = await _context.Employees
                .Include(t => t.JobTitle)
                 .Include(t => t.Department)
                .ToListAsync(cancellationToken);
            IEnumerable<Employee> res = new List<Employee>();
            res = employees;
            if (!string.IsNullOrEmpty(request.FullName))
            res = employees.Where(x => x.FullName.ToLower().Contains(request.FullName.ToLower()));
            if (!string.IsNullOrEmpty(request.Email))
                res = res.Where(x=>x.Email.ToLower().Contains(request.Email.ToLower()));
            if (!string.IsNullOrEmpty(request.MobileNumber))
                res = res.Where(x => x.MobileNumber.Contains(request.MobileNumber));
            if(request.JobTitleId!=null)
            res = res.Where(x => x.JobTitleId==request.JobTitleId);
            if (request.DepartmentId != null)
                res = res.Where(x => x.DepartmentId == request.DepartmentId);
            var result = res.Select(x => new EmployeeModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                Address=x.Address,
                Age=x.Age,
                DateOfBirth=x.DateOfBirth,
                JobTitleName=x.JobTitle.NameEn,
                DepartmentName=x.Department.NameEn,
                MobileNumber=x.MobileNumber
            });
            return result.ToList();
        }




    }
}